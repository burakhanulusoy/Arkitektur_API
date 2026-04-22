using Arkitektur.Business.DTOs.UserIdentityDtos;
using Arkitektur.Business.Services.UserİdentityServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsersController(IUserService _userService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> UserCreate(CreateUserDto createUserDto)
        {
            var response = await _userService.CreateUserAsync(createUserDto);
           
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserDto loginUserDto)
        {

            var response = await _userService.LoginUserAsync(loginUserDto);

            return response.IsSuccessful ? Ok(response) :BadRequest(response);


        }



    }
}
