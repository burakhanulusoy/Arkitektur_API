using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents.AdminSideBarComponents
{
    public class AdminSidebarComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }



    }
}
