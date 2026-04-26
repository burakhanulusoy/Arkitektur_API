using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.RoleAssignDtos;
using Arkitektur.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.RoleAssignServices
{
    public class AssignRoleService(UserManager<AppUser> _userManager,
                                   RoleManager<AppRole> _roleManager) : IAssignRoleService
    {
        public async Task<BaseResult<object>> AssignRoleAsync(List<AssignRoleDto> assignRoleDtos)
        {

            var userId = assignRoleDtos.Select(x => x.UserId).FirstOrDefault();

            var user = await _userManager.FindByIdAsync(userId.ToString());

            foreach(var role in assignRoleDtos)
            {

                if(role.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user,role.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user,role.RoleName);
                }



            }


            return BaseResult<object>.Success(new {Message ="Assign Role Successful."});


        }

        public async Task<BaseResult<List<AssignRoleDto>>> GetUserForRoleAssignAsync(int id)
        {
            
            var user = await _userManager.FindByIdAsync(id.ToString());

            if(user is null)
            {
                return BaseResult<List<AssignRoleDto>>.Fail("User Not Found");
            }

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            var assignRoleList = new List<AssignRoleDto>();

            foreach(var role in roles)
            {

                assignRoleList.Add(new AssignRoleDto
                {
                    FullName=string.Join(" ",user.FirstName,user.LastName),
                    RoleId = role.Id,
                    UserId = user.Id,
                    RoleName = role.Name,
                    RoleExist = userRoles.Contains(role.Name) //true ya da false


                });


            }

            return BaseResult<List<AssignRoleDto>>.Success(assignRoleList);


        
        }
    
    
    
    }
}
