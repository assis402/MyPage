using MyPage.Application.Helpers;
using MyPage.Application.Models.MediumIntegration;
using System.Globalization;

namespace MyPage.Application.Models.Pages
{
    public class AboutPageModel
    {
        public AboutPageModel(IEnumerable<MediumPublicationModel> projectList)
        {
            PublicationList = projectList;

            var beginOfCarreer = DateTime.Parse(BEGIN_OF_CARREER, CultureInfo.InvariantCulture);
            var careerPeriodInMonths = Utils.MonthDifference(beginOfCarreer, DateTime.Now);

            WorkYears = careerPeriodInMonths / 12;
            WorkMonths = careerPeriodInMonths % 12;
        }

        public IEnumerable<MediumPublicationModel> PublicationList { get; private set; }

        public int WorkYears { get; private set; }

        public int WorkMonths { get; private set; }

        private const string BEGIN_OF_CARREER = "11/1/2020";
    }
}