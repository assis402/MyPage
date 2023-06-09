using MyPage.Application.Data.Entities;

namespace MyPage.Application.Services.Interfaces
{
    public interface ICoursesCacheService : IMemoryCacheService<ICollection<CourseCertificate>>
    {
    }
}