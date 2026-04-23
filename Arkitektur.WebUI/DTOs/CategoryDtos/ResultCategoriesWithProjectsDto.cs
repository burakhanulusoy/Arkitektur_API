using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.ProjectDtos;

namespace Arkitektur.WebUI.DTOs.CategoryDtos
{
    public class ResultCategoriesWithProjectsDto:BaseDto
    {
        public string CategoryName { get; set; }

        public IList<ProjectDto> Projects { get; set; }

    }
}
