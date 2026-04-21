using Arkitektur.Business.DTOs.RoleIdentityDtos;
using Arkitektur.Business.Services.RoleIdentityServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleService _roleService) : ControllerBase
    {
        [HttpPost("createdRole")]
        public async Task<IActionResult> Create(CreateRoleDto createRoleDto)
        {

            var response = await _roleService.CreateRoleAsync(createRoleDto);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);


        }

        [HttpGet("getAllRoles")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _roleService.GetAllRolesAsync();

            return response.IsSuccessful ? Ok(response): BadRequest(response);

        }




    }
}
