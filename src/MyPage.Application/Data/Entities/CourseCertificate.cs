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
        public CourseCertificate()
        {
            TitleDictionary = new Dictionary<int, string>();
        }

        public CourseCertificate(CourseCertificateModel courseInsertModel)
        {
            var dictionary = new Dictionary<int, string>();

            foreach (var item in courseInsertModel.TitleDictionary)
                dictionary.Add((int)item.Key, item.Value);

            TitleDictionary = dictionary;
            WorkLoad = courseInsertModel.WorkLoad.Value;
            ConclusionDate = courseInsertModel.ConclusionDate;
            Tag = courseInsertModel.Tag;
            Platform = courseInsertModel.Platform;
            Instructor = courseInsertModel.Instructor;
            CourseUrl = courseInsertModel.CourseUrl;
            InstructorUrl = courseInsertModel.InstructorUrl;
            CertificateOriginalUrl = courseInsertModel.CertificateOriginalUrl;
            CertificateFullResolutionUrl = courseInsertModel.CertificateFullResolutionUrl;
            CertificateCardResolutionUrl = courseInsertModel.CertificateCardResolutionUrl;
        }

        [FirestoreProperty]
        public IDictionary<int, string> TitleDictionary { get; set; }

        [FirestoreProperty]
        public double WorkLoad { get; set; }

        [FirestoreProperty]
        public DateTime ConclusionDate { get; set; }

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