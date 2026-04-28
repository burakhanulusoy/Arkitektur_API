using Arkitektur.WebUI.DTOs.TeamSocialDtos;
using Arkitektur.WebUI.Services.TeamServices;
using Arkitektur.WebUI.Services.TeamSocialServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arkitektur.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamSocialController(ITeamSocialService _teamSocialService , ITeamService _teamService) : Controller
    {
        private async Task GetTeamMembersAsync()
        {
            var teams = await _teamService.GetAllAsync();

            ViewBag.teams=(from team in teams.Data
                           select new SelectListItem
                           {
                               Text=team.NameSurname,
                               Value=team.Id.ToString()
                           }).ToList();


        }

        public async Task<IActionResult> Index()
        {

            var teamSocialWithTeamMember = await _teamService.GetAllAsync();
            return View(teamSocialWithTeamMember.Data);
          
        }

        public async Task<IActionResult> CreateTeamSocial()
        {
            await GetTeamMembersAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  CreateTeamSocial(CreateTeamSocialDto dto)
        {
            await GetTeamMembersAsync();
            await _teamSocialService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DeleteTeamSocial(int id)
        {
            await _teamSocialService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UpdateTeamSocial(int id)
        {
            await GetTeamMembersAsync();
            var team = await _teamSocialService.GetByIdAsync(id);
            return View(team.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeamSocial(UpdateTeamSocialDto updateDto)
        {
            await GetTeamMembersAsync();
            await _teamSocialService.UpdateAsync(updateDto);
            return RedirectToAction(nameof(Index));

        }














    }
}
