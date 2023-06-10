using MyPage.Application.Data.Entities;
using MyPage.Application.Data.Repositories.Interfaces;
using MyPage.Application.Helpers;
using MyPage.Application.Models.Courses;
using MyPage.Application.Models.Enums;
using MyPage.Application.Models.Pages;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly Settings _settings;
        private readonly ICoursesCacheService _coursesCacheService;
        private readonly ICourseCertificateRepository _courseCertificateRepository;

        public CoursesService(Settings settings,
            ICoursesCacheService coursesCacheService,
            ICourseCertificateRepository courseCertificateRepository)
        {
            _settings = settings;
            _coursesCacheService = coursesCacheService;
            _courseCertificateRepository = courseCertificateRepository;
        }

        public async Task<CoursesPageModel> GetCourses(Language currentLanguage)
        {
            var courseCertificates = await _courseCertificateRepository.GetAll();
            return new CoursesPageModel(courseCertificates, currentLanguage);
        }

        public async Task InsertCourse(CourseInsertModel course)
        {
            await _courseCertificateRepository.Insert(new CourseCertificate(course));
        }

        public void ClearCoursesCache() => _coursesCacheService.ClearCache();
    }
}