using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.CategoryDtos;
using Arkitektur.DataAccess.Repositories.CategoryRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.CategoryServices
{
    public class CategoryService(ICategoryRepository _categoryRepository
                                 ,IUnitOfWork _unitOfWork
                                 ,IValidator<CreateCategoryDto> _createValidator
                                 ,IValidator<UpdateCategoryDto> _updateValidator) : ICategoryService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateCategoryDto createDto)
        {

            var category = createDto.Adapt<Category>();

            var validationResult = await _createValidator.ValidateAsync(createDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _categoryRepository.CreateAsync(category);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(category) : BaseResult<object>.Fail("Created Failed");

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var category= await _categoryRepository.GetByIdAsync(id);

            if(category is null)
            {
                return BaseResult<object>.Fail("Category Not Found");
            }

            _categoryRepository.Delete(category);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Deleted Failed");


        }

        public async Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var mappedCategories = categories.Adapt<List<ResultCategoryDto>>();

            return BaseResult<List<ResultCategoryDto>>.Success(mappedCategories);


        }

        public async Task<BaseResult<ResultCategoryDto>> GetByIdAsync(int id)
        {
            
            var category = await _categoryRepository.GetByIdAsync(id);

            if(category is null)
            {
                return BaseResult<ResultCategoryDto>.Fail("Category Not Found");
            }

            var mappedCategory = category.Adapt<ResultCategoryDto>();

            return BaseResult<ResultCategoryDto>.Success(mappedCategory);



        }

        public async Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjectsAsync()
        {
            var queryable =await _categoryRepository.GetQueryable().Include(x => x.Projects).ToListAsync();

            var mappedCategories = queryable.Adapt<List<ResultCategoriesWithProjectsDto>>();

            return BaseResult<List<ResultCategoriesWithProjectsDto>>.Success(mappedCategories);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto updateDto)
        {
           
            var category = updateDto.Adapt<Category>();

            var validationResult = await _updateValidator.ValidateAsync(updateDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            _categoryRepository.Update(category);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(category) : BaseResult<object>.Fail("Updated Failed");



        }



    }
}
