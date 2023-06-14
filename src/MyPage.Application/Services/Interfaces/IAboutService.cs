using MyPage.Application.Models.Pages;

namespace MyPage.Application.Services.Interfaces
{
    public interface IAboutService
    {
        public Task<AboutPageModel> GetAboutPageModel();

        public void ClearPublicationsCache();
    }
}