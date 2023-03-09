using MyPage.Application.Models.Enums;
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

        public void SetCustomPropertiesByLanguage(CustomPropertiesModel customProperties, Language currentLanguage)
        {
            if (customProperties.Description.TryGetValue(currentLanguage, out string description))
                Description = description;

            VideoUrl = customProperties.VideoUrl;
        }
    }
}
