using GoogleAuthentication.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyPage.Application.Helpers;
using MyPage.Application.Services.Interfaces;

namespace MyPage.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly string _googleLoginUrl;
        private readonly IAdminService _adminService;
        private readonly ICoursesService _coursesService;
        private readonly IAboutService _aboutService;
        private readonly IProjectsService _portfolioService;

        public AdminController(Settings settings,
            IAdminService adminService,
            ICoursesService coursesService,
            IAboutService aboutService,
            IProjectsService portfolioService)
        {
            _googleLoginUrl = GoogleAuth.GetAuthUrl(settings.GoogleSettings.ClientId,
                settings.GoogleSettings.CallbackUrl);

            _coursesService = coursesService;
            _adminService = adminService;
            _aboutService = aboutService;
            _portfolioService = portfolioService;
        }

        public IActionResult Index()
        {
            if (TempData["Message"] is not null)
                ViewBag.Message = TempData["Message"]!.ToString();

            if (User.Identity?.IsAuthenticated ?? false)
            {
                ViewBag.IsAuthenticated = true;
                ViewBag.UserName = User.Identity.Name;
            }
            else
            {
                ViewBag.IsAuthenticated = false;
            }

            return View();
        }

        public IActionResult Login() => Redirect(_googleLoginUrl);

        public async Task<IActionResult> Callback(string code)
        {
            var googleProfile = await _adminService.GetGoogleProfile(code);

            if (!googleProfile.Email.Equals("assis4002@gmail.com"))
            {
                TempData["Message"] = "Only the owner of this site can login to this page.";
                return RedirectToAction(nameof(Index));
            }

            var userIdentity = _adminService.CreateUserIdentity(googleProfile);

            await HttpContext.SignInAsync(userIdentity);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ClearCoursesCache()
        {
            try
            {
                _coursesService.ClearCoursesCache();
                TempData["Message"] = "Cache in memory Courses cleared successfully.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error when clearing cache in memory Courses.";
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ClearPublicationsCache()
        {
            try
            {
                _aboutService.ClearPublicationsCache();
                TempData["Message"] = "Cache in memory Publications cleared successfully.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error when clearing cache in memory Publications.";
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ClearProjectsCache()
        {
            try
            {
                _portfolioService.ClearPortfolioProjectsCache();
                _portfolioService.ClearPortfolioTagsCache();
                TempData["Message"] = "Cache in memory Projects and Tags cleared successfully.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error when clearing cache in memory Projects and Tags.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}