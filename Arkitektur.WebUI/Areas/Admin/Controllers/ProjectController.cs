using Arkitektur.WebUI.DTOs.ProjectDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.CategoryServices;
using Arkitektur.WebUI.Services.ProjectServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class ProjectController(IProjectService _projectService,ICategoryService _categoryService) : Controller
    {

        //bu metot hem postta hem gette hep calişir
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var actionName = context.RouteData.Values["action"]?.ToString();

            // Sadece bu sayfalarda kategorilere ihtiyacım var!
            if (actionName.Contains("Create") || actionName.Contains("Update"))
            {
                await GetCategoriesAsync();
            }

            // 2. Action'ı çalıştır (Yani CreateProject veya UpdateProject içine girer)
            var executedContext = await next();

            // 3. EĞER servis 'throw' fırlatmışsa burası yakalar!
            if (executedContext.Exception is ApiValidationException ex)
            {
                // Hataları ekrana bas
                foreach (var error in ex.Errors)
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                // Kullanıcıyı geldiği sayfaya, yazdığı verilerle (Model) geri gönder
                executedContext.Result = View(context.RouteData.Values["action"].ToString(), context.ActionArguments.Values.FirstOrDefault());

                // "Hatayı ben hallettim, sistemi çökertme" diyoruz
                executedContext.ExceptionHandled = true;
            }
        }

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
