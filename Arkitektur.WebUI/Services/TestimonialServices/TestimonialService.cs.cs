using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.AppointmentDtos;
using Arkitektur.WebUI.DTOs.TestimonialDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.FileServices;
using System.Net.Http;

namespace Arkitektur.WebUI.Services.TestimonialServices
{
    public class TestimonialService(HttpClient _httpClient,IFileService _fileService) : ITestimonialService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateTestimonialDto createDto)
        {

            var imageResponse = await _fileService.UploadFileAsync(createDto.file);

            if (imageResponse.IsFailure)
            {
                throw new ApiValidationException(imageResponse.Errors);
            }

            createDto.ImageUrl = imageResponse.Data.ImageUrl;

            var response = await _httpClient.PostAsJsonAsync("testimonials", createDto);

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
            var item = await _httpClient.GetFromJsonAsync<BaseResult<ResultTestimonialDto>>($"testimonials/{id}");

            await _fileService.DeleteFileAsync(item.Data.ImageUrl);

            var response = await _httpClient.DeleteAsync($"testimonials/{id}");

            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();


        }

        public async Task<BaseResult<List<ResultTestimonialDto>>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<BaseResult<List<ResultTestimonialDto>>>("testimonials");

        }

        public async Task<BaseResult<UpdateTestimonialDto>> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<BaseResult<UpdateTestimonialDto>>($"testimonials/{id}");

        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateTestimonialDto updateDto)
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

            var response = await _httpClient.PutAsJsonAsync("testimonials/", updateDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result.IsFailure)
            {
                throw new ApiValidationException(result.Errors);
            }

            return result;

        }
    }
}
