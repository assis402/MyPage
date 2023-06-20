using MyPage.Application.Integrations.Interfaces;
using MyPage.Application.Models.Enums;
using MyPage.Application.Models.Pages;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class AboutService : IAboutService
    {
        private readonly IPublicationsCacheService _publicationsCacheService;
        private readonly IMediumIntegration _mediumIntegration;
        private readonly ICoursesService _coursesService;

        public AboutService(IPublicationsCacheService publicationsCacheService,
                            IMediumIntegration mediumIntegration,
                            ICoursesService coursesService)
        {
            _publicationsCacheService = publicationsCacheService;
            _mediumIntegration = mediumIntegration;
            _coursesService = coursesService;
        }

        public async Task<AboutPageModel> GetAboutPageModel(Language currentLanguage)
        {
            var publicationList = await _publicationsCacheService.GetOrCreate(_mediumIntegration.GetPublications);
            var courseList = await _coursesService.GetAllFromCache();
            return new AboutPageModel(publicationList, courseList, currentLanguage);
        }

        public void ClearPublicationsCache() => _publicationsCacheService.ClearCache();
    }
}