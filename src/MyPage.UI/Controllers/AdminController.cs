using GoogleAuthentication.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyPage.Application.Helpers;
using MyPage.Application.Models.Courses;
using MyPage.Application.Models.Enums;
using MyPage.Application.Models.Google;
using MyPage.Application.Services.Interfaces;
using Pipelines.Sockets.Unofficial.Buffers;
using System.Security.Claims;

namespace MyPage.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly string _googleLoginUrl;
        private readonly IAdminService _adminService;
        private readonly ICoursesService _coursesService;


        public AdminController(Settings settings,
            IAdminService adminService,
            ICoursesService coursesService)
        {
            _googleLoginUrl = GoogleAuth.GetAuthUrl(settings.GoogleSettings.ClientId,
                settings.GoogleSettings.CallbackUrl);

            _coursesService = coursesService;
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            if (ViewBag.LoggedWithNonMatheusAccount ?? false)
                return View();

            if (HttpContext.User.Identity?.IsAuthenticated ?? false)
            {
                ViewBag.IsAuthenticated = true;
                ViewBag.UserName = HttpContext.User.Identity.Name;
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
                ViewBag.LoggedWithNonMatheusAccount = true;
                return RedirectToAction(nameof(Index));
            }

            var userIdentity = _adminService.CreateUserIdentity(googleProfile);

            await HttpContext.SignInAsync(userIdentity);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertCourse([Bind] CourseInsertModel courseInsertModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}