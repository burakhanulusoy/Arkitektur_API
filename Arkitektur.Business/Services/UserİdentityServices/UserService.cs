using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.JwtTokenDtos;
using Arkitektur.Business.DTOs.UserIdentityDtos;
using Arkitektur.Business.Services.JWTServices;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.UserİdentityServices
{
    public class UserService(UserManager<AppUser> _userManager
                            ,IValidator<CreateUserDto> _validator
                            ,SignInManager<AppUser> _signInManager
                            ,IJwtService _jwtService) : IUserService
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

        public async Task<BaseResult<List<ResultUserDto>>> GetAllUserAsync()
        {

            var users = await _userManager.Users.ToListAsync();

            var mappedUsers = users.Adapt<List<ResultUserDto>>();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                mappedUsers.Find(x => x.Id == user.Id).Roles = userRoles;
            }
            

            return BaseResult<List<ResultUserDto>>.Success(mappedUsers);

        }

        public async Task<BaseResult<TokenResponseDto>> LoginUserAsync(LoginUserDto loginUserDto)
        {
            var user = await _userManager.FindByEmailAsync(loginUserDto.Email);

            if (user is null)
            {
                return BaseResult<TokenResponseDto>.Fail("User Not Found");
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginUserDto.Password, true, true);

            if (!result.Succeeded)
            {
                return BaseResult<TokenResponseDto>.Fail("Password or email is incorrect");
            }

            var tokenResponse = await _jwtService.GenerateTokenAsync(user);

            return BaseResult<TokenResponseDto>.Success(tokenResponse);





        }
    }
}
