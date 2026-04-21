using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.UserIdentityDtos;

namespace Arkitektur.Business.Services.UserİdentityServices
{
    public interface IUserService
    {

        Task<BaseResult<object>> CreateUserAsync(CreateUserDto createUserDto);

    }
}
