using MyPage.Application.Helpers;
using MyPage.Application.Models.Courses;
using MyPage.Application.Models.Enums;
using MyPage.Application.Models.MediumIntegration;
using System.Globalization;

namespace MyPage.Application.Models.Pages
{
    public class AboutPageModel
    {
        public AboutPageModel(IEnumerable<MediumPublicationModel> projectList, ICollection<CourseCertificateModel> courseCertificateList, Language currentLanguage)
        {
            var beginOfCarreer = DateTime.Parse(BEGIN_OF_CARREER, CultureInfo.InvariantCulture);
            var careerPeriodInMonths = Utils.MonthDifference(beginOfCarreer, DateTime.Now);

            WorkYears = careerPeriodInMonths / 12;
            WorkMonths = careerPeriodInMonths % 12;

            PublicationList = projectList;

            foreach (var courseCertificate in courseCertificateList)
                courseCertificate.SetTitleByLanguage(currentLanguage);

            CourseCertificateList = courseCertificateList;
        }

        public IEnumerable<MediumPublicationModel> PublicationList { get; private set; }

        public ICollection<CourseCertificateModel> CourseCertificateList { get; private set; }

        public int WorkYears { get; private set; }

        public int WorkMonths { get; private set; }

        private const string BEGIN_OF_CARREER = "11/1/2020";
    }
}