using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents._AdminComponents
{
    public class _AdminHeadViewComponents:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }



    }
}
