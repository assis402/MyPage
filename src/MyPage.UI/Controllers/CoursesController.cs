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

        //[Authorize]
        public IActionResult Add()
        {
            return View("AddUpdateCourse", new AddUpdateCoursePageModel());
        }

        [HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CourseCertificateModel courseModel)
        {
            await _coursesService.Add(courseModel);
            return RedirectToAction(nameof(Index));
        }

        //[Authorize]
        public async Task<IActionResult> Update(string id)
        {
            var courseModel = await _coursesService.GetById(id);
            return View("AddUpdateCourse", new AddUpdateCoursePageModel(courseModel));
        }

        [HttpPut]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CourseCertificateModel courseModel)
        {
            await _coursesService.Update(courseModel);
            return RedirectToAction(nameof(Index));
        }

        //[Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            var courseModel = await _coursesService.GetById(id);
            return View("DeleteCourse", courseModel);
        }

        [HttpDelete]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CourseCertificateModel courseModel)
        {
            await _coursesService.DeleteById(courseModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}