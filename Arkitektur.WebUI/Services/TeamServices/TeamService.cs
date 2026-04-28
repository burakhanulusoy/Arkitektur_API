using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.TeamDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.FileServices;

namespace Arkitektur.WebUI.Services.TeamServices
{
    public class TeamService(HttpClient _httpClient,IFileService _fileService) : ITeamService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateTeamDto createDto)
        {
            var imageResponse = await _fileService.UploadFileAsync(createDto.file);

            if (imageResponse.IsFailure)
            {
                throw new ApiValidationException(imageResponse.Errors);
            }

            createDto.ImageUrl = imageResponse.Data.ImageUrl;

            var response = await _httpClient.PostAsJsonAsync("teams", createDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result.IsFailure)
            {
                await _fileService.DeleteFileAsync(imageResponse.Data.ImageUrl);
                throw new ApiValidationException(result.Errors);
            }


            return result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var feature = await _httpClient.GetFromJsonAsync<BaseResult<ResultTeamDto>>($"teams/{id}");

            await _fileService.DeleteFileAsync(feature.Data.ImageUrl);

            var response = await _httpClient.DeleteAsync($"teams/{id}");

            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();

        }

        public async Task<BaseResult<List<ResultTeamDto>>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<BaseResult<List<ResultTeamDto>>>("teams");

        }

        public async Task<BaseResult<UpdateTeamDto>> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<BaseResult<UpdateTeamDto>>("teams/" + id);

        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateTeamDto updateDto)
        {
            if (updateDto.file is not null)
            {
                var imageResponse = await _fileService.UploadFileAsync(updateDto.file);

                if (imageResponse.IsFailure)
                {
                    throw new ApiValidationException(imageResponse.Errors);
                }

                await _fileService.DeleteFileAsync(updateDto.ImageUrl);

                updateDto.ImageUrl = imageResponse.Data.ImageUrl;
            }

            var response = await _httpClient.PutAsJsonAsync("teams/", updateDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result.IsFailure)
            {
                throw new ApiValidationException(result.Errors);
            }

            return result;
        }
    }
}
