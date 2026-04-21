using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.UserIdentityDtos;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Identity;



namespace Arkitektur.Business.Services.UserİdentityServices
{
    public class UserService(UserManager<AppUser> _userManager ,IValidator<CreateUserDto> _validator) : IUserService
    {
        public async Task<BaseResult<object>> CreateUserAsync(CreateUserDto createUserDto)
        {

            if (createUserDto.Password != createUserDto.ConfirmPassword)
            {
                return  BaseResult<object>.Fail("Şifreler birbiriyle uyuşmuyor.");

            }

            var validationResult = await _validator.ValidateAsync(createUserDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }



            var user = createUserDto.Adapt<AppUser>();


            var result = await _userManager.CreateAsync(user, createUserDto.Password);


            if(!result.Succeeded)
            {
                return BaseResult<object>.Fail(result.Errors);

            }

            return BaseResult<object>.Success(new {Message ="User Created Success"});




        }
    }
}
