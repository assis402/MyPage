namespace MyPage.Application.Helpers
{
    public class Settings
    {
        public string ProjectsCacheKey { get; set; }

        public string TagsCacheKey { get; set; }

        public string PublicationsCacheKey { get; set; }

        public int CacheExpirationInDays { get; set; }

        public GitHubSettings GitHubSettings { get; set; }

        public string MediumUrl { get; set; }
    }
}