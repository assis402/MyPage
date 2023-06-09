using Google.Cloud.Firestore;
using MyPage.Application.Models.Enums;

namespace MyPage.Application.Data.Entities
{
    [FirestoreData]
    public class CourseCertificate
    {
        public string Id { get; set; }

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
    }
}