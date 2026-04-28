using Arkitektur.WebUI.Extensions;
using Arkitektur.WebUI.Filters;
using Arkitektur.WebUI.Services.AiServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// AI Servislerinin Kayýtlarý
// HttpClient kullanan servisler için AddHttpClient kullanýyoruz:
builder.Services.AddHttpClient<IGeminiService, GeminiService>();
builder.Services.AddHttpClient<ILeonardoService, LeonardoService>();

// Ana orkestra þefimiz olan AIManager'ý sisteme tanýtýyoruz:
builder.Services.AddScoped<IAIService, AIManager>();

builder.Services.AddHttpClientService(builder.Configuration);

builder.Services.AddServiceRegistrations(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.LogoutPath = "/Auth/Logout";
                    options.AccessDeniedPath = "/Auth/AccessDeniedPage";
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                    options.Cookie.Name = "Arlitektur.com";


                }); 


builder.Services.AddControllersWithViews(options =>
{
    //tüm contrllera entegre ediyorum
    options.Filters.Add<ValidationExceptionFilter>();

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();


app.UseAuthorization();

app.MapStaticAssets();

//admin area !
app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
         );



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();




app.Run();
