using Arkitektur.Business.DTOs.BannerDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.BannerValidators
{
    public class UpdateBannerValidator:AbstractValidator<UpdateBannerDto>
    {

        public UpdateBannerValidator()
        {

            RuleFor(x => x.Title).NotEmpty().WithMessage("Baþlýk boþ olamaz")
                         .MaximumLength(500).WithMessage("Baþlýk en fazla 500 karakter olabilir")
                         .MinimumLength(3).WithMessage("Baþlýk en az 3 karakter olabilir");


            RuleFor(x => x.Description).NotEmpty().WithMessage("Açýklama boþ olamaz")
                                   .MaximumLength(200).WithMessage("Açýklama en fazla 200 karakter olabilir")
                                   .MinimumLength(5).WithMessage("Açýklama en az 5 karakter olabilir");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim URL'si boþ olamaz");


        }



    }



    }

