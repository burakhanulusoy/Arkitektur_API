using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.Business.Services.AboutServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

 //   [Authorize(Roles ="deneme")]
    public class AboutsController(IAboutService _aboutService) : ControllerBase
    {
        // unutma boyle action resılt kullanıca neler gırılecegı goızkuyor !!!!!!!!!!!!!!!!!!!!!11


        [HttpGet]
        public async Task<ActionResult<List<ResultAboutDto>>> GetAll()
        {
            var response = await _aboutService.GetAllAboutAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _aboutService.GetAboutByIdAsync(id);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);


        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {

            var response = await  _aboutService.CreateAboutAsync(createAboutDto);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);//created 201,ok 200

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _aboutService.DeleteAboutAsync(id);

            return response.IsSuccessful ? NoContent() : BadRequest(response);


        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            var response = await _aboutService.UpdateAboutAsync(updateAboutDto);
            return response.IsSuccessful ? NoContent() : BadRequest(response);
        }



    }
}
