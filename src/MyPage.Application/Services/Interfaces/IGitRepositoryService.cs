using MyPage.Application.Models;

namespace MyPage.Application.Services.Interfaces
{
    public interface IGitRepositoryService
    {
        public Task<GitHubRepositoryModel> GetPortfolioRepositories();
    }
}
