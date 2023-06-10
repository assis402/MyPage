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

        //public async Task<IActionResult> Index()
        //{
        //    var currentLanguage = _languageResource["Culture"].Value.ToEnum<Language>();
        //    var projectsPageModel = await _coursesService.GetAll(currentLanguage);

        //    return View(projectsPageModel);
        //}

        [HttpPost("[controller]")]
        public async Task<IActionResult> Insert(CourseInsertModel courseInsertModel)
        {
            await _coursesService.InsertCourse(courseInsertModel);
            return Ok();
        } 

        public IActionResult ClearCache()
        {
            try
            {
                _coursesService.ClearCoursesCache();
                return Ok("Cache in memory \"Courses\" cleared successfully.");
            }
            catch (Exception ex)
            {
                var errorMessage = new
                {
                    Message = "Error when clearing Cache in memory \"Courses\".",
                    Exception = ex.Message
                };

                return BadRequest(errorMessage);
            }
        }
    }
}