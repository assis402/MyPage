using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MyPage.Application.Helpers;
using MyPage.Application.Models.Courses;
using MyPage.Application.Models.Enums;
using MyPage.Application.Services.Interfaces;

namespace MyPage.UI.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesService _coursesService;
        private readonly IStringLocalizer<LanguageResource> _languageResource;

        public CoursesController(IStringLocalizer<LanguageResource> languageResource,
            ICoursesService coursesService)
        {
            _languageResource = languageResource;
            _coursesService = coursesService;
        }

        public async Task<IActionResult> Index()
        {
            var currentLanguage = _languageResource["Culture"].Value.ToEnum<Language>();
            var coursesPageModel = await _coursesService.GetCoursesPageModel(currentLanguage);

            return View(coursesPageModel);
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