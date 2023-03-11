using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using MyPage.Application.Helpers;
using MyPage.Application.Integrations;
using MyPage.Application.Integrations.Interfaces;
using MyPage.Application.Services;
using MyPage.Application.Services.Interfaces;
using MyPage.UI;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.Configure<Settings>(configuration)
                .AddSingleton(sp => sp.GetRequiredService<IOptions<Settings>>().Value);

builder.Services.AddMemoryCache();
builder.Services.AddTransient<IGitHubIntegration, GitHubIntegration>();
builder.Services.AddTransient<IGitRepositoryService, GitRepositoryService>();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews()
                .AddDataAnnotationsLocalization(option =>
                {
                    option.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(LanguageResource).Assembly.FullName!);
                        return factory.Create("LanguageResource", assemblyName.Name!);
                    };
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("pt-BR")
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
