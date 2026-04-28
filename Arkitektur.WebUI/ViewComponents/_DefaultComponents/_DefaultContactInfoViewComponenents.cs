using Arkitektur.WebUI.Services.ContactService;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.WebUI.ViewComponents._DefaultComponents
{
    public class _DefaultContactInfoViewComponenents(IContactService _contactService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contact = (await _contactService.GetAllAsync()).Data.OrderByDescending(x=>x.Id).FirstOrDefault();
            return View(contact);

        }


    }
}
