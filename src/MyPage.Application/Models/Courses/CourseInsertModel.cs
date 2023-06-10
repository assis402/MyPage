using Google.Cloud.Firestore;
using MyPage.Application.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Models.Courses
{
    public class CourseInsertModel
    {
        public IDictionary<Language, string> TitleDictionary { get; set; }

        public double workLoad { get; set; }

        public DateTime ConclusionDate { get; set; }

        public string Tag { get; set; }

        public string Instructor { get; set; }

        public string CourseUrl { get; set; }

        public string InstructorUrl { get; set; }

        public string CertificateOriginalUrl { get; set; }

        public string CertificateFullResolutionUrl { get; set; }

        public string CertificateCardResolutionUrl { get; set; }
    }
}
