using Arkitektur.Business.DTOs.UserIdentityDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.UserValidators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            // FirstName (Ad) Doðrulamasý
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad alaný boþ geçilemez.")
                .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalýdýr.")
                .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olmalýdýr.");

            // LastName (Soyad) Doðrulamasý
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad alaný boþ geçilemez.")
                .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalýdýr.")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olmalýdýr.");

            // UserName (Kullanýcý Adý) Doðrulamasý
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanýcý adý boþ geçilemez.")
                .MinimumLength(3).WithMessage("Kullanýcý adý en az 3 karakter olmalýdýr.")
                .MaximumLength(50).WithMessage("Kullanýcý adý en fazla 50 karakter olmalýdýr.");

            // Email (E-posta) Doðrulamasý
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta alaný boþ geçilemez.")
                .EmailAddress().WithMessage("Lütfen geçerli bir e-posta formatý giriniz.");

            // PhoneNumber (Telefon) Doðrulamasý
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarasý boþ geçilemez.")
                .MaximumLength(20).WithMessage("Telefon numarasý en fazla 20 karakter olmalýdýr.");

            // Password (Þifre) Doðrulamasý
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Þifre boþ geçilemez.")
                .MinimumLength(6).WithMessage("Þifre en az 6 karakter olmalýdýr."); // Identity default ayarlarýna göre 6 veya 8 yapabilirsiniz

            // ConfirmPassword (Þifre Tekrar) Doðrulamasý ve Eþleþme Kontrolü
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Þifre tekrar alaný boþ geçilemez.")
                .Equal(x => x.Password).WithMessage("Girdiðiniz þifreler birbiriyle uyuþmuyor.");
        }
    }
}