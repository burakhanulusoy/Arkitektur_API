using Arkitektur.Business.DTOs.RoleIdentityDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.RoleValidators
{
    public class CreateRoleValidator:AbstractValidator<CreateRoleDto>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Boþ Býraklýamaz");
        }


    }
}
