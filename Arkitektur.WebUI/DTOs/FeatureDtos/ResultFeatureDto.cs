using Arkitektur.WebUI.Base;

namespace Arkitektur.WebUI.DTOs.FeatureDtos
{
    public class ResultFeatureDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string BacgroundImage { get; set; }
        public string Icon { get; set; }
    }
}
