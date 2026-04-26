using Arkitektur.WebUI.DTOs.FeatureDtos;
using Arkitektur.WebUI.Services.FeatureServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class FeatureController(IFeatureService _featureService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var item = await _featureService.GetAllAsync();

            return View(item.Data);
        }

        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
        {
            await _featureService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> UpdateFeature(int id)
        {
            var item = await _featureService.GetByIdAsync(id);
            return View(item.Data);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {
            await _featureService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _featureService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
