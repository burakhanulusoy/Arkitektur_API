using System.Text.Json.Serialization;

namespace Arkitektur.WebUI.DTOs.TeamDtos
{
    public class UpdateTeamDto
    {
        public int Id { get; set; }
        public string? NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }  //işi
        [JsonIgnore]
        public IFormFile? file { get; set; }
    }
}
