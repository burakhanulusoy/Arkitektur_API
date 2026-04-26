using Arkitektur.WebUI.DTOs.UserDtos;
using Arkitektur.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Controllers
{
    public class AuthController(IUserService _userService) : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            await _userService.LoginAsync(loginUserDto);

            return RedirectToAction("Index", "About", new { Area = "Admin" });

        }

    }
}
