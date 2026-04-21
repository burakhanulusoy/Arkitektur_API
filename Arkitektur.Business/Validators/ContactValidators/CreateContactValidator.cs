using Arkitektur.Business.DTOs.ContactDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.ContactValidators
{
    public class CreateContactValidator:AbstractValidator<CreateContactDto>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.Address)
                 .NotEmpty().WithMessage("Adres alaný boþ geçilemez.")
                 .MinimumLength(10).WithMessage("Adres en az 10 karakter uzunluðunda olmalýdýr.")
                 .MaximumLength(500).WithMessage("Adres en fazla 500 karakter uzunluðunda olmalýdýr.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarasý boþ geçilemez.")
                .MinimumLength(10).WithMessage("Telefon numarasý en az 10 karakter olmalýdýr.")
                .MaximumLength(20).WithMessage("Telefon numarasý en fazla 20 karakter olmalýdýr.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta alaný boþ geçilemez.")
                .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi formatý giriniz.");

            RuleFor(x => x.MapUrl)
                .NotEmpty().WithMessage("Harita URL alaný boþ geçilemez.");


        }



    }
}
