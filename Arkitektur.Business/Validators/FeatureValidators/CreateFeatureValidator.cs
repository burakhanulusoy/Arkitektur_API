using Arkitektur.Business.DTOs.FeatureDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.FeatureValidators
{
    public class CreateFeatureValidator:AbstractValidator<CreateFeatureDto>
    {
        public CreateFeatureValidator()
        {
            RuleFor(x => x.Title)
               .NotEmpty().WithMessage("Baþlýk alaný boþ geçilemez.")
               .MaximumLength(100).WithMessage("Baþlýk alaný en fazla 100 karakter olmalýdýr.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açýklama alaný boþ geçilemez.")
                .MaximumLength(500).WithMessage("Açýklama alaný en fazla 500 karakter olmalýdýr.");

            RuleFor(x => x.BacgroundImage)
                .NotEmpty().WithMessage("Arka plan görseli boþ geçilemez.");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Ýkon alaný boþ geçilemez.");
        }
    }
}
