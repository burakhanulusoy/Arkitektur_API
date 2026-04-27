using Arkitektur.Business.DTOs.TeamSocialDtos;
using Arkitektur.Business.Services.GenericServices;
using Arkitektur.Business.Validators.TeamSocialValidators;

namespace Arkitektur.Business.Services.TeamSocialServices
{
    public interface ITeamSocialService : IGenericService<ResultTeamSocialDto,CreateTeamSocialDto,UpdateTeamSocialDto>
    {


    }
}
