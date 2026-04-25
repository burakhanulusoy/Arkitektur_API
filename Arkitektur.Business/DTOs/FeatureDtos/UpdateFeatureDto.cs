namespace Arkitektur.Business.DTOs.FeatureDtos
{
    public class UpdateFeatureDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? BacgroundImage { get; set; }
        public string? Icon { get; set; }

    }
}
