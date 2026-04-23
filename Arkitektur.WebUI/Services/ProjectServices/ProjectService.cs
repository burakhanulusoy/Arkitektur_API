using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ProjectDtos;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.FileServices;

namespace Arkitektur.WebUI.Services.ProjectServices
{
    public class ProjectService(HttpClient _httpClient,IFileService _fileService) : IProjectService
    {
        public async Task<BaseResult<object>> CreateProjectAsync(CreateProjectDto createProcejtDto)
        {


            //AMAZON SE BUCKET AYARI RESIM YUKLEMEDE ******************************************************************
            var imageResponse = await _fileService.UploadFileAsync(createProcejtDto.file);
            createProcejtDto.ImageUrl = imageResponse.Data.ImageUrl;

            //serialize yaptık c# ı json yaptık yani
            var response = await _httpClient.PostAsJsonAsync("projects", createProcejtDto);

            //deserialze yaptık
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;

        }

        public async Task<BaseResult<object>> DeleteProjectAsync(int id)
        {

            //Eğer proje silinirse resimi de silinsin 
            var project = await _httpClient.GetFromJsonAsync<BaseResult<ResultProjectDto>>($"projects/{id}");
            await _fileService.DeleteFileAsync(project.Data.ImageUrl);

            var response = await _httpClient.DeleteAsync($"projects/{id}");

            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetAllProjectsWithCategoryAsync()
        {
            //deseriazle json -> c#
            return await _httpClient.GetFromJsonAsync<BaseResult<List<ResultProjectDto>>>("projects/WithCategories");

        }

        public async Task<BaseResult<UpdateProjectDto>> GetByIdProjectAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<BaseResult<UpdateProjectDto>>($"projects/{id}");
            
        }

        public async Task<BaseResult<object>> UpdateProjectAsync(UpdateProjectDto updateProcejtDto)
        {
            if(updateProcejtDto.file is not null) //çünkü belki resimi aynı kalmasını ısteyecek
            {
                await _fileService.DeleteFileAsync(updateProcejtDto.ImageUrl);//yeni resim gelirse eski resimi silcez oke


                //AMAZON SE BUCKET AYARI RESIM YUKLEMEDE ******************************************************************
                var imageResponse = await _fileService.UploadFileAsync(updateProcejtDto.file);
                updateProcejtDto.ImageUrl = imageResponse.Data.ImageUrl;


            }

           

            var response = await _httpClient.PutAsJsonAsync("projects", updateProcejtDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;


        }
    }
}
