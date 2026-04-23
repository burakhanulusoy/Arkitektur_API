using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ProjectDtos;
using Arkitektur.WebUI.Exceptions;

namespace Arkitektur.WebUI.Services.ProjectServices
{
    public class ProjectService(HttpClient _httpClient) : IProjectService
    {
        public async Task<BaseResult<object>> CreateProjectAsync(CreateProjectDto createProcejtDto)
        {

            //serialize yaptık c# ı json yaptık yani
            var response = await _httpClient.PostAsJsonAsync("projects", createProcejtDto);

            //deserialze yaptık
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;

        }

        public async Task<BaseResult<object>> DeleteProjectAsync(int id)
        {

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

            var response = await _httpClient.PutAsJsonAsync("projects", updateProcejtDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;


        }
    }
}
