﻿using MyPage.Application.Helpers;
using MyPage.Application.Integrations.Interfaces;
using MyPage.Application.Models.Enums;
using MyPage.Application.Models.GitHubIntegration;
using MyPage.Application.Models.Pages;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly Settings _settings;
        private readonly IGitHubIntegration _gitHubIntegration;
        private readonly IProjectsCacheService _projectsCacheService;
        private readonly ITagsCacheService _tagsCacheService;

        public ProjectsService(Settings settings,
                               IGitHubIntegration gitHubIntegration,
                               IProjectsCacheService projectsCacheService,
                               ITagsCacheService tagsCacheService)
        {
            _settings = settings;
            _gitHubIntegration = gitHubIntegration;
            _projectsCacheService = projectsCacheService;
            _tagsCacheService = tagsCacheService;
        }

        public async Task<ProjectsPageModel> GetPortfolioProjectsByLanguageAndFilter(Language currentLanguage, string searchFilter, string tagFilter)
        {
            var projectList = await GetPortfolioProjectsFromCache();
            var projectsPageModel = new ProjectsPageModel(projectList, currentLanguage);

            var tagList = await GetPortfolioTagsFromCache(projectsPageModel);
            projectsPageModel.SetTagList(tagList);

            if (searchFilter.IsNotNullAndNotEmpty())
                projectsPageModel.FilterProjectListBySearchFilter(searchFilter);

            if (tagFilter.IsNotNullAndNotEmpty())
                projectsPageModel.FilterProjectListByTagFilter(tagFilter);

            return projectsPageModel;
        }

        private async Task<ICollection<GitHubRepositoryModel>> GetPortfolioProjectsFromCache()
            => await _projectsCacheService.GetOrCreate(GetPortfolioProjectsFromGitHub);

        private async Task<IEnumerable<string>> GetPortfolioTagsFromCache(ProjectsPageModel projectsPageModel)
            => await _tagsCacheService.GetOrCreate(projectsPageModel.GetUncachedTagList);

        public void ClearPortfolioProjectsCache() => _projectsCacheService.ClearCache();

        public void ClearPortfolioTagsCache() => _tagsCacheService.ClearCache();

        private async Task<ICollection<GitHubRepositoryModel>> GetPortfolioProjectsFromGitHub()
        {
            var gitHubDataModel = await _gitHubIntegration.GetGitHubDataByRepositoryTopicName(_settings.GitHubSettings.TopicName);
            return gitHubDataModel.RepositoryList;
        }
    }
}