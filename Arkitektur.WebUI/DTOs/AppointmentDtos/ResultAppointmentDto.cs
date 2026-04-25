using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.Enums;

namespace Arkitektur.WebUI.DTOs.AppointmentDtos
{
    public class ResultAppointmentDto : BaseDto
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ServiceName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Message { get; set; }
        public AppointmentStatus Status { get; set; }


    }
}
