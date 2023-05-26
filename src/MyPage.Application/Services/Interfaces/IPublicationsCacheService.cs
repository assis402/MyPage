using MyPage.Application.Models.MediumIntegration;

namespace MyPage.Application.Services.Interfaces
{
    public interface IPublicationsCacheService : IMemoryCacheService<IEnumerable<MediumPublicationModel>>
    {
    }
}