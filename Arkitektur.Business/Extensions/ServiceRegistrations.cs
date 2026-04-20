using Arkitektur.Business.Services.AboutServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistrations
    {

        public static IServiceCollection AddServiceExt(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddScoped<IAboutService,AboutService>();

            return services;

        }








    }
}
