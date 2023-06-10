namespace MyPage.Application.Helpers
{
    public class Settings
    {
        public string ProjectsCacheKey { get; set; }

        public string TagsCacheKey { get; set; }

        public string PublicationsCacheKey { get; set; }

        public string CoursesCacheKey { get; set; }

        public int CacheExpirationInDays { get; set; }

        public GitHubSettings GitHubSettings { get; set; }

        public string MediumIntegrationUrl { get; set; }

        public string MediumUserUrl { get; set; }

        public string FirebaseProjectId { get; set; }
    }
}