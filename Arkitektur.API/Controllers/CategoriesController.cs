using Arkitektur.Business.DTOs.CategoryDtos;
using Arkitektur.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
         
            var response = await _categoryService.GetAllAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoryService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.DeleteAsync(id);
            return response.IsSuccessful ? NoContent() : BadRequest(response);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createDto)
        {
            var response = await _categoryService.CreateAsync(createDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateDto)
        {
            var response = await _categoryService.UpdateAsync(updateDto);
            return response.IsSuccessful ? NoContent() : BadRequest(response);
        }





    }
}
