using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.JwtTokenDtos;
using Arkitektur.Business.DTOs.UserIdentityDtos;

namespace Arkitektur.Business.Services.UserİdentityServices
{
    public interface IUserService
    {

        Task<BaseResult<object>> CreateUserAsync(CreateUserDto createUserDto);

        Task<BaseResult<TokenResponseDto>> LoginUserAsync(LoginUserDto loginUserDto);

    }
}
