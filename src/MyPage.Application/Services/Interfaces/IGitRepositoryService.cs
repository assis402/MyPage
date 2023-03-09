using MyPage.Application.Models;
using MyPage.Application.Models.Enums;

namespace MyPage.Application.Services.Interfaces
{
    public interface IGitRepositoryService
    {
        public Task<ICollection<GitHubRepositoryModel>> GetPortfolioRepositories(Language currentLanguage);
    }
}
