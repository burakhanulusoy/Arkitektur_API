using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.Entity.Entities;

namespace Arkitektur.Business.DTOs.TeamSocialDtos
{
    public class ResultTeamSocialDto:BaseDto
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public ResultTeamDto Team { get; set; }
        

    }
}
