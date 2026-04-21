using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.DataAccess.Repositories.ProjectRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.ProjectServices
{
    public class ProjectService(IUnitOfWork _unitOfWork
                               ,IProjectRepository _projectRepositories
                               ,IValidator<CreateProjectDto> _createValidator
                               ,IValidator<UpdateProjectDto> _updateValidator) : IProjectService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateProjectDto createDto)
        {

            var project = createDto.Adapt<Project>();

            var validationResult = await _createValidator.ValidateAsync(createDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _projectRepositories.CreateAsync(project);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(project) : BaseResult<object>.Fail("Created Failed");




        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            
            var project = await _projectRepositories.GetByIdAsync(id);

            if(project is null)
            {
                return BaseResult<object>.Fail("Project Not Found");
            }


            _projectRepositories.Delete(project);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Deleted Failed");




        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetAllAsync()
        {
            
            var projects = await _projectRepositories.GetAllAsync();

            var mappedProjects =projects.Adapt<List<ResultProjectDto>>();

            return BaseResult<List<ResultProjectDto>>.Success(mappedProjects);


        }

        public async Task<BaseResult<ResultProjectDto>> GetByIdAsync(int id)
        {
           
            var project = await _projectRepositories.GetByIdAsync(id);

            if(project is null)
            {
                return BaseResult<ResultProjectDto>.Fail("Project Not Found");
            }

            var mappedProject = project.Adapt<ResultProjectDto>();

            return BaseResult<ResultProjectDto>.Success(mappedProject);


        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategoryAsync()
        {

            var queryable = _projectRepositories.GetQueryable();

            var products = await queryable.Include(x=>x.Category).ToListAsync();

            var mappedProjects = products.Adapt<List<ResultProjectDto>>();

            return BaseResult<List<ResultProjectDto>>.Success(mappedProjects);


        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateProjectDto updateDto)
        {
            var project =updateDto.Adapt<Project>();

            var validationResult =await _updateValidator.ValidateAsync(updateDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            _projectRepositories.Update(project);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Updated Failed");



        }
    }
}
