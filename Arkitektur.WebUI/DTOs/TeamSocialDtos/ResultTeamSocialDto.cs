using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TeamDtos;

namespace Arkitektur.WebUI.DTOs.TeamSocialDtos
{
    public class ResultTeamSocialDto : BaseDto
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public ResultTeamDto Team { get; set; }

    }
}
