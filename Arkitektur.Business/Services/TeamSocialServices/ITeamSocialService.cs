using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TeamSocialDtos;
using Arkitektur.Business.Services.GenericServices;

namespace Arkitektur.Business.Services.TeamSocialServices
{
    public interface ITeamSocialService : IGenericService<ResultTeamSocialDto,CreateTeamSocialDto,UpdateTeamSocialDto>
    {
        Task<BaseResult<List<GetTeamSocialWithTeamMemberDto>>> GetTeamSocialWithTeamMemberAsync();
        Task<BaseResult<GetTeamSocialWithTeamMemberDto>> GetByIdTeamSocialWithTeamMemberAsync(int id);

    }
}
