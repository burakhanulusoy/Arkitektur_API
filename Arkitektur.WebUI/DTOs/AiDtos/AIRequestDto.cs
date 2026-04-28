namespace Arkitektur.WebUI.DTOs.AiDtos
{
    public class AIRequestDto
    {
        public IFormFile PlotImage { get; set; }
        public string UserPrompt { get; set; } // Örn: "Modern minimalist villa"
    }

    public class AIResponseDto
    {
        public string GeneratedImageUrl { get; set; }
        public string TechnicalAnalysis { get; set; }
    }
}
