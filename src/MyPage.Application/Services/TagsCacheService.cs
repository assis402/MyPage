using Microsoft.Extensions.Caching.Memory;
using MyPage.Application.Helpers;
using MyPage.Application.Models.GitHubIntegration;
using MyPage.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Services
{
    public class TagsCacheService : IMemoryCacheService<IEnumerable<string>>
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string _key;
        private readonly int _cacheExpirationInDays;

        public TagsCacheService(Settings settings,
                                IMemoryCache memoryCache)
        {
            _key = settings.TagsCacheKey;
            _cacheExpirationInDays = settings.CacheExpirationInDays;
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
