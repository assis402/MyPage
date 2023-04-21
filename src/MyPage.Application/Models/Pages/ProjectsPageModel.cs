using MyPage.Application.Models.Enums;
using MyPage.Application.Models.GitHubIntegration;

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
            TagList = tagList.Distinct().Select(tagName => new TagModel(false, tagName)).ToList();
        }

        internal void FilterProjectListBySearchFilter(string searchString)
        {
            ProjectList = ProjectList.Where(project => project.Contains(searchString)).ToList();
        }

        internal void FilterProjectListByTagFilter(string tagFilter)
        {
            var selectedTags = tagFilter.Split(";", StringSplitOptions.RemoveEmptyEntries);

            SetSelectedTags(selectedTags);
            ProjectList = ProjectList.Where(project => project.CustomProperties.Tags.Any(tag => selectedTags.Contains(tag))).ToList();
        }

        private void SetSelectedTags(string[] selectedTags)
        {
            foreach (var tag in TagList.Where(tag => selectedTags.Contains(tag.TagName)))
            {
                tag.ToggleSelectedToFilter();
            }
        }
    }
}