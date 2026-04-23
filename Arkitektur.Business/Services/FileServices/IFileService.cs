using Arkitektur.Business.Base;
using Microsoft.AspNetCore.Http;

namespace Arkitektur.Business.Services.FileServices
{
    public interface IFileService
    {
        Task<BaseResult<object>> UploadImageToS3Async(IFormFile? file); // RESİM BOŞ TA GONDERELEBİİİR ONUN İÇİN NULLABLE YAPILDI

        Task<BaseResult<object>> DeleteFileAsync(string imageUrl);

    }
}
