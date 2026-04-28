using Arkitektur.Business.DTOs.TestimonailDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.TestimonialValidators
{
    public class UpdateTestimonailValidator:AbstractValidator<UpdateTestimonialDto>
    {
        public UpdateTestimonailValidator()
        {
            RuleFor(x => x.NameSurname)
               .NotEmpty().WithMessage("Ad Soyad alaný boþ býrakýlamaz.")
               .MinimumLength(3).WithMessage("Ad Soyad en az 3 karakter olmalýdýr.")
               .MaximumLength(100).WithMessage("Ad Soyad en fazla 100 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel yüklenmesi zorunludur.");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum alaný boþ býrakýlamaz.")
                .MinimumLength(10).WithMessage("Yorumunuz çok kýsa, lütfen en az 10 karakter giriniz.")
                .MaximumLength(500).WithMessage("Yorum en fazla 500 karakter olabilir.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Ünvan alaný boþ býrakýlamaz.")
                .MaximumLength(50).WithMessage("Ünvan en fazla 50 karakter olabilir.");
        }
    }
}
