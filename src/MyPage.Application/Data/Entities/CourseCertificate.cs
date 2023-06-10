using Google.Cloud.Firestore;
using MyPage.Application.CustomAttributes;
using MyPage.Application.Models.Courses;
using MyPage.Application.Models.Enums;

namespace MyPage.Application.Data.Entities
{
    [FirestoreData]
    [Collection("courseCertificates")]
    public class CourseCertificate : BaseEntity
    {
        public CourseCertificate(CourseInsertModel courseInsertModel)
        {
            TitleDictonary = courseInsertModel.TitleDictionary;
            WorkLoad = courseInsertModel.workLoad;
            ConclusionDate = courseInsertModel.ConclusionDate;
            Tag = courseInsertModel.Tag;
            Instructor = courseInsertModel.Instructor;
            CourseUrl = courseInsertModel.CourseUrl;
            InstructorUrl = courseInsertModel.InstructorUrl;
            CertificateOriginalUrl = courseInsertModel.CertificateOriginalUrl;
            CertificateFullResolutionUrl = courseInsertModel.CertificateFullResolutionUrl;
            CertificateCardResolutionUrl = courseInsertModel.CertificateCardResolutionUrl;
        }

        public string Title { get; set; }

        [FirestoreProperty]
        public IDictionary<Language, string> TitleDictonary { get; set; }

        [FirestoreProperty]
        public double WorkLoad { get; set; }

        [FirestoreProperty]
        public DateTime ConclusionDate { get; set; }

        [FirestoreProperty]
        public string Tag { get; set; }

        [FirestoreProperty]
        public string Instructor { get; set; }

        [FirestoreProperty]
        public string CourseUrl { get; set; }

        [FirestoreProperty]
        public string InstructorUrl { get; set; }

        [FirestoreProperty]
        public string CertificateOriginalUrl { get; set; }

        [FirestoreProperty]
        public string CertificateFullResolutionUrl { get; set; }

        [FirestoreProperty]
        public string CertificateCardResolutionUrl { get; set; }

        public void SetTitleByLanguage(Language currentLanguage)
        {
            if (TitleDictonary.TryGetValue(currentLanguage, out string title))
                Title = title;
        }
    }
}