using Arkitektur.WebUI.DTOs.ContactDtos;
using Arkitektur.WebUI.Services.ContactService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class ContactController(IContactService _contactService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var item = await _contactService.GetAllAsync();

            return View(item.Data);
        }

        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto dto)
        {
            await _contactService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> UpdateContact(int id)
        {
            var item = await _contactService.GetByIdAsync(id);
            return View(item.Data);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto dto)
        {
            await _contactService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

    }
}
