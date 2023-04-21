namespace MyPage.Application.Helpers
{
    public class Settings
    {
        public string ProjectsCacheKey { get; set; }
        public string TagsCacheKey { get; set; }
        public int CacheExpirationInDays { get; set; }
        public GitHubSettings GitHubSettings { get; set; }
    }
}