using Microsoft.Extensions.Caching.Memory;
using MyPage.Application.Helpers;
using MyPage.Application.Models.GitHubIntegration;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class ProjectsCacheService : MemoryCacheService<ICollection<GitHubRepositoryModel>>, IProjectsCacheService
    {
        public ProjectsCacheService(Settings settings, IMemoryCache memoryCache)
            : base(settings.CacheSettings.ProjectsCacheKey, settings.CacheSettings.CacheExpirationInDays, memoryCache)
        { }
    }
}