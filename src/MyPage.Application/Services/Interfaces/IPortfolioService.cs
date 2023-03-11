using MyPage.Application.Models;
using MyPage.Application.Models.Enums;

namespace MyPage.Application.Services.Interfaces
{
    public interface IPortfolioService
    {
        public Task<ICollection<GitHubRepositoryModel>> GetPortfolioRepositories(Language currentLanguage);

        public void ClearPortfolioRepositoriesCache();
    }
}
