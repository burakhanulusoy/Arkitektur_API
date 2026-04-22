using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.RoleAssignDtos;

namespace Arkitektur.Business.Services.RoleAssignServices
{
    public interface IAssignRoleService
    {
        Task<BaseResult<List<AssignRoleDto>>> GetUserForRoleAssignAsync(int id);

        Task<BaseResult<object>> AssignRoleAsync(List<AssignRoleDto> assignRoleDtos);


    }
}
