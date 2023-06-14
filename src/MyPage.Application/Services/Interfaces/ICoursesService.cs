using MyPage.Application.Models.Courses;
using MyPage.Application.Models.Enums;
using MyPage.Application.Models.Pages;

namespace MyPage.Application.Services.Interfaces
{
    public interface ICoursesService
    {
        public Task<CoursesPageModel> GetCoursesPageModel(Language currentLanguage);

        public Task InsertCourse(CourseCertificateModel course);

        public void ClearCoursesCache();
    }
}