using MyPage.Application.Data.Entities;
using MyPage.Application.Data.Repositories.Interfaces;
using MyPage.Application.Helpers;
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
            var courseCertificates = await _courseCertificateRepository.GetAll();
            var courseCertificateModels = courseCertificates.Select(x => new CourseCertificateModel(x)).ToList();
            return new CoursesPageModel(courseCertificateModels, currentLanguage);
        }

        public async Task<CourseCertificateModel> GetById(string id)
        {
            var entity = await _courseCertificateRepository.GetById(id);
            return new CourseCertificateModel(entity);
        }

        public async Task Add(CourseCertificateModel course)
        {
            await _courseCertificateRepository.Add(new CourseCertificate(course));
        }

        public async Task Update(CourseCertificateModel course)
        {
            await _courseCertificateRepository.Update(new CourseCertificate(course));
        }

        public async Task DeleteById(string id)
        {
            await _courseCertificateRepository.Delete(id);
        }

        public void ClearCoursesCache() => _coursesCacheService.ClearCache();
    }
}