using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.BannerDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.FileServices;

namespace Arkitektur.WebUI.Services.BannerServices
{
    public class BannerService(HttpClient _client,IFileService _fileService) : IBannerService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateBannerDto createDto)
        {

            var imageResponse = await _fileService.UploadFileAsync(createDto.file);

            if(imageResponse.IsFailure)
            {
                throw new ApiValidationException(imageResponse.Errors);
            }

            createDto.ImageUrl = imageResponse.Data.ImageUrl;

            var response = await _client.PostAsJsonAsync("banners", createDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;





        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {

            var banner = await _client.GetFromJsonAsync<BaseResult<ResultBannerDto>>($"banners/{id}");

            await _fileService.DeleteFileAsync(banner.Data.ImageUrl);

            var response = await _client.DeleteAsync($"banners/{id}");

            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();





        }

        public async Task<BaseResult<List<ResultBannerDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultBannerDto>>>("banners");
        }

        public async Task<BaseResult<UpdateBannerDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateBannerDto>>($"banners/{id}");

        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateBannerDto updateDto)
        {
          
            if(updateDto.file is not null)
            {
                await _fileService.DeleteFileAsync(updateDto.ImageUrl);

                var imageResponse = await _fileService.UploadFileAsync(updateDto.file);

                updateDto.ImageUrl = imageResponse.Data.ImageUrl;
            }

            var response = await _client.PutAsJsonAsync("banners", updateDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;

        }










    }
}
