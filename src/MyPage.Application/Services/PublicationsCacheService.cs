using Microsoft.Extensions.Caching.Memory;
using MyPage.Application.Helpers;
using MyPage.Application.Models.MediumIntegration;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class PublicationsCacheService : MemoryCacheService<IEnumerable<MediumPublicationModel>>, IPublicationsCacheService
    {
        public PublicationsCacheService(Settings settings, IMemoryCache memoryCache)
            : base(settings.CacheSettings.PublicationsCacheKey, settings.CacheSettings.CacheExpirationInDays, memoryCache)
        { }
    }
}