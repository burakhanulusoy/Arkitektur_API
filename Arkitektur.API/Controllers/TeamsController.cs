using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.Business.Services.TeamServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController(ITeamService _teamService) : ControllerBase
    {

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _teamService.GetAllAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _teamService.GetByIdAsync(id);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamDto dto)
        {

            var response = await _teamService.CreateAsync(dto);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeamDto dto)
        {
            var response = await _teamService.UpdateAsync(dto);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _teamService.DeleteAsync(id);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }
    }
}
