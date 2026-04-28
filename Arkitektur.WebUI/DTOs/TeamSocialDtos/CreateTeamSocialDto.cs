namespace Arkitektur.WebUI.DTOs.TeamSocialDtos
{
    public class CreateTeamSocialDto
    {
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }

        public int TeamId { get; set; }
    }
}
