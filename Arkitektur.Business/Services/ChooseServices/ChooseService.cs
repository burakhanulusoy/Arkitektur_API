using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ChooseDtos;
using Arkitektur.DataAccess.Repositories.ChooseRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.ChooseServices
{
    public class ChooseService(IChooseRepository _chooseRepository
                             ,IUnitOfWork _unitOfWork
                             ,IValidator<UpdateChooseDto> _updateValidator
                             ,IValidator<CreateChooseDto> _createValidator ) : IChooseService
    {

        public async Task<BaseResult<object>> CreateAsync(CreateChooseDto createDto)
        {

            var choose = createDto.Adapt<Choose>();

            var validationResult = await _createValidator.ValidateAsync(createDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _chooseRepository.CreateAsync(choose);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(choose) : BaseResult<object>.Fail("Created Failed");




        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var choose = await _chooseRepository.GetByIdAsync(id);

            if(choose is null)
            {
                return BaseResult<object>.Fail("Choose Not Found");
            }

            _chooseRepository.Delete(choose);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Deleted Failed"); 

        }

        public async Task<BaseResult<List<ResultChooseDto>>> GetAllAsync()
        {

            var choosses = await _chooseRepository.GetAllAsync();

            var mappedChoosses = choosses.Adapt<List<ResultChooseDto>>();

            return BaseResult<List<ResultChooseDto>>.Success(mappedChoosses);



        }

        public async Task<BaseResult<ResultChooseDto>> GetByIdAsync(int id)
        {

            var choose = await _chooseRepository.GetByIdAsync(id);

            if(choose is null)
            {
                return BaseResult<ResultChooseDto>.Fail("Choose Not Found");
            }

            var mappedChoose = choose.Adapt<ResultChooseDto>();

            return BaseResult<ResultChooseDto>.Success(mappedChoose);




        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateChooseDto updateDto)
        {
            var choose = updateDto.Adapt<Choose>();

            var validationResult = await _updateValidator.ValidateAsync(updateDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            _chooseRepository.Update(choose);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Updated Failed");






        }
    }
}
