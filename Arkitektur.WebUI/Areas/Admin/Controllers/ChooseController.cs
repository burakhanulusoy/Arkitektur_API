using Arkitektur.WebUI.DTOs.ChooseDtos;
using Arkitektur.WebUI.Services.ChooseServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChooseController(IChooseService _chooseService) : Controller
    {
       public async Task<IActionResult> Index()
        {
            var item = await _chooseService.GetAllAsync();

            return View(item.Data);
        }

        public IActionResult CreateChoose()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateChoose(CreateChooseDto dto)
        {
            await _chooseService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> UpdateChoose(int id)
        {
            var item = await _chooseService.GetByIdAsync(id);
            return View(item.Data);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateChoose(UpdateChooseDto dto)
        {
            await _chooseService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteChoose(int id)
        {
            await _chooseService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

    }
}
