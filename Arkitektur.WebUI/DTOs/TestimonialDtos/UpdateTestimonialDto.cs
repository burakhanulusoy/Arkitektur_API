namespace Arkitektur.WebUI.DTOs.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public int Id { get; set; }
        public string? NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string? Comment { get; set; }
        public string? Title { get; set; }
        public IFormFile? file { get; set; }

    }
}
