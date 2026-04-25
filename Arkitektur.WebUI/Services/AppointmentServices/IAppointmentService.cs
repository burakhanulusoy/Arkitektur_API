using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.AppointmentDtos;
using Arkitektur.WebUI.Services.GenericServices;

namespace Arkitektur.WebUI.Services.AppointmentServices
{
    public interface IAppointmentService:IGenericService<ResultAppointmentDto,CreateAppointmentDto,UpdateAppointmentDto>
    {
        Task<BaseResult<object>> ApproveAsync(int id);
        Task<BaseResult<object>> CancelAsync(int id);



    }
}
