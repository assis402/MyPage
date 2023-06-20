using MyPage.Application.Models.Enums;
using MyPage.Application.Models.Pages;

namespace MyPage.Application.Services.Interfaces
{
    public interface IAboutService
    {
        public Task<AboutPageModel> GetAboutPageModel(Language currentLanguage);

        public void ClearPublicationsCache();
    }
}