using Microsoft.Extensions.Caching.Memory;
using MyPage.Application.Helpers;
using MyPage.Application.Integrations.Interfaces;
using MyPage.Application.Models;
using MyPage.Application.Models.Enums;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly Settings _settings;
        private readonly IGitHubIntegration _gitHubIntegration;
        private readonly IMemoryCache _memoryCache;

        public PortfolioService(Settings settings,
                                IGitHubIntegration gitHubIntegration,
                                IMemoryCache memoryCache)
        {
            _settings = settings;
            _gitHubIntegration = gitHubIntegration;
            _memoryCache = memoryCache;
        }
        
        public async Task<ICollection<GitHubRepositoryModel>> GetPortfolioRepositories(Language currentLanguage)
        {
            var projectList = await GetPortfolioRepositoriesFromCache();

            foreach (var project in projectList)
                project.SetDescriptionByLanguage(currentLanguage);

            return projectList;
        }

        private async Task<ICollection<GitHubRepositoryModel>> GetPortfolioRepositoriesFromGitHub()
        {
            var repositoryList = await _gitHubIntegration.GetRepositories();
            repositoryList = repositoryList.Where(repository => repository.Topics.Contains(_settings.GitHubSettings.TopicName))
                                            .OrderByDescending(repository => repository.CreatedAt)
                                            .ToList();

            foreach (var repository in repositoryList)
            {
                var customProperties = await _gitHubIntegration.GetCustomPropertiesByRepository(repository.FullName);
                repository.CustomProperties = customProperties;
            }

            return repositoryList;
        }

        private async Task<ICollection<GitHubRepositoryModel>> GetPortfolioRepositoriesFromCache()
        {
            return await _memoryCache.GetOrCreateAsync(_settings.CacheKey, async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(_settings.DaysToCacheExpiration);
                cacheEntry.SetPriority(CacheItemPriority.High);
                return await GetPortfolioRepositoriesFromGitHub();
            });
        }

        public void ClearPortfolioRepositoriesCache() => _memoryCache.Remove(_settings.CacheKey);
    }
}
