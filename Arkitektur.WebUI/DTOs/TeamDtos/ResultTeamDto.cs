using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TeamSocialDtos;

namespace Arkitektur.WebUI.DTOs.TeamDtos
{
    public class ResultTeamDto : BaseDto
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }  //işi
       
         public IList<ResultTeamSocialDto> TeamSocials { get; set; }
    }
}
