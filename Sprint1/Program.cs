using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Google.Apis.Auth.OAuth2;
using FirebaseAdmin;

var builder = WebApplication.CreateBuilder(args);

// Set up configuration sources.
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Initialize Firebase Admin SDK
builder.Services.AddSingleton<FirebaseApp>(sp =>
{
    var hostingEnvironment = sp.GetRequiredService<IWebHostEnvironment>();
    var pathToKeyFile = Path.Combine(hostingEnvironment.ContentRootPath, "App_Data", "serviceAccountKey.json");
    var credential = GoogleCredential.FromFile(pathToKeyFile);
    return FirebaseApp.Create(new AppOptions
    {
        Credential = credential
    });
});

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
