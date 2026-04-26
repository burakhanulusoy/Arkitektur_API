using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.JwtTokenDtos;
using Arkitektur.WebUI.DTOs.UserDtos;
using Arkitektur.WebUI.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Arkitektur.WebUI.Services.UserServices
{                                              
                                                 //controller erşsedok httcontext onun ıcın bunu ekledık
    public class UserService(HttpClient _client,IHttpContextAccessor _httpContext) : IUserService
    {
        public async Task<BaseResult<object>> AssignRoleAsync(List<AssignRoleDto> assignRoleDtos)
        {

            var response = await _client.PostAsJsonAsync("assignRoles", assignRoleDtos);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;

        }

        public async Task<BaseResult<List<ResultUserDto>>> GetAllUserAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultUserDto>>>("users");
        }

        public async Task<BaseResult<List<AssignRoleDto>>> GetUserForeRoleAssignAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<List<AssignRoleDto>>>($"assignRoles/{id}");

        }

        public async Task<BaseResult<TokenResponseDto>> LoginAsync(LoginUserDto userDto)
        {
            var response = await _client.PostAsJsonAsync("users/login", userDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<TokenResponseDto>>();

            if(result.IsFailure)
            {
                throw new ApiValidationException(result.Errors);
            }

            //jwt token okuyucu
            JwtSecurityTokenHandler handler = new();

            var token = handler.ReadJwtToken(result.Data.Token);

            var claims = token.Claims.ToList();

            claims.Add(new Claim("Token", result.Data.Token));

            var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);

            var authProporty = new AuthenticationProperties
            {
                ExpiresUtc = result.Data.ExpireTime,
                IsPersistent = true,//beni hatırla

            };


            await _httpContext.HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProporty);


            return result;



        }
    }
}
