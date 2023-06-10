using MyPage.Application.Models.Courses;
using MyPage.Application.Models.Enums;
using MyPage.Application.Models.Pages;

namespace MyPage.Application.Services.Interfaces
{
    public interface ICoursesService
    {
        public Task<CoursesPageModel> GetCourses(Language currentLanguage);

        public Task InsertCourse(CourseInsertModel course);

        public void ClearCoursesCache();
    }
}