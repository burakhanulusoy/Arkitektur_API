using FluentValidation;

namespace Arkitektur.Business.Validators.AppointmentValidators
{
    public class UpdateAppointmentValidator:AbstractValidator<UpdateAppointmentDto>
    {
        public UpdateAppointmentValidator()
        {

            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boþ býrakýlamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boþ býrakýlamaz.").EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarasý boþ býrakýlamaz.");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad boþ býrakýlamaz.").MaximumLength(100).WithMessage("Ad Soyad en fazla 100 karakter olabilir.");
            RuleFor(x => x.ServiceName).NotEmpty().WithMessage("Hizmet adý boþ býrakýlamaz.");

        }
    }
}
