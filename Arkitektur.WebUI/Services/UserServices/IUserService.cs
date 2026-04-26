using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.JwtTokenDtos;
using Arkitektur.WebUI.DTOs.UserDtos;

namespace Arkitektur.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<BaseResult<List<ResultUserDto>>> GetAllUserAsync();

        Task<BaseResult<List<AssignRoleDto>>> GetUserForeRoleAssignAsync(int id);

        Task<BaseResult<object>> AssignRoleAsync(List<AssignRoleDto> assignRoleDtos);

        Task<BaseResult<TokenResponseDto>> LoginAsync(LoginUserDto userDto);

        Task<BaseResult<object>> CreateUserAsync(CreateUserDto createUserDto);


    }
}
