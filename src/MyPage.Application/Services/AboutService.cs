using MyPage.Application.Integrations.Interfaces;
using MyPage.Application.Models.Pages;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class AboutService : IAboutService
    {
        private readonly IPublicationsCacheService _publicationsCacheService;
        private readonly IMediumIntegration _mediumIntegration;

        public AboutService(IPublicationsCacheService publicationsCacheService,
                            IMediumIntegration mediumIntegration)
        {
            _publicationsCacheService = publicationsCacheService;
            _mediumIntegration = mediumIntegration;
        }

        public async Task<AboutPageModel> GetAboutPageModel()
        {
            var publicationList = await _publicationsCacheService.GetOrCreate(_mediumIntegration.GetPublications);
            return new AboutPageModel(publicationList);
        }

        public void ClearPublicationsCache() => _publicationsCacheService.ClearCache();
    }
}