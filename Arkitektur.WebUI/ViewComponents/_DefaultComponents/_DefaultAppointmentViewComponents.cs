using Arkitektur.WebUI.Services.AppointmentServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents._DefaultComponents
{
    public class _DefaultAppointmentViewComponents:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }



    }
}
