using Microsoft.Extensions.Caching.Memory;
using MyPage.Application.Data.Entities;
using MyPage.Application.Helpers;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class CoursesCacheService : ICoursesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string _key;
        private readonly int _cacheExpirationInDays;

        public CoursesCacheService(Settings settings,
                                    IMemoryCache memoryCache)
        {
            _key = settings.CoursesCacheKey;
            _cacheExpirationInDays = settings.CacheExpirationInDays;
            _memoryCache = memoryCache;
        }

        public async Task<ICollection<CourseCertificate>> GetOrCreate(Func<Task<ICollection<CourseCertificate>>> methodToCache)
        {
            return await _memoryCache.GetOrCreateAsync(_key, async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(_cacheExpirationInDays);
                cacheEntry.SetPriority(CacheItemPriority.High);
                return await methodToCache();
            });
        }

        public void ClearCache() => _memoryCache.Remove(_key);
    }
}