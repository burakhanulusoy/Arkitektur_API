using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ProjectDtos;

namespace Arkitektur.WebUI.Services.ProjectServices
{
    public interface IProjectService
    {

        Task<BaseResult<List<ResultProjectDto>>> GetAllProjectsWithCategoryAsync();
        Task<BaseResult<UpdateProjectDto>> GetByIdProjectAsync(int id);
        Task<BaseResult<object>> CreateProjectAsync(CreateProjectDto createProcejtDto);
        Task<BaseResult<object>> UpdateProjectAsync(UpdateProjectDto updateProcejtDto);
        Task<BaseResult<object>> DeleteProjectAsync(int id);

    }
}
