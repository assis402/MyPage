using Google.Cloud.Firestore;
using MyPage.Application.CustomAttributes;
using MyPage.Application.Helpers;
using MyPage.Application.Models.Courses;
using MyPage.Application.Models.Enums;

namespace MyPage.Application.Data.Entities
{
    [FirestoreData]
    [Collection("courseCertificates")]
    public class CourseCertificate : BaseEntity
    {
        public CourseCertificate()
        {
            TitleDictionary = new Dictionary<Language, string>();
        }

        public CourseCertificate(CourseCertificateModel courseInsertModel)
        {
            TitleDictionary = courseInsertModel.TitleDictionary;
            WorkLoad = courseInsertModel.WorkLoad.Value;
            //ConclusionDate = Timestamp.FromDateTime(courseInsertModel.ConclusionDate);
            ConclusionDate = courseInsertModel.ConclusionDate.ToUniversalTime();
            Tag = courseInsertModel.Tag;
            Platform = courseInsertModel.Platform;
            Instructor = courseInsertModel.Instructor;
            CourseUrl = courseInsertModel.CourseUrl;
            InstructorUrl = courseInsertModel.InstructorUrl;
            CertificateOriginalUrl = courseInsertModel.CertificateOriginalUrl;
            CertificateFullResolutionUrl = courseInsertModel.CertificateFullResolutionUrl;
            CertificateCardResolutionUrl = courseInsertModel.CertificateCardResolutionUrl;
        }

        public IDictionary<Language, string> TitleDictionary { get; set; }

        [FirestoreProperty]
        public string FirestoreTitleDictionary
        {
            get { return TitleDictionary.ToJson(); }
            set { TitleDictionary = value.ToObject<IDictionary<Language, string>>(); }
        }

        [FirestoreProperty]
        public double WorkLoad { get; set; }

        [FirestoreProperty]
        public DateTime ConclusionDate { get; set; }
        //public Timestamp ConclusionDate { get; set; }

        [FirestoreProperty]
        public string Tag { get; set; }

        [FirestoreProperty]
        public string Platform { get; set; }

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
    }
}