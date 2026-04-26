using Arkitektur.Business.Services.AppointmentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController(IAppointmentService _appointmentService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _appointmentService.GetAllAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }


        //https://localhost:5001/api/appointments/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _appointmentService.GetByIdAsync(id);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);


        }

        [AllowAnonymous]

        [HttpPost]
        public async Task<IActionResult>  Create(CreateAppointmentDto createAppointmentDto)
        {

            var response = await _appointmentService.CreateAsync(createAppointmentDto);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _appointmentService.DeleteAsync(id);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppointmentDto updateAppointmentDto)
        {
            var response = await _appointmentService.UpdateAsync(updateAppointmentDto);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }





    }
}
