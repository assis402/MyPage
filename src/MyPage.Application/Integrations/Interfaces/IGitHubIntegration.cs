using Flurl.Http;
using MyPage.Application.Models.GitHubIntegration;

namespace MyPage.Application.Integrations.Interfaces
{
    public interface IGitHubIntegration
    {
        public Task Login();

        public Task<GitHubDataModel> GetGitHubDataByRepositoryTopicName(string topicName);
    }
}
