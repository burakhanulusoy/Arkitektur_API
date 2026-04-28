using Arkitektur.WebUI.DTOs.TestimonialDtos;
using Arkitektur.WebUI.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController(ITestimonialService _testimonialService)  : Controller
    {
        public async Task<IActionResult> Index()
        {
            var items = await _testimonialService.GetAllAsync();
            return View(items.Data);
        }

        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto testimonialDto)
        {
            await _testimonialService.CreateAsync(testimonialDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> UpdateTestimonail(int id)
        {
            var testimonial = await _testimonialService.GetByIdAsync(id);
            return View(testimonial.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonail(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialService.UpdateAsync(updateTestimonialDto);
            return RedirectToAction(nameof(Index));

        }
    }
}
