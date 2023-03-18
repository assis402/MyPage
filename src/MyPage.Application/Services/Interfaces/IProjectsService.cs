using MyPage.Application.Models;
using MyPage.Application.Models.Enums;

namespace MyPage.Application.Services.Interfaces
{
    public interface IProjectsService
    {
        public Task<ProjectsPageModel> GetPortfolioRepositories(Language currentLanguage);

        public void ClearPortfolioRepositoriesCache();
    }
}
