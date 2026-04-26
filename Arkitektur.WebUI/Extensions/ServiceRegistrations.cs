using Arkitektur.WebUI.Handlers;
using Arkitektur.WebUI.Options;
using Arkitektur.WebUI.Services.MessageService;
using Arkitektur.WebUI.Services.TokenServices;

namespace Arkitektur.WebUI.Extensions
{
    public static class ServiceRegistrations
    {

        public static void AddServiceRegistrations(this IServiceCollection services,IConfiguration configuration)
        {

            //olay su secrettekı degerı apioptıons ıcın oku ve apıoptıonsa yaz

            services.Configure<ApiOptions>(configuration.GetSection(nameof(ApiOptions)));

            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<TokenHandler>();



        }





    }
}
