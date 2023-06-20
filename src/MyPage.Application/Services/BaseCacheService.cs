using Microsoft.Extensions.Caching.Memory;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class MemoryCacheService<T> : IMemoryCacheService<T> where T : class
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string _key;
        private readonly int _cacheExpirationInDays;

        public MemoryCacheService(string key,
            int cacheExpiration,
            IMemoryCache memoryCache)
        {
            _key = key;
            _cacheExpirationInDays = cacheExpiration;
            _memoryCache = memoryCache;
        }

        public async Task<T> GetOrCreate(Func<Task<T>> methodToCache)
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