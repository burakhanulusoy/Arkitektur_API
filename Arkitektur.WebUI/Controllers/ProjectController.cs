using Arkitektur.WebUI.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.WebUI.Controllers
{
    public class ProjectController(ICategoryService _categoryService) : Controller
    {
        public async Task<IActionResult> GetCategoriesWithProjects()
        {
            var result = await _categoryService.GetCategoriesWithProjectsAsync();
            return View(result.Data);
        }
    }
}
