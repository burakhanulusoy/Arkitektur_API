using Arkitektur.Entity.Enums;


    public record CreateAppointmentDto(
        string NameSurname,
        string Email,
        string PhoneNumber,
        string ServiceName,
        DateTime AppointmentDate,
        string Message,
        AppointmentStatus Status=AppointmentStatus.Pending);


  
