using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AboutDtos;

namespace Arkitektur.Business.Services.AboutServices
{
    public interface IAboutService
    {

        Task<BaseResult<List<ResultAboutDto>>> GetAllAboutAsync();
        Task<BaseResult<ResultAboutDto>> GetAboutByIdAsync(int id);
        Task<BaseResult<object>> CreateAboutAsync(CreateAboutDto createAboutDto);
        Task<BaseResult<object>> UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task<BaseResult<object>> DeleteAboutAsync(int id);


    }
}
