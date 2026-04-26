using Arkitektur.WebUI.DTOs.BannerDtos;
using Arkitektur.WebUI.Services.BannerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BannerController(IBannerService _bannerService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var banners = await _bannerService.GetAllAsync();

            return View(banners.Data);
        }

        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            await _bannerService.CreateAsync(createBannerDto);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> UpdateBanner(int id)
        {
            var banner = await _bannerService.GetByIdAsync(id);
            return View(banner.Data);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            await _bannerService.UpdateAsync(updateBannerDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteBanner(int id)
        {

            await _bannerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }


    }
}
