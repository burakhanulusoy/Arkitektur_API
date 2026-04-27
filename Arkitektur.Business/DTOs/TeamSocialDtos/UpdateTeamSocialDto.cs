using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.Entity.Entities;

namespace Arkitektur.Business.DTOs.TeamSocialDtos
{
    public class UpdateTeamSocialDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }

        public ResultTeamDto Team { get; set; }
    }
}
