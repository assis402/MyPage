using MyPage.Application.Data.Entities;
using MyPage.Application.Models.Enums;
using MyPage.Application.Models.GitHubIntegration;

namespace MyPage.Application.Models.Pages
{
    public class CoursesPageModel
    {
        public CoursesPageModel(ICollection<CourseCertificate> courseCertificateList, Language currentLanguage)
        {
            foreach (var courseCertificate in courseCertificateList)
                courseCertificate.SetTitleByLanguage(currentLanguage);

            CourseCertificateList = courseCertificateList;
        }

        public ICollection<CourseCertificate> CourseCertificateList { get; private set; }
    }
}