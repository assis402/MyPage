using MyPage.Application.Models.MediumIntegration;

namespace MyPage.Application.Models.Pages
{
    public class AboutPageModel
    {
        public AboutPageModel(IEnumerable<MediumPublicationModel> projectList)
        {
            PublicationList = projectList;
        }

        public IEnumerable<MediumPublicationModel> PublicationList { get; private set; }
    }
}