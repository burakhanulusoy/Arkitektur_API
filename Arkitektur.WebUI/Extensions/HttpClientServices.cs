using Arkitektur.WebUI.Options;
using Arkitektur.WebUI.Services.AboutServices;
using Arkitektur.WebUI.Services.AppointmentServices;
using Arkitektur.WebUI.Services.BannerServices;
using Arkitektur.WebUI.Services.CategoryServices;
using Arkitektur.WebUI.Services.ChooseServices;
using Arkitektur.WebUI.Services.ContactService;
using Arkitektur.WebUI.Services.FeatureServices;
using Arkitektur.WebUI.Services.FileServices;
using Arkitektur.WebUI.Services.ProjectServices;
using Arkitektur.WebUI.Services.UserServices;

namespace Arkitektur.WebUI.Extensions
{
    public static class HttpClientServices
    {

        public static void AddHttpClientService(this IServiceCollection services,IConfiguration configuration)
        {

            var apiOptions = configuration.GetSection(nameof(ApiOptions)).Get<ApiOptions>();

            //boyle yapınca scoped life time oluyor ek olarak yapmana gerek yok
            services.AddHttpClient<ICategoryService,CategoryService>(options=>
            {
                options.BaseAddress = new Uri(apiOptions.baseUrl);

            });
            services.AddHttpClient<IProjectService, ProjectService>(options =>
            {
                options.BaseAddress = new Uri(apiOptions.baseUrl);

            });

            services.AddHttpClient<IFileService, FileService>(options =>
            {
                options.BaseAddress = new Uri(apiOptions.baseUrl);

            });

            services.AddHttpClient<IAboutService, AboutService>(options =>
            {
                options.BaseAddress = new Uri(apiOptions.baseUrl);

            });

            services.AddHttpClient<IBannerService, BannerService>(options =>
            {
                options.BaseAddress = new Uri(apiOptions.baseUrl);

            });

            services.AddHttpClient<IChooseService, ChooseService>(options =>
            {
                options.BaseAddress = new Uri(apiOptions.baseUrl);

            });

            services.AddHttpClient<IContactService, ContactService>(options =>
            {
                options.BaseAddress = new Uri(apiOptions.baseUrl);

            });

            services.AddHttpClient<IFeatureService, FeatureService>(options =>
            {
                options.BaseAddress = new Uri(apiOptions.baseUrl);

            });

            services.AddHttpClient<IAppointmentService, AppointmentService>(options =>
            {
                options.BaseAddress = new Uri(apiOptions.baseUrl);

            });

            services.AddHttpClient<IUserService, UserService>(options =>
            {
                options.BaseAddress = new Uri(apiOptions.baseUrl);

            });

        }


    }
}
