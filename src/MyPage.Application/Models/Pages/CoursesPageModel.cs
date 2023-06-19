using MyPage.Application.Models.Courses;
using MyPage.Application.Models.Enums;

namespace MyPage.Application.Models.Pages
{
    public class CoursesPageModel
    {
        public CoursesPageModel(ICollection<CourseCertificateModel> courseCertificateList, Language currentLanguage)
        {
            foreach (var courseCertificate in courseCertificateList)
                courseCertificate.SetTitleByLanguage(currentLanguage);

            CourseCertificateList = courseCertificateList;
        }

        public ICollection<CourseCertificateModel> CourseCertificateList { get; private set; }
    }
}