using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.CategoryDtos;

namespace Arkitektur.WebUI.Services.CategoryServices
{
    public interface ICategoryService
    {

        Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync();
        Task<BaseResult<UpdateCategoryDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateCategoryDto createCategoryDto);
        Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto updateCategoryDto);
        Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjectsAsync();


    }
}
