using MyPage.Application.Models.GitHubIntegration;

namespace MyPage.Application.Services.Interfaces
{
    public interface IProjectsCacheService : IMemoryCacheService<ICollection<GitHubRepositoryModel>>
    {
    }
}