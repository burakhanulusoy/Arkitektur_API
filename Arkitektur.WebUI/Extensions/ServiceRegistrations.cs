using Arkitektur.WebUI.Options;

namespace Arkitektur.WebUI.Extensions
{
    public static class ServiceRegistrations
    {

        public static void AddServiceRegistrations(this IServiceCollection services,IConfiguration configuration)
        {

            //olay su secrettekı degerı apioptıons ıcın oku ve apıoptıonsa yaz

            services.Configure<ApiOptions>(configuration.GetSection(nameof(ApiOptions)));


        }





    }
}
