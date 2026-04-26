using Arkitektur.WebUI.DTOs.AboutDtos;
using Arkitektur.WebUI.Services.AboutServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController(IAboutService _aboutService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var abouts = await _aboutService.GetAllAsync();
            return View(abouts.Data);
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {

            await _aboutService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto aboutDto)
        {

            await _aboutService.CreateAsync(aboutDto);

            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            return View(about.Data);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto aboutDto)
        {
            await _aboutService.UpdateAsync(aboutDto);
            return RedirectToAction(nameof(Index));


        }








    }
}
