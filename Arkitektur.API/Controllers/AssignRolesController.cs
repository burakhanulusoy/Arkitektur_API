using Arkitektur.Business.DTOs.RoleAssignDtos;
using Arkitektur.Business.Services.RoleAssignServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignRolesController(IAssignRoleService _assignRoleService) : ControllerBase
    {


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserForAssignRole(int id)
        {
           var response = await _assignRoleService.GetUserForRoleAssignAsync(id);

           return response.IsSuccessful ? Ok(response) : BadRequest(response);


        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleDtos)
        {

            var response = await _assignRoleService.AssignRoleAsync(assignRoleDtos);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }


    }
}
