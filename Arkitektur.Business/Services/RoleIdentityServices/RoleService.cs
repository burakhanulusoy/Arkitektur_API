using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.RoleIdentityDtos;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.RoleIdentityServices
{
    public class RoleService(RoleManager<AppRole> _roleManager
                            ,IValidator<CreateRoleDto> _validator) : IRoleService
    {
        public async Task<BaseResult<object>> CreateRoleAsync(CreateRoleDto createRoleDto)
        {
           
            var validationResult =await _validator.ValidateAsync(createRoleDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            var role = createRoleDto.Adapt<AppRole>();

            var result = await _roleManager.CreateAsync(role);

            if(!result.Succeeded)
            {
                return BaseResult<object>.Fail(result.Errors);
            }

            return BaseResult<object>.Success(new { Message = "Role Created" });

        }

        public async Task<BaseResult<List<ResultRoleDto>>> GetAllRolesAsync()
        {
           
             var roles = await _roleManager.Roles.ToListAsync();

             var mappedRoles = roles.Adapt<List<ResultRoleDto>>();

            return BaseResult<List<ResultRoleDto>>.Success(mappedRoles);

        }
    }
}
