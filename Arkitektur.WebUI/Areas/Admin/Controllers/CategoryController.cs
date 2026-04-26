using Arkitektur.WebUI.DTOs.CategoryDtos;
using Arkitektur.WebUI.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    //https://localhost:7600/Admin/Category/Index
    //index defaullttur yazmasanda olur

    [Area("Admin")]
    [Authorize]
    public class CategoryController(ICategoryService _categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {

            var response = await _categoryService.GetAllAsync();

            return View(response.Data);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateAsync(createCategoryDto);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            
            var response = await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var response = await _categoryService.GetByIdAsync(id);

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
             await _categoryService.UpdateAsync(updateCategoryDto);

            return RedirectToAction(nameof(Index));


        }



    }
}
