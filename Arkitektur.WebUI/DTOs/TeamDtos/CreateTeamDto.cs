using System.Text.Json.Serialization;

namespace Arkitektur.WebUI.DTOs.TeamDtos
{
    public class CreateTeamDto
    {
        public string? NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }  //işi
        [JsonIgnore]
        public IFormFile? file { get; set; }
    }
}
