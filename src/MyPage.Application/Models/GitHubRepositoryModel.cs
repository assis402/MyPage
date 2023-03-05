using Newtonsoft.Json;

namespace MyPage.Application.Models
{
    public class GitHubRepositoryModel
    {
        [JsonProperty("html_url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Title { get; set; }

        [JsonProperty("topics")]
        public List<string> Topic { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }


        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public void SetCustomPropertiesByCulture(CustomPropertiesModel customProperties, string culture)
        {
        }
    }
}
