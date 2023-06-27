using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyPage.Application.Helpers;
using MyPage.Application.Models.Enums;
using MyPage.Application.Services.Interfaces;

namespace MyPage.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IStringLocalizer<LanguageResource> _languageResource;

        public HomeController(IAboutService aboutService,
            IStringLocalizer<LanguageResource> languageResource)
        {
            _aboutService = aboutService;
            _languageResource = languageResource;
        }

        public async Task<IActionResult> Index()
        {
            var currentLanguage = _languageResource["Culture"].Value.ToEnum<Language>();
            var pageModel = await _aboutService.GetAboutPageModel(currentLanguage);
            return View(pageModel);
        }
    }
}