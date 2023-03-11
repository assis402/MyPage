using Flurl.Http;
using MyPage.Application.Models;

namespace MyPage.Application.Integrations.Interfaces
{
    public interface IGitHubIntegration
    {
        public Task Login();

        public Task<ICollection<GitHubRepositoryModel>> GetRepositories();

        public Task<CustomPropertiesModel> GetCustomPropertiesByRepository(string repositoryFullName);
    }
}
