using Microsoft.Extensions.Caching.Memory;
using MyPage.Application.Helpers;
using MyPage.Application.Models.MediumIntegration;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class PublicationsCacheService : IPublicationsCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string _key;
        private readonly int _cacheExpirationInDays;

        public PublicationsCacheService(Settings settings,
                                        IMemoryCache memoryCache)
        {
            _key = settings.PublicationsCacheKey;
            _cacheExpirationInDays = settings.CacheExpirationInDays;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<MediumPublicationModel>> GetOrCreate(Func<Task<IEnumerable<MediumPublicationModel>>> methodToCache)
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