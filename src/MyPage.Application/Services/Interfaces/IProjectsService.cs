using MyPage.Application.Models.Enums;
using MyPage.Application.Models.Pages;

namespace MyPage.Application.Services.Interfaces
{
    public interface IProjectsService
    {
        public Task<ProjectsPageModel> GetPortfolioProjectsByLanguageAndFilter(Language currentLanguage, string searchFilter, string tagFilter);

        public void ClearPortfolioProjectsCache();

        public void ClearPortfolioTagsCache();
    }
}