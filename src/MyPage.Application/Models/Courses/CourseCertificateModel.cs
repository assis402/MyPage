using MyPage.Application.Data.Entities;
using MyPage.Application.Models.Enums;

namespace MyPage.Application.Models.Courses
{
    public class CourseCertificateModel
    {
        public CourseCertificateModel()
        {
            TitleDictionary = new Dictionary<Language, string>();
        }

        public CourseCertificateModel(CourseCertificate courseCertificateEntity)
        {
            Id = courseCertificateEntity.Id;
            TitleDictionary = courseCertificateEntity.TitleDictionary;
            WorkLoad = courseCertificateEntity.WorkLoad;
            ConclusionDate = courseCertificateEntity.ConclusionDate.ToDateTime();
            Tag = courseCertificateEntity.Tag;
            Platform = courseCertificateEntity.Platform;
            Instructor = courseCertificateEntity.Instructor;
            CourseUrl = courseCertificateEntity.CourseUrl;
            InstructorUrl = courseCertificateEntity.InstructorUrl;
            CertificateOriginalUrl = courseCertificateEntity.CertificateOriginalUrl;
            CertificateFullResolutionUrl = courseCertificateEntity.CertificateFullResolutionUrl;
            CertificateCardResolutionUrl = courseCertificateEntity.CertificateCardResolutionUrl;
        }

        public string Id { get; set; }

        public IDictionary<Language, string> TitleDictionary { get; set; }

        public string CurrentTitle { get; set; }

        public double? WorkLoad { get; set; }

        public DateTime ConclusionDate { get; set; }

        public string Tag { get; set; }

        public string Platform { get; set; }

        public string Instructor { get; set; }

        public string CourseUrl { get; set; }

        public string InstructorUrl { get; set; }

        public string CertificateOriginalUrl { get; set; }

        public string CertificateFullResolutionUrl { get; set; }

        public string CertificateCardResolutionUrl { get; set; }

        public string GetCertificateImgUrl()
        {
            return CertificateOriginalUrl ?? CertificateFullResolutionUrl;
        }

        public void SetTitleByLanguage(Language currentLanguage)
        {
            CurrentTitle = GetTitleByLanguage(currentLanguage);
        }

        public string GetTitleByLanguage(Language currentLanguage)
        {
            if (TitleDictionary.TryGetValue(currentLanguage, out string title))
                return title;
            else
                return null;
        }
    }
}