using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TestimonailDtos;
using Arkitektur.DataAccess.Repositories.TestimonialRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Arkitektur.Business.Services.TestimonialServices
{
    public class TestimonialService(ITestimonialRepository _testimonialRepository
                                    ,IUnitOfWork _unitOfWork
                                    ,IValidator<CreateTestimonialDto> _createValidator
                                    ,IValidator<UpdateTestimonialDto> _updateValidator) : ITestimonialService
    {

        public async Task<BaseResult<object>> CreateAsync(CreateTestimonialDto createDto)
        {

            var item = createDto.Adapt<Testimonial>();

            var validationResult = await _createValidator.ValidateAsync(createDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _testimonialRepository.CreateAsync(item);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(item) : BaseResult<object>.Fail("Created Failed");

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var item = await _testimonialRepository.GetByIdAsync(id);

            if(item is null)
            {
                return BaseResult<object>.Fail("Testimonial Not Found");
            }
            _testimonialRepository.Delete(item);
            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(item) : BaseResult<object>.Fail("Deleted Failed");




        }

        public async Task<BaseResult<List<ResultTestimonialDto>>> GetAllAsync()
        {
            
            var items = await _testimonialRepository.GetAllAsync();

            var mappedItems = items.Adapt<List<ResultTestimonialDto>>();

            return  BaseResult<List<ResultTestimonialDto>>.Success(mappedItems);

        }

        public async Task<BaseResult<ResultTestimonialDto>> GetByIdAsync(int id)
        {

            var item = await _testimonialRepository.GetByIdAsync(id);

            if(item is null)
            {
                return BaseResult<ResultTestimonialDto>.Fail("Testimonial Not Found");
            }

            var mappedItem = item.Adapt<ResultTestimonialDto>();

            return BaseResult<ResultTestimonialDto>.Success(mappedItem);



        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateTestimonialDto updateDto)
        {
            var item = updateDto.Adapt<Testimonial>();

            var validationResult = await _updateValidator.ValidateAsync(updateDto);

            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

             _testimonialRepository.Update(item);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(item) : BaseResult<object>.Fail("Updated Failed");
        }
    }
}
