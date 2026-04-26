using Arkitektur.Business.DTOs.UserIdentityDtos;
using Arkitektur.Business.Services.UserİdentityServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService _userService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> UserCreate(CreateUserDto createUserDto)
        {
            var response = await _userService.CreateUserAsync(createUserDto);
           
            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }
        [AllowAnonymous]

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserDto loginUserDto)
        {

            var response = await _userService.LoginUserAsync(loginUserDto);

            return response.IsSuccessful ? Ok(response) :BadRequest(response);


        }

        [HttpGet]
        public async Task<ActionResult<List<ResultUserDto>>> GetAll()
        {
            var response= await _userService.GetAllUserAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }


    }
}
