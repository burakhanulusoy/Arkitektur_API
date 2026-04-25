using Arkitektur.WebUI.DTOs.ContactDtos;
using Arkitektur.WebUI.Services.GenericServices;

namespace Arkitektur.WebUI.Services.ContactService
{
    public interface IContactService : IGenericService<ResultContactDto,CreateContactDto,UpdateContactDto>
    {
    }
}
