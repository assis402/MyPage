using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyPage.Application.Helpers;
using MyPage.Application.Models.Enums;
using MyPage.Application.Services.Interfaces;
using MyPage.UI.Models;
using System.Diagnostics;

namespace MyPage.UI.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IGitRepositoryService _gitHubService;
        private readonly IStringLocalizer<LanguageResource> _languageResource;

        public ProjectsController(IGitRepositoryService gitHubService,
                                  IStringLocalizer<LanguageResource> languageResource)
        {
            _gitHubService = gitHubService;
            _languageResource = languageResource;
        }

        public async Task<IActionResult> Index()
        {
            var currentLanguage = _languageResource["Culture"].Value.ToEnum<Language>();
            var repositories = await _gitHubService.GetPortfolioRepositories(currentLanguage);
            return View(repositories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}