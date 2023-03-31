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

        public ICollection<TagModel> TagList { get; private set; }

        public ICollection<GitHubRepositoryModel> ProjectList { get; private set; }

        internal async Task<IEnumerable<string>> GetUncachedTagList()
        {
            return await Task.FromResult(ProjectList.SelectMany(_ => _.CustomProperties.Tags));
        }

        internal void SetTagList(IEnumerable<string> tagList)
        {
            TagList = tagList.Select(tagName => new TagModel(false, tagName)).ToList();
        }

        internal void FilterProjectListBySearchFilter(string searchString)
        {
            ProjectList = ProjectList.Where(project => project.Contains(searchString)).ToList();
        }

        internal void FilterProjectListByTagFilter(string tagFilter)
        {
            var tags = tagFilter.Split();

            ProjectList = ProjectList.Where(project => project.Contains(tagFilter)).ToList();
        }
    }
}
