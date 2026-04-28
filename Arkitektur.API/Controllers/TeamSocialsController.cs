using Amazon.S3.Model.Internal.MarshallTransformations;
using Arkitektur.Business.DTOs.TeamSocialDtos;
using Arkitektur.Business.Services.TeamSocialServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamSocialsController(ITeamSocialService _teamSocialService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllTeamSocial()
        {
            var response = await _teamSocialService.GetTeamSocialWithTeamMemberAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [AllowAnonymous]
        [HttpGet("withTeamMember")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _teamSocialService.GetTeamSocialWithTeamMemberAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _teamSocialService.GetByIdTeamSocialWithTeamMemberAsync(id);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamSocialDto dto)
        {

            var response = await _teamSocialService.CreateAsync(dto);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeamSocialDto dto)
        {
            var response = await _teamSocialService.UpdateAsync(dto);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {

            var response = await _teamSocialService.DeleteAsync(id);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }





    }
}
