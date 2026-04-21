using Amazon.Runtime;
using Amazon.S3;
using Arkitektur.Business.Assemblies;
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


            //SCRUTOR ÝLE AUTO REGÝSTRATÝON

            services.Scan(options => options.FromAssemblyOf<BusinessAssembly>() //kendi assembly içinde 
                     .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
                     .AsImplementedInterfaces()
                     .WithScopedLifetime()

            );

            //AWS CONNFÝGRASYONU

            var awsOptions = configuration.GetAWSOptions();

            awsOptions.Region = Amazon.RegionEndpoint.EUNorth1;

            awsOptions.Credentials = new BasicAWSCredentials(
                   
                    configuration["AWS:AccessKey"],
                    configuration["AWS:SecretKey"]
                    


            );

            services.AddDefaultAWSOptions(awsOptions);

            services.AddAWSService<IAmazonS3>();



            // services.AddValidatorsFromAssembly(typeof(CreateAppointmentValidator).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());




            return services;

        }








    }
}
