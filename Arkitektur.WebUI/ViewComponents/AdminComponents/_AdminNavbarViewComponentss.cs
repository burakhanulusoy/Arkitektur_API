using Arkitektur.WebUI.Services.AppointmentServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.WebUI.ViewComponents.AdminComponents
{
    public class _AdminNavbarViewComponentss(IAppointmentService _appointmentService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var last5Appointmments = (await _appointmentService.GetAllAsync()).Data.OrderByDescending(x=>x.Id).Where(x=>x.Status==Enums.AppointmentStatus.Pending).ToList();
            ViewBag.Count = last5Appointmments.Count;

            var fullName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "FullName")?.Value;
            var imageUrl = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "ImageUrl")?.Value;
            ViewBag.FullName = fullName;
            ViewBag.ImageUrl = imageUrl;
            return View(last5Appointmments);
        }


    }
}
