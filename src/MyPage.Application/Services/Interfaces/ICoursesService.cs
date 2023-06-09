using MyPage.Application.Models.Enums;
using MyPage.Application.Models.Pages;

namespace MyPage.Application.Services.Interfaces
{
    public interface ICoursesService
    {
        public Task<CoursesPageModel> GetAll(Language currentLanguage);

        public void ClearCoursesCache();
    }
}