using MyPage.Application.Models.Enums;
using MyPage.Application.Models.GitHubIntegration;

namespace MyPage.Application.Models.Pages
{
    public class CoursesPageModel
    {
        internal CoursesPageModel(ICollection<GitHubRepositoryModel> projectList, Language currentLanguage)
        {
            foreach (var project in projectList)
                project.SetDescriptionByLanguage(currentLanguage);

            ProjectList = projectList;
        }

        public ICollection<GitHubRepositoryModel> ProjectList { get; private set; }
    }
}