using Arkitektur.WebUI.Extensions;
using Arkitektur.WebUI.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddHttpClientService(builder.Configuration);

builder.Services.AddServiceRegistrations(builder.Configuration);


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
