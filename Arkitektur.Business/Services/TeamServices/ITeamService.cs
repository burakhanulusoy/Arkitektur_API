using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.Business.Services.GenericServices;

namespace Arkitektur.Business.Services.TeamServices
{
    public interface ITeamService:IGenericService<ResultTeamDto,CreateTeamDto,UpdateTeamDto>
    {
    }
}
