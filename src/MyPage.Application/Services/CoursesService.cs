using MyPage.Application.Helpers;
using MyPage.Application.Models.Enums;
using MyPage.Application.Models.Pages;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly Settings _settings;
        private readonly ICoursesCacheService _coursesCacheService;

        public CoursesService(Settings settings,
            ICoursesCacheService coursesCacheService)
        {
            _settings = settings;
            _coursesCacheService = coursesCacheService;
        }

        public Task<CoursesPageModel> GetAll(Language currentLanguage)
        {
            throw new NotImplementedException();
        }

        public void ClearCoursesCache() => _coursesCacheService.ClearCache();
    }
}