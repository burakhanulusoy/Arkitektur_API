using Arkitektur.Business.DTOs.TeamDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.TeamValidators
{
    public class CreateeamValidator:AbstractValidator<CreateTeamDto>
    {
        public CreateeamValidator()
        {

            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad soyad alaný boþ geçilemez.")
                .MinimumLength(3).WithMessage("Ad soyad alaný en az 3 karakter olmalýdýr.")
                .MaximumLength(60).WithMessage("Ad soyad alaný en fazla 60 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel yolu boþ geçilemez.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Unvan alaný boþ geçilemez.")
                .MinimumLength(2).WithMessage("Unvan alaný en az 2 karakter olmalýdýr.")
                .MaximumLength(50).WithMessage("Unvan alaný en fazla 50 karakter olabilir.");
        }
    }
}
