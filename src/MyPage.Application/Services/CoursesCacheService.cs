using Microsoft.Extensions.Caching.Memory;
using MyPage.Application.Helpers;
using MyPage.Application.Models.Courses;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class CoursesCacheService : MemoryCacheService<ICollection<CourseCertificateModel>>, ICoursesCacheService
    {
        public CoursesCacheService(Settings settings, IMemoryCache memoryCache)
            : base(settings.CacheSettings.CoursesCacheKey, settings.CacheSettings.CacheExpirationInDays, memoryCache)
        { }
    }
}