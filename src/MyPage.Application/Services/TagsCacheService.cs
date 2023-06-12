using Microsoft.Extensions.Caching.Memory;
using MyPage.Application.Helpers;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class TagsCacheService : ITagsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string _key;
        private readonly int _cacheExpirationInDays;

        public TagsCacheService(Settings settings,
                                IMemoryCache memoryCache)
        {
            _key = settings.CacheSettings.TagsCacheKey;
            _cacheExpirationInDays = settings.CacheSettings.CacheExpirationInDays;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<string>> GetOrCreate(Func<Task<IEnumerable<string>>> methodToCache)
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