using Microsoft.AspNetCore.Mvc;
using MyPage.Application.Services.Interfaces;

namespace MyPage.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;

        public HomeController(IAboutService aboutService) => _aboutService = aboutService;

        public async Task<IActionResult> Index()
        {
            var pageModel = await _aboutService.GetAboutPageModel();
            return View(pageModel);
        }
    }
}