using Arkitektur.WebUI.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.WebUI.ViewComponents._DefaultComponents
{
    public class _DefaultFeatureViewComponents(IFeatureService _featureService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var features = await _featureService.GetAllAsync();
            return View(features.Data);


        }




    }
}
