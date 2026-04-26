using Arkitektur.Business.DTOs.ChooseDtos;
using Arkitektur.Business.Services.ChooseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoossesController(IChooseService _chooseService) : ControllerBase
    {
        [AllowAnonymous]

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _chooseService.GetAllAsync();

            return response.IsSuccessful ? Ok(response):BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _chooseService.GetByIdAsync(id);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChooseDto createChooseDto)
        {
            var response = await _chooseService.CreateAsync(createChooseDto);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateChooseDto updateChooseDto)
        {
            var response = await _chooseService.UpdateAsync(updateChooseDto);
           
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _chooseService.DeleteAsync(id);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }




    }
}
