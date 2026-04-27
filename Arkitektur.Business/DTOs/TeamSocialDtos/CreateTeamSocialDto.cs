using Arkitektur.Business.DTOs.TeamDtos;

namespace Arkitektur.Business.DTOs.TeamSocialDtos
{
    public class CreateTeamSocialDto
    {
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }

        public ResultTeamDto Team { get; set; }
    }
}
