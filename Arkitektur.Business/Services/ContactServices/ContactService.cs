using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ContactDtos;
using Arkitektur.DataAccess.Repositories.ContactRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.ContactServices
{
    public class ContactService(IContactRepository _contactRepository
                              ,IUnitOfWork _unitOfWork
                              ,IValidator<CreateContactDto> _createValidator
                              ,IValidator<UpdateContactDto> _updateValidator) : IContactService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateContactDto createDto)
        {

            var contact = createDto.Adapt<Contact>();

            var validationResult = await _createValidator.ValidateAsync(createDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _contactRepository.CreateAsync(contact);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(contact) : BaseResult<object>.Fail("Created Failed");


        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            
            var contact = await _contactRepository.GetByIdAsync(id);

            if(contact is null)
            {
                return BaseResult<object>.Fail("Contact Not Found");
            }

            _contactRepository.Delete(contact);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Deleted Failed");


        }

        public async Task<BaseResult<List<ResultContactDto>>> GetAllAsync()
        {
            var contacts = await _contactRepository.GetAllAsync();

            var mappedContacts = contacts.Adapt<List<ResultContactDto>>();

            return BaseResult<List<ResultContactDto>>.Success(mappedContacts);


        }

        public async Task<BaseResult<ResultContactDto>> GetByIdAsync(int id)
        {

            var contact = await _contactRepository.GetByIdAsync(id);

            if(contact is null)
            {
              return  BaseResult<ResultContactDto>.Fail("Contact Not Found");
            }

            var mappedContact = contact.Adapt<ResultContactDto>();

            return BaseResult<ResultContactDto>.Success(mappedContact);

        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateContactDto updateDto)
        {

            var contact = updateDto.Adapt<Contact>();

            var validationResult = await _updateValidator.ValidateAsync(updateDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            _contactRepository.Update(contact);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(contact) : BaseResult<object>.Fail("Updated Failed");





        }
    }
}
