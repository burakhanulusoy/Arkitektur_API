using System.Text.Json.Serialization;

namespace Arkitektur.WebUI.DTOs.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string? NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string? Comment { get; set; }
        public string? Title { get; set; }
        [JsonIgnore]
        public IFormFile? file { get; set; }

    }
}
