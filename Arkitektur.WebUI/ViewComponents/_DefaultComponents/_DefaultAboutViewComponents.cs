using Arkitektur.WebUI.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents._DefaultComponents
{
    public class _DefaultAboutViewComponents(IAboutService _aboutService):ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var abouts = await _aboutService.GetAllAsync();

            var lastAbout = abouts.Data.OrderByDescending(x=>x.Id).FirstOrDefault();

            ViewBag.time = DateTime.Now.Year - lastAbout.StartYear;

            return View(lastAbout);

        }

    }
}
