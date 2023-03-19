using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Models.GitHubIntegration
{
    public class GitHubResponseModel
    {
        public GitHubResponseModel(ICollection<GitHubRepositoryModel> repositoryList)
        {
            RepositoryList = repositoryList;
        }

        public ICollection<GitHubRepositoryModel> RepositoryList { get; set; }

        public ICollection<GitHubRepositoryModel> GetFilteredRepositoryListByTopic(string topic)
        {
            return RepositoryList.Where(repository => repository.Topics.Contains(topic))
                                 .OrderByDescending(repository => repository.CreatedAt)
                                 .ToList();
        }
    }
}
