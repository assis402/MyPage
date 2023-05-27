using Flurl.Http;
using MyPage.Application.Helpers;
using MyPage.Application.Integrations.Interfaces;
using MyPage.Application.Models.MediumIntegration;

namespace MyPage.Application.Integrations
{
    public class MediumIntegration : IMediumIntegration
    {
        private readonly string _mediumUrl;

        public MediumIntegration(Settings settings)
        {
            _mediumUrl = settings.MediumIntegrationUrl;
        }

        public async Task<IEnumerable<MediumPublicationModel>> GetPublications()
        {
            IEnumerable<MediumPublicationModel> publicationList = new List<MediumPublicationModel>();

            try
            {
                var rawResult = await _mediumUrl.GetJsonAsync<MediumResponseModel>();

                if (rawResult is not null)
                    publicationList = rawResult.Data.Posts.OrderByDescending(x => x.CreatedAt).Take(10);

                return publicationList;
            }
            catch (Exception ex)
            {
                return publicationList;
            }
        }
    }
}