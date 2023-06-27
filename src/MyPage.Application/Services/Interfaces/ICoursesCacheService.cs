using MyPage.Application.Models.Courses;

namespace MyPage.Application.Services.Interfaces
{
    public interface ICoursesCacheService : IMemoryCacheService<ICollection<CourseCertificateModel>>
    {
    }
}