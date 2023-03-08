﻿using MyPage.Application.Models;
using MyPage.Application.Integrations;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class GitRepositoryService : IGitRepositoryService
    {
        private readonly GitHubIntegration _gitHubIntegration;

        public GitRepositoryService(GitHubIntegration gitHubIntegration)
        {
            _gitHubIntegration = gitHubIntegration;
        }

        public async Task<GitHubRepositoryModel> GetPortfolioRepositories()
        {
            var repositories = await _gitHubIntegration.GetRepositories();
            repositories = repositories.Where(_ => _.Topic.Contains("mypage")).ToList();

            foreach (var repository in repositories)
            {
                var customProperties = await _gitHubIntegration.GetCustomPropertiesByRepositoryUrl(repository.Url);
                
            }

            return null;
        }
    }
}
