using Arkitektur.WebUI.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.WebUI.ViewComponents._DefaultComponents
{
    public class _DefaultTestimonialViewComponents(ITestimonialService testimonialService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await testimonialService.GetAllAsync();
            return View(items.Data);

        }




    }
}
