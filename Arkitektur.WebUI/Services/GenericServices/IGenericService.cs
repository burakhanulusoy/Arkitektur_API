using Arkitektur.WebUI.Base;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Arkitektur.WebUI.Services.GenericServices
{
    public interface IGenericService<TResultDto,TCreateDto,TUpdateDto> where TResultDto : class
                                                                       where TCreateDto : class
                                                                       where TUpdateDto : class
        
    {

        Task<BaseResult<List<TResultDto>>> GetAllAsync();
        Task<BaseResult<TUpdateDto>> GetByIdAsync(int id);

        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> CreateAsync(TCreateDto createDto);
        Task<BaseResult<object>> UpdateAsync(TUpdateDto updateDto);




    }
}
