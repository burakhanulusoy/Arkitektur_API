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

            // 3. ENJEKTE EDİLMİŞ YENİ YAPAY ZEKA PROMPT'U (Deprem, Zemin, Çevre ve Karar Eklendi)
            // 3. ENJEKTE EDİLMİŞ YENİ YAPAY ZEKA PROMPT'U
            string prompt = $@"Sen Arkitektur isimli mimarlık ve gayrimenkul danışmanlık şirketinin profesyonel Baş Mimarı, İnşaat Mühendisi ve Şehir Plancısısın.
Müşterinin haritadan seçtiği arazinin bilgileri şunlar:
- Şehir: {request.City}
- Tam Konum / Adres: {request.FullAddress}
- Koordinatlar: Enlem {request.Latitude}, Boylam {request.Longitude}
- Hayalindeki Ev: {request.HouseDescription}

Lütfen bu boş arazi için son derece resmi, kurumsal ve profesyonel bir rapor hazırla.

ÖNEMLİ KURALLAR: 
1. Yanıtında KESİNLİKLE kalın yazı için '**', '*', başlıklar için '#' gibi Markdown işaretleri KULLANMA! Sadece temiz düz metin kullan.
2. Rapora doğrudan 'Sayın Müşterimiz,' diyerek başla ve boşluk bırakarak paragraflara geç.
3. Raporun girişinde KESİNLİKLE 'Sen Arkitektur olarak' gibi ifadeler KULLANMA! Bunun yerine 'Biz Arkitektur Mimarlık olarak' diyerek profesyonel ve kurumsal bir dil kullan.

Raporda şu bölümler alt alta, net bir Türkçeyle yer alsın:

1. Konum ve Sosyal Çevre Analizi: ({request.FullAddress} koordinatlarına göre buranın şehir merkezi mi, gelişmekte olan bir banliyö mü yoksa köy/kırsal mı olduğunu analiz et. Çevredeki market, hastane ve ulaşım ağlarını değerlendir.)
2. Zemin, Toprak Yapısı ve Deprem Riski: (Toprak yapısı inşaata uygun mu? Bölge AFAD verilerine göre kaçıncı derece deprem bölgesinde yer alıyor? Depreme karşı ne tür bir temel gerekir açıkla.)
3. İmar Durumu ve İnşaat İzni: (Bu adres için tahmini bir imar senaryosu üret ve kısıtlamaları açıkla.)
4. Bölgeye Özel Maliyet Tahmini: (Sadece {request.City} ilindeki güncel piyasa ortalamalarını baz alarak tahmini maliyetleri çıkar ve toplam bütçe aralığını belirt.)
5. Nihai Karar ve Mimari Tavsiye: (Tüm analizleri göz önünde bulundurarak Raporun en sonunda büyük harflerle 'SONUÇ OLARAK BU BÖLGEYE YENİ BİR EV YAPMAK MANTIKLIDIR' veya '...MANTIKSIZDIR' şeklinde kesin bir hüküm bildir.)";
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
        public string FullAddress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string HouseDescription { get; set; }
    }
}