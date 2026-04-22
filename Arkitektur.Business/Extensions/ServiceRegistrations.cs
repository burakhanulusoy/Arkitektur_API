using Amazon.Runtime;
using Amazon.S3;
using Arkitektur.Business.Assemblies;
using Arkitektur.Business.Options;
using Arkitektur.Business.Services.AboutServices;
using Arkitektur.Business.Services.AppointmentServices;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

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


            //************************

            //JWT Configrasyonlarý

            var tokenOptions = configuration.GetSection(nameof(JwtTokenOptions)).Get<JwtTokenOptions>();


            //ýoptions yaptýkya onun için
            services.Configure<JwtTokenOptions>(configuration.GetSection(nameof(JwtTokenOptions)));


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Key)),
                    ClockSkew = TimeSpan.Zero
                   
                };


            });

            //****************************************

            return services;

        }








    }
}
