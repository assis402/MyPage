namespace MyPage.Application.Helpers
{
    public class CacheSettings
    {
        public string TagsCacheKey { get; init; }
        public string ProjectsCacheKey { get; init; }
        public string PublicationsCacheKey { get; init; }
        public string CoursesCacheKey { get; init; }
        public int CacheExpirationInDays { get; init; }
    }
}