using Flurl.Http;

namespace MyPage.Application.Helpers;

public class GitHubSettings
{
    internal IFlurlRequest _requestClient;

    public string GitHubLoginUrl { get; set; }
    public string GitHubReposUrl { get; set; }
    public string GitHubToken { get; set; }
}
