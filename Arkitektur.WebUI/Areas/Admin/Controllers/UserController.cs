using Arkitektur.WebUI.DTOs.UserDtos;
using Arkitektur.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Authorize]

    [Area("Admin")]
    public class UserController(IUserService _userService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUserAsync();
            return View(users.Data);
        }

        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userService.GetUserForeRoleAssignAsync(id);  
            return View(user.Data);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> roleDtos)
        {
            await _userService.AssignRoleAsync(roleDtos);
            return RedirectToAction(nameof(Index));
        }

    }
}
