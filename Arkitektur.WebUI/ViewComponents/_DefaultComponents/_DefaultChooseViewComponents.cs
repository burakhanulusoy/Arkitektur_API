using Arkitektur.WebUI.Services.ChooseServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents._DefaultComponents
{
    public class _DefaultChooseViewComponents(IChooseService _chooseService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var choosess = await _chooseService.GetAllAsync();
            var lastChoose=choosess.Data.OrderByDescending(x=>x.Id).FirstOrDefault();

            return View(lastChoose);


        }





    }
}
