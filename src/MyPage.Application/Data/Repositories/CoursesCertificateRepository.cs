using MyPage.Application.Data.Entities;
using MyPage.Application.Data.Repositories.Interfaces;

namespace MyPage.Application.Data.Repositories
{
    public class CoursesCertificateRepository : BaseRepository<CourseCertificate>, ICourseCertificateRepository
    {
        public CoursesCertificateRepository(MyPageContextDb myPageContextDb) : base(myPageContextDb)
        {
        }
    }
}