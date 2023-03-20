using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Models.GitHubIntegration
{
    public class GitHubDataModel
    {
        public GitHubDataModel(ICollection<GitHubRepositoryModel> repositoryList)
        {
            RepositoryList = repositoryList;
        }

        public ICollection<GitHubRepositoryModel> RepositoryList { get; set; }

        public void FilterRepositoryListByTopic(string topic)
        {
            RepositoryList = RepositoryList.Where(repository => repository.Topics.Contains(topic))
                                           .OrderByDescending(repository => repository.CreatedAt)
                                           .ToList();
        }

        public async Task SetRepositoriesCustomProperties(Func<string, Task<GitHubCustomPropertiesModel>> getCustomPropertiesMethod)
        {
            foreach (var repository in RepositoryList)
            {
                var customProperties = await getCustomPropertiesMethod(repository.FullName);
                repository.CustomProperties = customProperties;
            }
        }
    }
}
