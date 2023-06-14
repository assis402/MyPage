using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyPage.Application.Helpers;
using MyPage.Application.Models.Enums;
using MyPage.Application.Services.Interfaces;

namespace MyPage.UI.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectsService _portfolioService;
        private readonly IStringLocalizer<LanguageResource> _languageResource;

        public ProjectsController(IProjectsService portfolioService,
                                  IStringLocalizer<LanguageResource> languageResource)
        {
            _portfolioService = portfolioService;
            _languageResource = languageResource;
        }

        public async Task<IActionResult> Index(string tagFilter, string searchFilter = "")
        {
            ViewData["SearchFilter"] = searchFilter.Trim();
            ViewData["TagFilter"] = tagFilter;
            var currentLanguage = _languageResource["Culture"].Value.ToEnum<Language>();
            var projectsPageModel = await _portfolioService.GetPortfolioProjectsByLanguageAndFilter(currentLanguage, searchFilter.Trim(), tagFilter);

            return View(projectsPageModel);
        }
    }
}