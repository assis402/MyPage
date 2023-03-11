namespace MyPage.Application.Helpers
{
    public class Settings
    {
        public string CacheKey { get; set; }
        public int DaysToCacheExpiration { get; set; }
        public GitHubSettings GitHubSettings { get; set; }
    }
}
