using Arkitektur.Business.Services.FileServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController(IFileService _fileService) : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> FileUpload(IFormFile? file)
        {

            var response = await _fileService.UploadImageToS3Async(file);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);



        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFile([FromQuery]string imageUrl)
        {

            var response = await _fileService.DeleteFileAsync(imageUrl);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);


        }



    }
}
