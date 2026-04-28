using Arkitektur.Business.Base;

namespace Arkitektur.Business.DTOs.TestimonailDtos
{
    public class ResultTestimonialDto:BaseDto
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
        public string Title { get; set; }


    }
}
