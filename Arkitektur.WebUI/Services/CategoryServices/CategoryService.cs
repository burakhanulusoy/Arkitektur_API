using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.CategoryDtos;
using Arkitektur.WebUI.Exceptions;

namespace Arkitektur.WebUI.Services.CategoryServices
{

    //apiya httpclient ile istek atacağız
    public class CategoryService(HttpClient _client) : ICategoryService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateCategoryDto createCategoryDto)
        {
            //serialaze işlemi yapıyor ılk c# ı jsona ceviriyor ve api ye göneriyor
            var response =await _client.PostAsJsonAsync("categories", createCategoryDto); 

            //apiden gelen jsonu  deserialaze ile jsondan c# a donturup cevapı donduruyorsun
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsSuccessful ? result : throw new ApiValidationException(result.Errors); //turniri if sorgusu

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {

            var response = await _client.DeleteAsync("categories/" + id);

            await Task.Delay(2000);//2 saniye beklesin sweet alertimiz

            //deserialaze
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();

        }

        public async Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync()
        {
                                                  //bu tipte deserialaze et cunku veriler zaten json ıle gelıyor bıze   
            return await _client.GetFromJsonAsync<BaseResult<List<ResultCategoryDto>>>("categories");


        }

        public async Task<BaseResult<UpdateCategoryDto>> GetByIdAsync(int id)
        {
         
            return await _client.GetFromJsonAsync<BaseResult<UpdateCategoryDto>>("categories/"+id);

        }

        public async Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjectsAsync()
        {
           return await _client.GetFromJsonAsync<BaseResult<List<ResultCategoriesWithProjectsDto>>>("categories/WithProjects");
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
                                             
            var response = await _client.PutAsJsonAsync("categories", updateCategoryDto);    

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;

        }
    }
}
