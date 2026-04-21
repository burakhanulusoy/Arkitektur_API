using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ProjectDtos;

namespace Arkitektur.Business.DTOs.CategoryDtos
{
    public class ResultCategoriesWithProjectsDto:BaseDto
    {
        public string CategoryName { get; set; }

        public IList<ProjectDto> Projects { get; set; }

    }
}
