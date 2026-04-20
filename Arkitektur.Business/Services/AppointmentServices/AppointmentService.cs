using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AppointmentDtos;
using Arkitektur.DataAccess.Repositories.AppointmentRepoistories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.AppointmentServices
{
    public class AppointmentService(IAppointmentRepository _appointmentRepository
                                   ,IUnitOfWork _unitOfWork
                                   ,IValidator<CreateAppointmentDto> _createValidator
                                   ,IValidator<UpdateAppointmentDto> _updateValidator) : IAppointmentService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAppointmentDto createDto)
        {

            var appointment = createDto.Adapt<Appointment>();
            
            var validationResult = await _createValidator.ValidateAsync(createDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);


            }

            await _appointmentRepository.CreateAsync(appointment);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(appointment) : BaseResult<object>.Fail("Created Failed");




        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if(appointment is null)
            {
                return BaseResult<object>.Fail("Appointment Not Found");
            }

            _appointmentRepository.Delete(appointment);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Deleted Failed");


        }

        public async Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync()
        {
           
            var appointments = await _appointmentRepository.GetAllAsync();

            var mappedAppointments = appointments.Adapt<List<ResultAppointmentDto>>();

            return BaseResult<List<ResultAppointmentDto>>.Success(mappedAppointments);

            // boþ dondurmek hata degýldýr !

        }

        public async Task<BaseResult<ResultAppointmentDto>> GetByIdAsync(int id)
        {
           
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if(appointment is null)
            {
                return BaseResult<ResultAppointmentDto>.Fail("Appointment Not Found");
            }

            var mappedAppointment = appointment.Adapt<ResultAppointmentDto>();

            return BaseResult<ResultAppointmentDto>.Success(mappedAppointment);



        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto updateDto)
        {
           
            var appointment = updateDto.Adapt<Appointment>();

            var validationResult = await _updateValidator.ValidateAsync(updateDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            _appointmentRepository.Update(appointment);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Updated Failed");




        }
    }
}
