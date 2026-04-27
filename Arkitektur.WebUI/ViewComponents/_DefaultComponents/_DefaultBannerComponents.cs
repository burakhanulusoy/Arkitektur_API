using Arkitektur.WebUI.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.WebUI.ViewComponents._DefaultComponents
{
    public class _DefaultBannerComponents(IBannerService _bannerService):ViewComponent
    {
      
           public async Task<IViewComponentResult> InvokeAsync()
           {
                 var  response = await _bannerService.GetAllAsync();


                 return View(response.Data);
           }


    }
}
