using System.Text.Json.Serialization;

namespace Arkitektur.WebUI.DTOs.AboutDtos
{
    public class UpdateAboutDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? StartYear { get; set; }
        public string? ImageUrl { get; set; }
        [JsonIgnore]

        public IFormFile? file { get; set; }

    }
}
