using Arkitektur.Business.DTOs.UserIdentityDtos;
using Arkitektur.Business.Services.UserİdentityServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService _userService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> UserCreate(CreateUserDto createUserDto)
        {
            var response = await _userService.CreateUserAsync(createUserDto);
           
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }





    }
}
