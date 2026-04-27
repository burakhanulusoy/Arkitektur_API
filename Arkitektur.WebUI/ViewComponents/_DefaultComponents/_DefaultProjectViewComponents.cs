using Arkitektur.WebUI.Services.CategoryServices;
using Arkitektur.WebUI.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents._DefaultComponents
{
    public class _DefaultProjectViewComponents(ICategoryService _categoryService):ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var getCategoriesWithProjects=await _categoryService.GetCategoriesWithProjectsAsync();
            return View(getCategoriesWithProjects.Data);

        }




    }
}
