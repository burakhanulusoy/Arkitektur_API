namespace Arkitektur.WebUI.DTOs.UserDtos
{
    public class AssignRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; }//bu rol kişide varmi kontrolü için
        public string? FullName { get; set; }


    }
}
