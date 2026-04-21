using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.BannerDtos;
using Arkitektur.DataAccess.Repositories.BannerRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.BannerServices
{
    public class BannerService(IUnitOfWork _unitOfWork
                              ,IBannerRepository _bannerRepository
                              ,IValidator<CreateBannerDto> _createValidator
                              ,IValidator<UpdateBannerDto> _updateValidator) : IBannerService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateBannerDto createDto)
        {

            var banner = createDto.Adapt<Banner>();

            var validationResult = await _createValidator.ValidateAsync(createDto);

            if(!validationResult.IsValid)//fast fail yöntemi
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _bannerRepository.CreateAsync(banner);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(banner) : BaseResult<object>.Fail("Created Failed.");





        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
           
            var banner = await _bannerRepository.GetByIdAsync(id);

            if(banner is null)
            {
                return BaseResult<object>.Fail("Banner not found.");
            }

            _bannerRepository.Delete(banner);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Deleted Failed.");


        }

        public async Task<BaseResult<List<ResultBannerDto>>> GetAllAsync()
        {
           
            var banners = await _bannerRepository.GetAllAsync();

            var mappedBanners = banners.Adapt<List<ResultBannerDto>>();

            return BaseResult<List<ResultBannerDto>>.Success(mappedBanners);


        }

        public async Task<BaseResult<ResultBannerDto>> GetByIdAsync(int id)
        {
            var banner = await _bannerRepository.GetByIdAsync(id);

            if(banner is null)
            {
                return BaseResult<ResultBannerDto>.Fail("Banner not found.");
            }

            var mappedBanner = banner.Adapt<ResultBannerDto>();

            return BaseResult<ResultBannerDto>.Success(mappedBanner);


        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateBannerDto updateDto)
        {
            
            var banner = updateDto.Adapt<Banner>();

            var validationResult = await _updateValidator.ValidateAsync(updateDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            _bannerRepository.Update(banner);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Updated Failed.");

        }





    }
}
