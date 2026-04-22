namespace Arkitektur.Business.DTOs.RoleAssignDtos
{
    public class AssignRoleDto
    {

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; }//bu rol kiþide varmi kontrolü için






    }
}
