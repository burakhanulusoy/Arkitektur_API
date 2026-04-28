using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.AppointmentDtos;
using Arkitektur.WebUI.DTOs.TeamSocialDtos;
using Arkitektur.WebUI.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Arkitektur.WebUI.Services.TeamSocialServices
{
    public class TeamSocialService(HttpClient _httpClient) : ITeamSocialService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateTeamSocialDto createDto)
        {
            var response = await _httpClient.PostAsJsonAsync("teamSocials", createDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;


        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {

            var response = await _httpClient.DeleteAsync($"teamSocials/{id}");

            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();


        }

        public async Task<BaseResult<List<ResultTeamSocialDto>>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<BaseResult<List<ResultTeamSocialDto>>>("teamSocials");

        }

        public async Task<BaseResult<UpdateTeamSocialDto>> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<BaseResult<UpdateTeamSocialDto>>($"teamSocials/{id}");

        }

        public async Task<BaseResult<List<GetTeamSocialWithTeamMemberDto>>> GetTeamSocialWithTeamMemberListAsync()
        {
            return await _httpClient.GetFromJsonAsync<BaseResult<List<GetTeamSocialWithTeamMemberDto>>>("teamSocials/withTeamMember");

        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateTeamSocialDto updateDto)
        {
            var response = await _httpClient.PutAsJsonAsync("teamSocials", updateDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;

        }
    }
}
