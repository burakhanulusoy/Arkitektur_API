using Arkitektur.Business.DTOs.JwtTokenDtos;
using Arkitektur.Entity.Entities;

namespace Arkitektur.Business.Services.JWTServices
{
    public interface IJwtService
    {

        Task<TokenResponseDto> GenerateTokenAsync(AppUser appUser);


    }
}
