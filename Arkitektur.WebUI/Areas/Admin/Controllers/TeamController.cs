using Arkitektur.WebUI.DTOs.TeamDtos;
using Arkitektur.WebUI.Services.TeamServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController(ITeamService _teamService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var teams = await _teamService.GetAllAsync();
            return View(teams.Data);
        }

        public IActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto createDto)
        {
            await _teamService.CreateAsync(createDto);
            return RedirectToAction(nameof(Index));

        
        }



        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UpdateTeam(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            return View(team.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateDto)
        {
            await _teamService.UpdateAsync(updateDto);
            return RedirectToAction(nameof(Index));
            
        }








    }
}
