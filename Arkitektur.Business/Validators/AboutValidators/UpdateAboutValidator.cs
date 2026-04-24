using Arkitektur.Business.DTOs.AboutDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.AboutValidators
{
    public class UpdateAboutValidator:AbstractValidator<UpdateAboutDto>
    {
        public UpdateAboutValidator()
        {

            RuleFor(x => x.Title).NotEmpty().WithMessage("bos býrkalma");
            RuleFor(x => x.Description).NotEmpty().WithMessage("bos býrkalma");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("bos býrkalma");

        }
    }
}
