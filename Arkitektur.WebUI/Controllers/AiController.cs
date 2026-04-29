using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Arkitektur.WebUI.Controllers
{
    public class AiController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AiController(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Analyze(AiRequestDto request)
        {
            // 1. HARİTADAN SEÇİM YAPILDI MI KONTROLÜ
            if (string.IsNullOrEmpty(request.City) || request.Latitude == 0)
            {
                ViewBag.Error = "Lütfen harita üzerinden bir arazi seçimi yapınız.";
                return View("Index");
            }

            // 2. ARAZİ DOLULUK KONTROLÜ (Düzeltilmiş Simülasyon)
            bool isLandOccupied = CheckIfLandOccupiedMock(request.Latitude, request.Longitude);

            if (isLandOccupied)
            {
                ViewBag.Error = "Maalesef seçtiğiniz konumda halihazırda bir yapı/inşaat bulunmaktadır. Lütfen harita üzerinden BOŞ bir arazi seçiniz.";
                return View("Index");
            }

            var apiKey = _configuration["Gemini:ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                ViewBag.Error = "API Key bulunamadı!";
                return View("Index");
            }

            // 3. YENİ GELİŞMİŞ YAPAY ZEKA PROMPT'U (Tam Konum Eklendi)
            string prompt = $@"Sen Arkitektur isimli mimarlık ve gayrimenkul danışmanlık şirketinin profesyonel Baş Mimarı ve İnşaat Mühendisisin.
Müşterinin haritadan seçtiği arazinin bilgileri şunlar:
- Şehir: {request.City}
- Tam Konum / Adres: {request.FullAddress}
- Koordinatlar: Enlem {request.Latitude}, Boylam {request.Longitude}
- Hayalindeki Ev: {request.HouseDescription}

Lütfen bu boş arazi için son derece resmi, kurumsal ve profesyonel bir rapor hazırla.

ÖNEMLİ KURAL: Yanıtında KESİNLİKLE kalın yazı için '**', '*', başlıklar için '#' gibi Markdown işaretleri KULLANMA! Sadece temiz, paragraflara ayrılmış düz metin formatında yaz. 

Raporda şu bölümler alt alta, net bir Türkçeyle yer alsın:
1. Şehir, Konum ve Coğrafi Analiz: ({request.FullAddress} konumunun çevresel özellikleri, altyapı potansiyeli ve zemin yapısı hakkında bilgi ver. Boş arazinin potansiyelinden bahset.)
2. İmar Durumu ve İnşaat İzni: (Bu tam adresteki boş arazi için tahmini bir imar senaryosu üret. Tarım arazisi riski varsa kısıtlamaları açıkla.)
3. {request.City} Bölgesine Özel Maliyet Tahmini: (Sadece {request.City} ilindeki güncel piyasa ortalamalarını baz alarak tahmini birim maliyetleri çıkar ve liste yap:
   - Hazır Beton (m3)
   - İnşaat Demiri (Ton)
   - Tuğla / Bims
   - Zemin Kaplama / Parke (m2)
   - Fayans / Seramik (m2)
   - Dış ve İç Cephe Boya Malzemeleri
   Ardından projenin toplam tahmini bütçe aralığını belirt.)
4. Mimari Tavsiye: (Arazinin boş durumu, iklimi ve müşterinin hayaline en uygun yalıtım, temel tipi ve tasarruf sağlayacak yapı malzemesi tavsiyelerini ver.)";

            var endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-pro:generateContent?key={apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new { parts = new[] { new { text = prompt } } }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(endpoint, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    using JsonDocument doc = JsonDocument.Parse(responseString);
                    var aiResponseText = doc.RootElement
                        .GetProperty("candidates")[0]
                        .GetProperty("content")
                        .GetProperty("parts")[0]
                        .GetProperty("text").GetString();

                    ViewBag.AiResult = aiResponseText;
                    return View("Result");
                }
                else
                {
                    ViewBag.Error = $"API Hatası: {responseString}";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Bir hata oluştu: {ex.Message}";
                return View("Index");
            }
        }

        // --- ARAZİ DOLULUK SİMÜLASYONU (Mock) ---
        private bool CheckIfLandOccupiedMock(double latitude, double longitude)
        {
            // Kullanıcıyı sürekli hata ile boğmamak için doluluk ihtimalini %5'e düşürdük.
            // Sadece test amaçlıdır, ileride gerçek API ile değiştirilecek.
            int randomCheck = new Random().Next(1, 101);
            if (randomCheck <= 5)
            {
                return true;  // %5 ihtimalle arazi dolu
            }
            return false; // %95 ihtimalle arazi boş
        }
    }

    // --- DATA TRANSFER OBJECT (DTO) ---
    public class AiRequestDto
    {
        public string City { get; set; }
        public string FullAddress { get; set; } // YENİ EKLENEN TAM ADRES
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string HouseDescription { get; set; }
    }
}