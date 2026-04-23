using Arkitektur.WebUI.DTOs.ProjectDtos;
using Arkitektur.WebUI.Services.CategoryServices;
using Arkitektur.WebUI.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController(IProjectService _projectService,ICategoryService _categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {

            var projects = await _projectService.GetAllProjectsWithCategoryAsync();
            return View(projects.Data);
        }

        private async Task GetCategoriesAsync()
        {
            var result = await _categoryService.GetAllAsync();

            var categories = result.Data;

            ViewBag.categories = (from category in categories
                                  select new SelectListItem
                                  {
                                      Text = category.CategoryName,
                                      Value = category.Id.ToString()

                                  }).ToList();


        }




        public async Task<IActionResult> CreateProject()
        {
            await GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectDto procejtDto)
        {
            await GetCategoriesAsync(); //create işleminde hata alırısma diye koymak zorundayım

            await _projectService.CreateProjectAsync(procejtDto);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProjectAsync(id);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UpdateProject(int id)
        {
            await GetCategoriesAsync();

            var project = await _projectService.GetByIdProjectAsync(id);

            return View(project.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto procejtDto)
        {
            await GetCategoriesAsync();

            await _projectService.UpdateProjectAsync(procejtDto);
           
            return RedirectToAction(nameof(Index));
        }









    }
}
