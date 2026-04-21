using Arkitektur.Business.DTOs.ProjectDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.ProjectValidators
{
    public class CreateProjectValidator:AbstractValidator<CreateProjectDto>
    {
        public CreateProjectValidator()
        {

            RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("Proje baþlýðý boþ býrakýlamaz.")
                 .MinimumLength(3).WithMessage("Proje baþlýðý en az 3 karakter olmalýdýr.")
                 .MaximumLength(100).WithMessage("Proje baþlýðý en fazla 100 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel yolu (URL) boþ býrakýlamaz.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Proje açýklamasý boþ býrakýlamaz.")
                .MinimumLength(10).WithMessage("Proje açýklamasý en az 10 karakter olmalýdýr.")
                .MaximumLength(1000).WithMessage("Proje açýklamasý en fazla 1000 karakter olabilir.");

            RuleFor(x => x.Item1)
                .NotEmpty().WithMessage("1. madde boþ býrakýlamaz.")
                .MaximumLength(100).WithMessage("1. madde en fazla 100 karakter olabilir.");

            RuleFor(x => x.Item2)
                .NotEmpty().WithMessage("2. madde boþ býrakýlamaz.")
                .MaximumLength(100).WithMessage("2. madde en fazla 100 karakter olabilir.");

            RuleFor(x => x.Item3)
                .NotEmpty().WithMessage("3. madde  boþ býrakýlamaz.")
                .MaximumLength(100).WithMessage("3. madde en fazla 100 karakter olabilir.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Kategori seçimi zorunludur.")
                .GreaterThan(0).WithMessage("Lütfen geçerli bir kategori seçiniz.");


        }




    }
}
