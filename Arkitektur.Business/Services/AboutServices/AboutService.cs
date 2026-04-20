using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;
using Arkitektur.DataAccess.Repositories.GenericRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using Mapster;

namespace Arkitektur.Business.Services.AboutServices
{
    public class AboutService(IGenericRepository<About> _aboutRepository, IUnitOfWork _unitOfWork) : IAboutService
    {
        public async Task<BaseResult<object>> CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var about = createAboutDto.Adapt<About>();

            await _aboutRepository.CreateAsync(about);

            var result= await _unitOfWork.SaveChangesAsync();

            return result ?  BaseResult<object>.Success(about) : BaseResult<object>.Fail("Create failed.");

        }

        public async Task<BaseResult<object>> DeleteAboutAsync(int id)
        {
            var about = await _aboutRepository.GetByIdAsync(id);

            if(about is null)
            {
                return BaseResult<object>.Fail("About not found.");
            }

            _aboutRepository.Delete(about);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete failed.");




        }

        public async Task<BaseResult<ResultAboutDto>> GetAboutByIdAsync(int id)
        {
            var about = await _aboutRepository.GetByIdAsync(id);

            if(about is null)
            {
                return BaseResult<ResultAboutDto>.Fail("About not found.");
            }


            var mappedAbout = about.Adapt<ResultAboutDto>();

            return BaseResult<ResultAboutDto>.Success(mappedAbout);



        }

        public async Task<BaseResult<List<ResultAboutDto>>> GetAllAboutAsync()
        {
            
            var abouts = await _aboutRepository.GetAllAsync();

            var mappedAbouts = abouts.Adapt<List<ResultAboutDto>>();

            return BaseResult<List<ResultAboutDto>>.Success(mappedAbouts);


        }

        public async Task<BaseResult<object>> UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            
            var about = updateAboutDto.Adapt<About>();

            _aboutRepository.Update(about);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update failed.");




        }
    }
}
