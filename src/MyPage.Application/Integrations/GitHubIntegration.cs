using Flurl.Http;
using MyPage.Application.Models;
using MyPage.Application.Helpers;

namespace MyPage.Application.Integrations
{
    public class GitHubIntegration
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
            await loginUrl.WithHeader("Accept", "application/vnd.github+json")
                          .WithHeader("Authorization", _userToken)
                          .GetJsonAsync();
        }

        public async Task<List<GitHubRepositoryModel>> GetRepositories()
        {
            var reposUrl = _settings.GitHubSettings.GitHubReposUrl;

            return await reposUrl.WithHeader("Accept", "application/vnd.github+json")
                                 .GetJsonAsync<List<GitHubRepositoryModel>>();
        }

        public async Task<CustomPropertiesModel> GetCustomPropertiesByRepositoryUrl(string repositoryUrl)
        {
            var url = $"{repositoryUrl}/blob/master/mypage-props.json";
            return await url.GetJsonAsync<CustomPropertiesModel>();
        }
    }
}
