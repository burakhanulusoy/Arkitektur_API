using Arkitektur.Business.DTOs.TeamSocialDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.TeamSocialValidators
{
    public class CreateTeamSocialValidator:AbstractValidator<CreateTeamSocialDto>
    {
        public CreateTeamSocialValidator()
        {
            RuleFor(x => x.Title)
              .NotEmpty().WithMessage("Sosyal medya platform adý boþ geçilemez.")
              .MinimumLength(2).WithMessage("Platform adý en az 2 karakter olmalýdýr.")
              .MaximumLength(50).WithMessage("Platform adý en fazla 50 karakter olabilir.");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Ýkon alaný boþ geçilemez.")
                .MaximumLength(100).WithMessage("Ýkon bilgisi en fazla 100 karakter olabilir.");

            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("URL adresi boþ geçilemez.")
                .MaximumLength(250).WithMessage("URL adresi en fazla 250 karakter olabilir.");
        }
    }
}
