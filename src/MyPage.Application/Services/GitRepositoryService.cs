using MyPage.Application.Helpers;
using MyPage.Application.Integrations.Interfaces;
using MyPage.Application.Models;
using MyPage.Application.Models.Enums;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class GitRepositoryService : IGitRepositoryService
    {
        private readonly Settings _settings;
        private readonly IGitHubIntegration _gitHubIntegration;

        public GitRepositoryService(IGitHubIntegration gitHubIntegration, Settings settings)
        {
            _gitHubIntegration = gitHubIntegration;
            _settings = settings;
        }

        public async Task<ICollection<GitHubRepositoryModel>> GetPortfolioRepositories(Language currentLanguage)
        {
            var repositories = await GetPortfolioRepositoriesFromGitHub();

            return null;
        }

        private async Task<ICollection<GitHubRepositoryModel>> GetPortfolioRepositoriesFromGitHub()
        {
            var repositories = await _gitHubIntegration.GetRepositories();
            repositories = repositories.Where(_ => _.Topic.Contains(_settings.GitHubSettings.TopicName))
                                       .OrderByDescending(_ => _.CreatedAt)
                                       .ToList();

            foreach (var repository in repositories)
            {
                var customProperties = await _gitHubIntegration.GetCustomPropertiesByRepository(repository.FullName);
                repository.CustomProperties = customProperties;
            }

            return repositories;
        }

        private async Task<ICollection<GitHubRepositoryModel>> GetPortfolioRepositoriesFromCache()
        {
            return null;
        }
    }
}
