using Arkitektur.Business.Base;
using Arkitektur.Entity.Entities;

namespace Arkitektur.Business.DTOs.TeamDtos
{
    public class ResultTeamDto : BaseDto
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }  //iþi


        public IList<TeamSocial> TeamSocials { get; set; }

    }
}
