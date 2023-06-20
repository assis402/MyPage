using Microsoft.Extensions.Caching.Memory;
using MyPage.Application.Helpers;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class TagsCacheService : MemoryCacheService<IEnumerable<string>>, ITagsCacheService
    {
        public TagsCacheService(Settings settings, IMemoryCache memoryCache)
            : base(settings.CacheSettings.TagsCacheKey, settings.CacheSettings.CacheExpirationInDays, memoryCache)
        { }
    }
}