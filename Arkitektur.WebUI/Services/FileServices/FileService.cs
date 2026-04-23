using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.FileDtos;
using Arkitektur.WebUI.Exceptions;
using System.Net.Http.Headers;

namespace Arkitektur.WebUI.Services.FileServices
{
    public class FileService(HttpClient _client) : IFileService
    {
        public async Task<BaseResult<ResultFileDto>> UploadFileAsync(IFormFile file)
        {
            if(file is null || file.Length<=0)
            {
                throw new ApiValidationException([new Error { PropertyName="File" , ErrorMessage="Lütfen bir dosya seçiniz."}]);
            }

            //kargo kutusu hazırlmaa
            var form = new MultipartFormDataContent();
           
            //gelen dosyayı okur
            var streamContent = new StreamContent(file.OpenReadStream());
            //img mı pdf mi neyse omu belirler
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            //dosyayı kutuya koy
            form.Add(streamContent, "file", file.FileName);

            var response = await _client.PostAsync("files/upload", form);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApiValidationException([new Error { PropertyName = "File", ErrorMessage = "Dosya yüklenirken hata oluştu." }]);
            }

            return await response.Content.ReadFromJsonAsync<BaseResult<ResultFileDto>>();




        }
    }
}
