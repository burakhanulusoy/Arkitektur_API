using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents._DefaultComponents
{
    public class _DefaultProjectViewComponents:ViewComponent
    {

        public IViewComponentResult InvokeAsync()
        {
            return View();
        }




    }
}
