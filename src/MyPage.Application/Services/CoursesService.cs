using MyPage.Application.Data.Entities;
using MyPage.Application.Data.Repositories.Interfaces;
using MyPage.Application.Models.Courses;
using MyPage.Application.Models.Enums;
using MyPage.Application.Models.Pages;
using MyPage.Application.Services.Interfaces;

namespace MyPage.Application.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesCacheService _coursesCacheService;
        private readonly ICourseCertificateRepository _courseCertificateRepository;

        public CoursesService(ICoursesCacheService coursesCacheService,
            ICourseCertificateRepository courseCertificateRepository)
        {
            _coursesCacheService = coursesCacheService;
            _courseCertificateRepository = courseCertificateRepository;
        }

        public async Task<CoursesPageModel> GetCoursesPageModel(Language currentLanguage)
        {
            var courseCertificateModels = await GetAllFromCache();
            return new CoursesPageModel(courseCertificateModels, currentLanguage);
        }

        public async Task<ICollection<CourseCertificateModel>> GetAllFromCache()
        {
            return await _coursesCacheService.GetOrCreate(GetAll);
        }

        public async Task<ICollection<CourseCertificateModel>> GetAll()
        {
            var courseCertificates = await _courseCertificateRepository.GetAll();
            return courseCertificates.Select(x => new CourseCertificateModel(x)).ToList();
        }

        public async Task<CourseCertificateModel> GetById(string id)
        {
            var entity = await _courseCertificateRepository.GetById(id);
            return new CourseCertificateModel(entity);
        }

        public async Task Add(CourseCertificateModel course)
        {
            await _courseCertificateRepository.Add(new CourseCertificate(course));
            ClearCoursesCache();
        }

        public async Task Update(CourseCertificateModel course)
        {
            await _courseCertificateRepository.Update(new CourseCertificate(course));
            ClearCoursesCache();
        }

        public async Task DeleteById(string id)
        {
            await _courseCertificateRepository.Delete(id);
            ClearCoursesCache();
        }

        public void ClearCoursesCache() => _coursesCacheService.ClearCache();
    }
}