using Arkitektur.Business.DTOs.AboutDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.AboutValidators
{
    public class CreateAboutValidator : AbstractValidator<CreateAboutDto>
    {
        public CreateAboutValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Baþlýk alaný boþ býrakýlamaz.")
                .MaximumLength(100).WithMessage("Baþlýk alaný en fazla 100 karakter olmalýdýr.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açýklama alaný boþ býrakýlamaz.")
                .MinimumLength(10).WithMessage("Açýklama alaný detaylý ve en az 10 karakter olmalýdýr.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL alaný boþ býrakýlamaz.");

            RuleFor(x => x.StartYear)
                .NotEmpty().WithMessage("Baþlangýç yýlý alaný boþ býrakýlamaz.")
                .GreaterThan(1800).WithMessage("Lütfen geçerli bir baþlangýç yýlý giriniz.")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Baþlangýç yýlý içinde bulunduðumuz yýldan büyük olamaz.");
        }
    }
}