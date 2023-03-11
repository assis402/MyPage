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
            _userToken = _settings.GitHubSettings.Token;
        }

        public async Task Login()
        {
            var loginUrl = _settings.GitHubSettings.LoginUrl;
            await GetRequestClient(loginUrl).GetJsonAsync();
        }

        public async Task<ICollection<GitHubRepositoryModel>> GetRepositories()
        {
            var reposUrl = _settings.GitHubSettings.ReposUrl;
            return await GetRequestClient(reposUrl).GetJsonAsync<ICollection<GitHubRepositoryModel>>();
        }

        public async Task<CustomPropertiesModel> GetCustomPropertiesByRepository(string repositoryFullName)
        {
            var url = _settings.GitHubSettings.RawBaseUrl + repositoryFullName + _settings.GitHubSettings.CustomPropertiesPath;
            var test = await url.GetJsonAsync();
            return await url.GetJsonAsync<CustomPropertiesModel>();
        }

        private IFlurlRequest GetRequestClient(string url)
        {
            return url.WithHeader("Authorization", _userToken)
                      .WithHeader("User-Agent", "MyPageUI")
                      .WithHeader("Accept", "application/vnd.github+json")
                      .WithHeader("X-GitHub-Api-Version", "2022-11-28");
        }
    }
}
