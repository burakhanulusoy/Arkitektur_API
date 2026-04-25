using Arkitektur.WebUI.Base;

namespace Arkitektur.WebUI.DTOs.ContactDtos
{
    public class ResultContactDto:BaseDto
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MapUrl { get; set; }
    }
}
