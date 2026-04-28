using Microsoft.AspNetCore.Mvc;
using Arkitektur.WebUI.Services.AiServices;

namespace Arkitektur.WebUI.Controllers
{
    public class AiController(IAIService _aiService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile plotImage, string userPrompt)
        {
            // Basit bir boş kontrolü
            if (plotImage == null || string.IsNullOrEmpty(userPrompt))
            {
                ViewBag.Error = "Lütfen bir arsa fotoğrafı yükleyin ve tasarım detayı girin.";
                return View();
            }

            // DTO yok! Direkt değerleri yolluyoruz.
            var result = await _aiService.ProcessDesignAsync(plotImage, userPrompt);

            // Gelen Tuple (iki değişkenli) sonucu ViewBag'e atıyoruz.
            ViewBag.GeneratedImageUrl = result.ImageUrl;
            ViewBag.Analysis = result.Analysis;

            // ViewBag dolu bir şekilde View'a dönüyoruz
            return View();
        }
    }
}