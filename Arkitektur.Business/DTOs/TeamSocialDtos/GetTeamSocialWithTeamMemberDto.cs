using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Business.DTOs.TeamSocialDtos
{
    public class GetTeamSocialWithTeamMemberDto:BaseDto
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }

        public TeamDto Team { get; set; }
        public int TeamId { get; set; }


    }
}
