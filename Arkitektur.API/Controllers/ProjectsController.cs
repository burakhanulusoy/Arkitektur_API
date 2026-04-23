using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.Business.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService _projectService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _projectService.GetAllAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("WithCategories")]
        public async Task<IActionResult> GetProjectWithCategory()
        {
            var response = await _projectService.GetProjectsWithCategoryAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _projectService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _projectService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectDto updateDto)
        {
            var response = await _projectService.UpdateAsync(updateDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto createDto)
        {
            var response = await _projectService.CreateAsync(createDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }


    }
}
