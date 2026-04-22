using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.CategoryDtos;

namespace Arkitektur.WebUI.Services.CategoryServices
{

    //apiya httpclient ile istek atacağız
    public class CategoryService(HttpClient _client) : ICategoryService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateCategoryDto createCategoryDto)
        {
            //serialazeişlemi yapıyor ılk c# ı jsona ceviriyor ve api ye göneriyor
            var response =await _client.PostAsJsonAsync("categories", createCategoryDto); 

            //apiden gelen jsonu  deserialaze ile jsondan c# a donturup cevapı donduruyorsun
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
                       
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {

            var response = await _client.DeleteAsync("categories/" + id);
            await Task.Delay(2000);//2 samiye

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

        public async Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
                                             
            var response = await _client.PutAsJsonAsync("categories", updateCategoryDto);    

            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }
    }
}
