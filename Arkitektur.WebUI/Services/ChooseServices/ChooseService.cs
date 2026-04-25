using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ChooseDtos;
using Arkitektur.WebUI.Exceptions;

namespace Arkitektur.WebUI.Services.ChooseServices
{
    public class ChooseService(HttpClient _client) : IChooseService
    {

        public async Task<BaseResult<object>> CreateAsync(CreateChooseDto createDto)
        {

            var response = await _client.PostAsJsonAsync("Choosses", createDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {

            var response = await _client.DeleteAsync($"Choosses/{id}");

            return await response.Content.ReadFromJsonAsync<BaseResult<object>>(); 


        }

        public async Task<BaseResult<List<ResultChooseDto>>> GetAllAsync()
        {

            return await _client.GetFromJsonAsync<BaseResult<List<ResultChooseDto>>>("Choosses");

        }

        public async Task<BaseResult<UpdateChooseDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateChooseDto>>($"Choosses/{id}");
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateChooseDto updateDto)
        {

            var response = await _client.PutAsJsonAsync("Choosses", updateDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;


        }
    }
}
