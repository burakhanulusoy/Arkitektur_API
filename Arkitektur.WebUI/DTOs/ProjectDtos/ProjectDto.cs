using Arkitektur.WebUI.Base;

namespace Arkitektur.WebUI.DTOs.ProjectDtos
{
    public class ProjectDto:BaseDto
    {
        // Bu Şey categorılere gore proje hgetırmek ıcın

        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public int CategoryId { get; set; }
    }
}
