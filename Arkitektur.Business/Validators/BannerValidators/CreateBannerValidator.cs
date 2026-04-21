using Arkitektur.Business.DTOs.BannerDtos;
using FluentValidation;

namespace Arkitektur.Business.Validators.BannerValidators
{
    public class CreateBannerValidator:AbstractValidator<CreateBannerDto>
    {
        public CreateBannerValidator()
        {

            RuleFor(x => x.Title).NotEmpty().WithMessage("Baþlýk boþ olamaz")
                                 .MaximumLength(50).WithMessage("Baþlýk en fazla 50 karakter olabilir")
                                 .MinimumLength(3).WithMessage("Baþlýk en az 3 karakter olabilir")
                                 .Must(title => title == null || !title.Any(c => new[] { '*', '/', '+', '-' }.Contains(c)))
                                 .WithMessage("Baþlýk içerisinde *, /, +, - gibi özel karakterler kullanýlamaz!");
             
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açýklama boþ olamaz")
                                   .MaximumLength(200).WithMessage("Açýklama en fazla 200 karakter olabilir")
                                   .MinimumLength(5).WithMessage("Açýklama en az 5 karakter olabilir");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim URL'si boþ olamaz")
                                        .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute)).WithMessage("Geçerli bir URL giriniz");

        }




    }
}
