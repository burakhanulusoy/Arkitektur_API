using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes; // JSON okumak için eklediğimiz kritik kütüphane

namespace Arkitektur.WebUI.Services.AiServices
{
    // --- INTERFACE'LER ---
    public interface IGeminiService
    {
        Task<string> AnalyzePlotAsync(IFormFile file);
    }

    public interface ILeonardoService
    {
        Task<string> UploadImageAsync(IFormFile file);
        Task<string> StartGenerationAsync(string initImageId, string prompt);
        Task<string> GetResultAsync(string generationId);
    }

    public interface IAIService
    {
        Task<(string ImageUrl, string Analysis)> ProcessDesignAsync(IFormFile plotImage, string userPrompt);
    }

    // --- SINIFLAR ---
    public class GeminiService(HttpClient _httpClient, IConfiguration _config) : IGeminiService
    {
        private readonly string _apiKey = _config["Gemini:ApiKey"];

        public async Task<string> AnalyzePlotAsync(IFormFile file)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var base64Image = Convert.ToBase64String(ms.ToArray());

            var requestBody = new
            {
                contents = new[] {
                    new {
                        parts = new object[] {
                            new { text = "Act as an expert Senior Architect. Analyze this plot for AI image generation. Output ONLY technical architectural tags in English (terrain, light, vegetation, surroundings). No full sentences." },
                            new { inline_data = new { mime_type = file.ContentType, data = base64Image } }
                        }
                    }
                }
            };

            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-pro:generateContent?key={_apiKey}";
            var response = await _httpClient.PostAsJsonAsync(url, requestBody);
            var responseString = await response.Content.ReadAsStringAsync();

            // Eğer API bir hata fırlattıysa, gizleme, bize göster:
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Gemini API Hatası: {responseString}");
            }

            // JsonNode ile güvenli ayrıştırma
            var jsonNode = JsonNode.Parse(responseString);
            return jsonNode["candidates"][0]["content"]["parts"][0]["text"].ToString();
        }
    }

    public class LeonardoService(HttpClient _client, IConfiguration _config) : ILeonardoService
    {
        private readonly string _apiKey = _config["Leonardo:ApiKey"];

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            // 1. Leonardo API'sine istek atmak için şifremizi ekliyoruz
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var extension = Path.GetExtension(file.FileName).TrimStart('.');
            if (string.IsNullOrEmpty(extension)) extension = "jpg";

            var initRes = await _client.PostAsJsonAsync("https://cloud.leonardo.ai/api/rest/v1/init-image", new { extension = extension });
            var initString = await initRes.Content.ReadAsStringAsync();

            if (!initRes.IsSuccessStatusCode) throw new Exception($"Leonardo Init Hatası: {initString}");

            var initNode = JsonNode.Parse(initString);
            string uploadUrl = initNode["uploadInitImage"]["url"].ToString();
            string imageId = initNode["uploadInitImage"]["id"].ToString();

            string fieldsStr = initNode["uploadInitImage"]["fields"].ToString();
            var fields = JsonSerializer.Deserialize<Dictionary<string, string>>(fieldsStr);

            using var content = new MultipartFormDataContent();

            foreach (var field in fields)
            {
                content.Add(new StringContent(field.Value), field.Key);
            }

            var streamContent = new StreamContent(file.OpenReadStream());
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            content.Add(streamContent, "file", file.FileName);

            // ÇÖZÜM BURADA: Amazon S3'e yüklerken şifre (Bearer token) gitmesin diye 
            // tertemiz yeni bir HttpClient kullanıyoruz.
            using var s3Client = new HttpClient();
            var uploadRes = await s3Client.PostAsync(uploadUrl, content);

            if (!uploadRes.IsSuccessStatusCode)
            {
                var err = await uploadRes.Content.ReadAsStringAsync();
                throw new Exception($"Leonardo S3 Yükleme Hatası: {err}");
            }

            return imageId;
        }
        public async Task<string> StartGenerationAsync(string initImageId, string prompt)
        {
            var body = new
            {
                prompt = prompt,
                width = 1024,
                height = 768,

                // ÇÖZÜM BURADA: "_generation_" kısmını sildik. Dışarıdan yüklenen fotoğraflar için sadece init_image_id olmalı!
                init_image_id = initImageId,

                init_strength = 0.65
            };

            var response = await _client.PostAsJsonAsync("https://cloud.leonardo.ai/api/rest/v1/generations", body);
            var resString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Leonardo Çizim Başlatma Hatası: {resString}");

            var resNode = JsonNode.Parse(resString);
            return resNode["sdGenerationJob"]["generationId"].ToString();
        }
        public async Task<string> GetResultAsync(string generationId)
        {
            while (true)
            {
                var response = await _client.GetAsync($"https://cloud.leonardo.ai/api/rest/v1/generations/{generationId}");
                var resString = await response.Content.ReadAsStringAsync();
                var resNode = JsonNode.Parse(resString);

                string status = resNode["generations_by_pk"]["status"].ToString();

                if (status == "COMPLETE")
                {
                    return resNode["generations_by_pk"]["generated_images"][0]["url"].ToString();
                }
                else if (status == "FAILED")
                {
                    throw new Exception("Leonardo görseli oluşturamadı, API tarafında hata verdi.");
                }

                await Task.Delay(3000);
            }
        }
    }

    public class AIManager(IGeminiService _gemini, ILeonardoService _leonardo) : IAIService
    {
        public async Task<(string ImageUrl, string Analysis)> ProcessDesignAsync(IFormFile plotImage, string userPrompt)
        {
            var technicalTags = await _gemini.AnalyzePlotAsync(plotImage);
            var imageId = await _leonardo.UploadImageAsync(plotImage);

            string masterPrompt = $"Professional architectural visualization of {userPrompt}, " +
                                  $"integrated into {technicalTags}, hyper-realistic, octane render, " +
                                  $"architectural photography, 8k, cinematic lighting, sharp details.";

            var jobId = await _leonardo.StartGenerationAsync(imageId, masterPrompt);
            var finalUrl = await _leonardo.GetResultAsync(jobId);

            return (finalUrl, technicalTags);
        }
    }
}