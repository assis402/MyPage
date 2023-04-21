using Flurl.Http;
using MyPage.Application.Helpers;
using MyPage.Application.Integrations.Interfaces;
using MyPage.Application.Models.GitHubIntegration;

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

        public async Task<GitHubDataModel> GetGitHubDataByRepositoryTopicName(string topicName)
        {
            var repositoryList = await GetRepositories();
            var gitHubDataModel = new GitHubDataModel(repositoryList);

            gitHubDataModel.FilterRepositoryListByTopic(topicName);
            await gitHubDataModel.SetRepositoriesCustomProperties(GetCustomPropertiesByRepository);

            return gitHubDataModel;
        }

        private async Task<ICollection<GitHubRepositoryModel>> GetRepositories()
        {
            var reposUrl = _settings.GitHubSettings.ReposUrl;
            var repositoryList = await GetRequestClient(reposUrl).GetJsonAsync<ICollection<GitHubRepositoryModel>>();

            return repositoryList;
        }

        private async Task<GitHubCustomPropertiesModel> GetCustomPropertiesByRepository(string repositoryFullName)
        {
            var url = _settings.GitHubSettings.RawBaseUrl + repositoryFullName + _settings.GitHubSettings.CustomPropertiesPath;
            return await url.GetJsonAsync<GitHubCustomPropertiesModel>();
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