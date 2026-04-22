using Arkitektur.WebUI.Services.CategoryServices;
using System.Net.Http.Headers;

namespace Arkitektur.WebUI.Extensions
{
    public static class WebUIServices
    {

        public static void AddHttpClientService(this IServiceCollection services,IConfiguration configuration)
        {

            //boyle yapınca scoped life time oluyor ek olarak yapmana gerek yok
            services.AddHttpClient<ICategoryService,CategoryService>(options=>
            {
                options.BaseAddress = new Uri("https://localhost:7018/api/");


            });



        }


    }
}
