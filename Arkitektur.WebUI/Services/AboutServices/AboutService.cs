using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.AboutDtos;
using Arkitektur.WebUI.DTOs.ProjectDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.FileServices;

namespace Arkitektur.WebUI.Services.AboutServices
{
    public class AboutService(HttpClient _client,IFileService _fileService) : IAboutService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAboutDto createDto)
        {

            var imageResponse = await _fileService.UploadFileAsync(createDto.file);

            if(imageResponse.IsFailure)
            {
                throw new ApiValidationException(imageResponse.Errors);
            }


            createDto.ImageUrl = imageResponse.Data.ImageUrl;

            var response = await _client.PostAsJsonAsync("abouts", createDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;




        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {

            var about = await _client.GetFromJsonAsync<BaseResult<ResultProjectDto>>($"abouts/{id}");

            await _fileService.DeleteFileAsync(about.Data.ImageUrl);

            var response = await _client.DeleteAsync($"abouts/{id}");

            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();



        }

        public async Task<BaseResult<List<ResultAboutDto>>> GetAllAsync()
        {

            return await _client.GetFromJsonAsync<BaseResult<List<ResultAboutDto>>>("abouts");



        }

        public async Task<BaseResult<UpdateAboutDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateAboutDto>>($"abouts/{id}");

        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAboutDto updateDto)
        {
           
              if(updateDto.file is not null)
              {
                await _fileService.DeleteFileAsync(updateDto.ImageUrl);

                var imageResponse = await _fileService.UploadFileAsync(updateDto.file);

                updateDto.ImageUrl = imageResponse.Data.ImageUrl;

              }

            var response = await _client.PutAsJsonAsync("abouts", updateDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;




        }
    }
}
