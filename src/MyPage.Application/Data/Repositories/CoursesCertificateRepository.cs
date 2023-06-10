using MyPage.Application.Data.Entities;
using MyPage.Application.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Data.Repositories
{
    public class CoursesCertificateRepository : BaseRepository<CourseCertificate>, ICourseCertificateRepository
    {
        public CoursesCertificateRepository(MyPageContextDb myPageContextDb) : base(myPageContextDb)
        {
        }
    }
}
