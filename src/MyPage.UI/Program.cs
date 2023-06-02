using Microsoft.AspNetCore.HttpOverrides;
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
builder.Services.AddTransient<IAboutService, AboutService>();
builder.Services.AddTransient<IProjectsService, ProjectsService>();
builder.Services.AddTransient<IGitHubIntegration, GitHubIntegration>();
builder.Services.AddTransient<IMediumIntegration, MediumIntegration>();
builder.Services.AddTransient<IPublicationsCacheService, PublicationsCacheService>();
builder.Services.AddTransient<IProjectsCacheService, ProjectsCacheService>();
builder.Services.AddTransient<ITagsCacheService, TagsCacheService>();
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
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.Use((context, next) =>
    {
        context.Request.PathBase = "/";
        return next();
    });
}

app.UseStaticFiles();

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

app.UseForwardedHeaders();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();