using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.FileDtos;

namespace Arkitektur.WebUI.Services.FileServices
{
    public interface IFileService
    {

        Task<BaseResult<ResultFileDto>> UploadFileAsync(IFormFile file); 



    }

}
