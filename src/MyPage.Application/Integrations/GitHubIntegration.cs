using Flurl.Http;
using MyPage.Application.Models;
using MyPage.Application.Helpers;
using MyPage.Application.Integrations.Interfaces;

namespace MyPage.Application.Integrations
{
    public class GitHubIntegration : IGitHubIntegration
    {
        private readonly Settings _settings;
        private readonly string _userToken;

        public GitHubIntegration(Settings settings)
        {
            _settings = settings;
            _userToken = _settings.GitHubSettings.GitHubToken;
        }

        public async Task Login()
        {
            var loginUrl = _settings.GitHubSettings.GitHubLoginUrl;
            await GetRequestClient(loginUrl).GetJsonAsync();
        }

        public async Task<List<GitHubRepositoryModel>> GetRepositories()
        {
            var reposUrl = _settings.GitHubSettings.GitHubReposUrl;
            return await GetRequestClient(reposUrl).GetJsonAsync<List<GitHubRepositoryModel>>();
        }

        public async Task<CustomPropertiesModel> GetCustomPropertiesByRepositoryUrl(string repositoryUrl)
        {
            var url = $"{repositoryUrl}/blob/master/mypage-props.json";
            return await url.GetJsonAsync<CustomPropertiesModel>();
        }

        private IFlurlRequest GetRequestClient(string url)
        {
            return url.WithHeader("Accept", "application/vnd.github+json")
                      .WithHeader("X-GitHub-Api-Version", "2022-11-28")
                      .WithHeader("Authorization", _userToken);
        }
    }
}
