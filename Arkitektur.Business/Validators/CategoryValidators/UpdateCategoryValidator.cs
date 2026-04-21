using Arkitektur.Business.DTOs.CategoryDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.CategoryValidators
{
    public class UpdateCategoryValidator:AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adý boþ olamaz")
                                      .MaximumLength(60).WithMessage("Kategori adý 60 karakterden fazla olamaz")
                                      .MinimumLength(3).WithMessage("Kategori adý 3 karakterden az olamaz");
                                      




        }




    }
}
