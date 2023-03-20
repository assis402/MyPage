using MyPage.Application.Models.Enums;
using MyPage.Application.Models.GitHubIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Models.Pages
{
    public class ProjectsPageModel
    {
        internal ProjectsPageModel(ICollection<GitHubRepositoryModel> projectList, Language currentLanguage)
        {
            foreach (var project in projectList)
                project.SetDescriptionByLanguage(currentLanguage);

            ProjectList = projectList;
        }

        public ICollection<GitHubRepositoryModel> ProjectList { get; private set; }

        public IEnumerable<string> TagList { get; private set; }

        internal async Task<IEnumerable<string>> GetUncachedTagList()
        {
            return await Task.FromResult(ProjectList.SelectMany(_ => _.CustomProperties.Tags));
        }

        internal void SetTagList(IEnumerable<string> tagList) => TagList = tagList;

        internal void FilterProjectListByCurrentFilter(string searchString)
        {
            ProjectList = ProjectList.Where(project => project.Contains(searchString)).ToList();
        }

    }
}
