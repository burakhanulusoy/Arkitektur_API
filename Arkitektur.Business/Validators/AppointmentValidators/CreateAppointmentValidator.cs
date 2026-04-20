using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Validators.AppointmentValidators
{
    public class CreateAppointmentValidator:AbstractValidator<CreateAppointmentDto>
    {
        public CreateAppointmentValidator()
        {
            
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boþ býrakýlamaz.");
            RuleFor(x => x.AppointmentDate).GreaterThan(DateTime.Now).WithMessage("Randevu tarihi geçmiþ olamaz.");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email boþ býrakýlamaz.").EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
            RuleFor(x=>x.PhoneNumber).NotEmpty().WithMessage("Telefon numarasý boþ býrakýlamaz.").Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Geçerli bir telefon numarasý giriniz.");
            RuleFor(x=>x.NameSurname).NotEmpty().WithMessage("Ad Soyad boþ býrakýlamaz.").MaximumLength(100).WithMessage("Ad Soyad en fazla 100 karakter olabilir.");
            RuleFor(x => x.ServiceName).NotEmpty().WithMessage("Hizmet adý boþ býrakýlamaz.");


        }



    }
}
