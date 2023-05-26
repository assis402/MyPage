using MyPage.Application.Models.MediumIntegration;

namespace MyPage.Application.Integrations.Interfaces
{
    public interface IMediumIntegration
    {
        public Task<IEnumerable<MediumPublicationModel>> GetPublications();
    }
}