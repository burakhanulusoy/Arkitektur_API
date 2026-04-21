using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.Business.Services.GenericServices;

namespace Arkitektur.Business.Services.ProjectServices
{
    public interface IProjectService : IGenericService<ResultProjectDto,CreateProjectDto,UpdateProjectDto>
    {

        Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategoryAsync();



    }
}
