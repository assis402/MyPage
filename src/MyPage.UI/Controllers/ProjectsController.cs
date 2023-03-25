﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IProjectsService _portfolioService;
        private readonly IStringLocalizer<LanguageResource> _languageResource;

        public ProjectsController(IProjectsService portfolioService,
                                  IStringLocalizer<LanguageResource> languageResource)
        {
            _portfolioService = portfolioService;
            _languageResource = languageResource;
        }

        public async Task<IActionResult> Index(List<int> tagsFilter, string searchFilter = "")
        {
            ViewData["SearchFilter"] = searchFilter;

            var currentLanguage = _languageResource["Culture"].Value.ToEnum<Language>();
            var projectsPageModel = await _portfolioService.GetPortfolioProjectsByLanguageAndFilter(currentLanguage, searchFilter);

            return View(projectsPageModel);
        }

        public IActionResult ClearCache()
        {
            try
            {
                _portfolioService.ClearPortfolioProjectsCache();
                _portfolioService.ClearPortfolioTagsCache();
                return Ok("Cache in memory \"Projects\" cleared successfully.");
            }
            catch (Exception ex)
            {
                var errorMessage = new
                {
                    Message = "Error when clearing Cache in memory \"Projects\".",
                    Exception = ex.Message
                };

                return BadRequest(errorMessage);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}