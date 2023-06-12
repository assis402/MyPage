namespace MyPage.Application.Helpers
{
    public class Settings
    {
        public GoogleSettings GoogleSettings { get; init; }
        
        public CacheSettings CacheSettings { get; init; }
        
        public MediumSettings MediumSettings { get; init; }

        public GitHubSettings GitHubSettings { get; init; }
    }
}