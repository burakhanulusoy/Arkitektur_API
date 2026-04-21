using Arkitektur.Business.DTOs.ContactDtos;
using Arkitektur.Business.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IContactService _contactService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _contactService.GetAllAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _contactService.GetByIdAsync(id);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);


        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto createContactDto)
        {
            var response = await _contactService.CreateAsync(createContactDto);

            return response.IsSuccessful ? Ok(response) : BadRequest(response);

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
        {
            var response = await _contactService.UpdateAsync(updateContactDto);

            return response.IsSuccessful ? NoContent() : BadRequest(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _contactService.DeleteAsync(id);

            return response.IsSuccessful ? NoContent() : BadRequest(response);


        }





    }
}
