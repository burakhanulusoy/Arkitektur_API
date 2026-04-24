using Arkitektur.WebUI.Base;

namespace Arkitektur.WebUI.DTOs.AboutDtos
{
    public class ResultAboutDto:BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StartYear { get; set; }
        public string ImageUrl { get; set; }

    }
}
