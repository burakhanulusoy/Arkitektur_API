using Arkitektur.Business.DTOs.TeamSocialDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.TeamSocialValidators
{
    public class UpdateTeamSocialValidator : AbstractValidator<UpdateTeamSocialDto>
    {
        public UpdateTeamSocialValidator()
        {

            RuleFor(x => x.Title)
               .NotEmpty().WithMessage("Sosyal medya platform adý boþ geçilemez.")
               .MinimumLength(2).WithMessage("Platform adý en az 2 karakter olmalýdýr.")
               .MaximumLength(50).WithMessage("Platform adý en fazla 50 karakter olabilir.");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Ýkon alaný boþ geçilemez.");

            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("URL adresi boþ geçilemez.");
        }

    }
}
