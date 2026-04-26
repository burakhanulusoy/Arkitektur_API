using Arkitektur.WebUI.Services.AppointmentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AppointmentController(IAppointmentService _appointmentService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentService.GetAllAsync();
            return View(appointments.Data);
        }

        public async Task<IActionResult> ApproveAppointment(int id)
        {

            var appointment = await _appointmentService.GetByIdAsync(id);

            var result = await _appointmentService.ApproveAsync(id);
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> CancelAppointment(int id)
        {
            var result = await _appointmentService.CancelAsync(id);
            return RedirectToAction(nameof(Index));


        }




    }
}
