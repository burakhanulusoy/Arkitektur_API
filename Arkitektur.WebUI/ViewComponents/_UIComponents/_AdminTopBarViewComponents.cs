using Arkitektur.WebUI.Services.ContactService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.WebUI.ViewComponents._AdminComponents
{
    public class _AdminTopBarViewComponents(IContactService _contactService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = (await _contactService.GetAllAsync()).Data.OrderByDescending(x=>x.Id).FirstOrDefault();

            return View(item);
        }


    }
}
