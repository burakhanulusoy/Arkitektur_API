using Arkitektur.WebUI.Services.TeamServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents._DefaultComponents
{
    public class _DefaultTeamViewComponents(ITeamService _teamService):ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var teamMembers = await _teamService.GetAllAsync();
            return View(teamMembers.Data);

        }




    }
}
