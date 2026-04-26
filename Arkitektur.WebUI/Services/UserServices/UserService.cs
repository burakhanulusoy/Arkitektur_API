using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.UserDtos;
using Arkitektur.WebUI.Exceptions;

namespace Arkitektur.WebUI.Services.UserServices
{
    public class UserService(HttpClient _client) : IUserService
    {
        public async Task<BaseResult<object>> AssignRoleAsync(List<AssignRoleDto> assignRoleDtos)
        {

            var response = await _client.PostAsJsonAsync("assignRoles", assignRoleDtos);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;

        }

        public async Task<BaseResult<List<ResultUserDto>>> GetAllUserAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultUserDto>>>("users");
        }

        public async Task<BaseResult<List<AssignRoleDto>>> GetUserForeRoleAssignAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<List<AssignRoleDto>>>($"assignRoles/{id}");

        }
    }
}
