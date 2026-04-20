using Arkitektur.Business.Services.AboutServices;
using Arkitektur.Business.Services.AppointmentServices;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistrations
    {

        public static IServiceCollection AddServiceExt(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddScoped<IAboutService,AboutService>();
            services.AddScoped<IAppointmentService,AppointmentService>();

           // services.AddValidatorsFromAssembly(typeof(CreateAppointmentValidator).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());




            return services;

        }








    }
}
