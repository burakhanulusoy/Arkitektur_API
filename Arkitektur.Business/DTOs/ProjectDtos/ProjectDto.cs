using Arkitektur.Business.Base;

namespace Arkitektur.Business.DTOs.ProjectDtos
{
    public class ProjectDto:BaseDto
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public int CategoryId { get; set; }
    }
}
