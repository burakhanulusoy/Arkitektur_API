using Arkitektur.WebUI.Base;
using Arkitektur.WebUI.DTOs.AppointmentDtos;
using Arkitektur.WebUI.Enums;
using Arkitektur.WebUI.Exceptions;
using Arkitektur.WebUI.Services.MessageService;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Arkitektur.WebUI.Services.AppointmentServices
{
    public class AppointmentService(HttpClient _httpClient,IMessageService _messageService) : IAppointmentService
    {
        public async Task<BaseResult<object>> ApproveAsync(int id)
        {
            var appointment = await _httpClient.GetFromJsonAsync<BaseResult<UpdateAppointmentDto>>($"appointments/{id}");

            appointment.Data.Status = AppointmentStatus.Approved;


            var response = await _httpClient.PutAsJsonAsync("appointments", appointment.Data);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if(result.IsFailure)
            {
                throw new ApiValidationException(result.Errors);
            }
       
            await _messageService.SendMessageAsync(appointment.Data.Email, false, appointment.Data.AppointmentDate);
         
            return result;


        }

        public async Task<BaseResult<object>> CancelAsync(int id)
        {
            var appointment = await _httpClient.GetFromJsonAsync<BaseResult<UpdateAppointmentDto>>($"appointments/{id}");

            appointment.Data.Status = AppointmentStatus.Canceled;



            var response = await _httpClient.PutAsJsonAsync("appointments", appointment.Data);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result.IsFailure)
            {
                throw new ApiValidationException(result.Errors);
            }

            await _messageService.SendMessageAsync(appointment.Data.Email, true, appointment.Data.AppointmentDate);


            return result;

        }

        public async Task<BaseResult<object>> CreateAsync(CreateAppointmentDto createDto)
        {
            createDto.AppointmentDate = DateTime.Now;
            createDto.Status = AppointmentStatus.Pending;

            var response = await _httpClient.PostAsJsonAsync("appointments", createDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;



        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"appointments/{id}");

            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();


        }

        public async Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<BaseResult<List<ResultAppointmentDto>>>("appointments");
        }

        public async Task<BaseResult<UpdateAppointmentDto>> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<BaseResult<UpdateAppointmentDto>>($"appointments/{id}");
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto updateDto)
        {
            updateDto.Status = AppointmentStatus.Pending;

            var response = await _httpClient.PutAsJsonAsync("appointments", updateDto);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;


        }
    }
}
