
using Arkitektur.Entity.Enums;

public record UpdateAppointmentDto(
        int Id,
        string? NameSurname,
        string? Email,
        string? PhoneNumber,
        string? ServiceName,
        DateTime AppointmentDate,
        string? Message,
        AppointmentStatus Status
    );

   

