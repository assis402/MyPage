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

        public IActionResult ClearCache()
        {
            try
            {
                _aboutService.ClearAboutCache();
                return Ok("Cache in memory \"Publications\" cleared successfully.");
            }
            catch (Exception ex)
            {
                var errorMessage = new
                {
                    Message = "Error when clearing Cache in memory \"Publications\".",
                    Exception = ex.Message
                };

                return BadRequest(errorMessage);
            }
        }
    }
}