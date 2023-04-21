using Microsoft.Extensions.Caching.Memory;
using MyPage.Application.Helpers;
using MyPage.Application.Models.GitHubIntegration;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class ProjectsCacheService : IMemoryCacheService<ICollection<GitHubRepositoryModel>>
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string _key;
        private readonly int _cacheExpirationInDays;

        public ProjectsCacheService(Settings settings,
                                    IMemoryCache memoryCache)
        {
            _key = settings.ProjectsCacheKey;
            _cacheExpirationInDays = settings.CacheExpirationInDays;
            _memoryCache = memoryCache;
        }

        public async Task<ICollection<GitHubRepositoryModel>> GetOrCreate(Func<Task<ICollection<GitHubRepositoryModel>>> methodToCache)
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