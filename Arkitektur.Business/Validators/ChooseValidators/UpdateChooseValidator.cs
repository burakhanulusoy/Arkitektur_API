using Arkitektur.Business.DTOs.ChooseDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.ChooseValidators
{
    
        public class UpdateChooseValidator : AbstractValidator<UpdateChooseDto>
        {
            public UpdateChooseValidator()
            {
                

                RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Baþlýk alaný boþ geçilemez.")
                    .MinimumLength(3).WithMessage("Baþlýk en az 3 karakter uzunluðunda olmalýdýr.")
                    .MaximumLength(100).WithMessage("Baþlýk en fazla 100 karakter uzunluðunda olmalýdýr.");

                RuleFor(x => x.Description)
                    .NotEmpty().WithMessage("Açýklama alaný boþ geçilemez.")
                    .MinimumLength(10).WithMessage("Açýklama en az 10 karakter uzunluðunda olmalýdýr.")
                    .MaximumLength(500).WithMessage("Açýklama en fazla 500 karakter uzunluðunda olmalýdýr.");

                RuleFor(x => x.Icon)
                    .NotEmpty().WithMessage("Ýkon alaný boþ geçilemez.");
            }
        }
    }


