using MyPage.Application.Models.Courses;
using MyPage.Application.Models.Enums;
using MyPage.Application.Models.Pages;

namespace MyPage.Application.Services.Interfaces
{
    public interface ICoursesService
    {
        public Task<CoursesPageModel> GetCoursesPageModel(Language currentLanguage);

        public Task<CourseCertificateModel> GetById(string id);

        public Task Add(CourseCertificateModel course);

        public Task Update(CourseCertificateModel course);

        public Task DeleteById(string id);

        public void ClearCoursesCache();
    }
}