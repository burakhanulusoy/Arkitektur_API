using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.RoleIdentityDtos;

namespace Arkitektur.Business.Services.RoleIdentityServices
{
    public interface IRoleService
    {
        Task<BaseResult<object>> CreateRoleAsync(CreateRoleDto createRoleDto);

        Task<BaseResult<List<ResultRoleDto>>> GetAllRolesAsync();


    }
}
