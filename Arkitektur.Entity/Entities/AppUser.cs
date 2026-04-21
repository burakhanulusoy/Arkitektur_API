using Microsoft.AspNetCore.Identity;

namespace Arkitektur.Entity.Entities
{
    public class AppUser:IdentityUser<int>
    {
        //sýnýfý yazmasak bile ef core bize bunu tabllya ekler

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
