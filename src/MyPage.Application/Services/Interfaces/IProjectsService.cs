using MyPage.Application.Models.Enums;
using MyPage.Application.Models.Pages;

namespace MyPage.Application.Services.Interfaces
{
    public interface IProjectsService
    {
        public Task<ProjectsPageModel> GetPortfolioProjects(Language currentLanguage);

        public void ClearPortfolioProjectsCache();

        public void ClearPortfolioTagsCache();

    }
}
