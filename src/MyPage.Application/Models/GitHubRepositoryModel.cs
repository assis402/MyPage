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

        [JsonProperty("full_name")]
        public string FullName { get; set; } 

        [JsonProperty("topics")]
        public IEnumerable<string> Topic { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        public CustomPropertiesModel CustomProperties { get; set; }

        public void SetDescriptionByLanguage(Language currentLanguage)
        {
            if (CustomProperties.DescriptionDictonary.TryGetValue(currentLanguage, out string description))
                CustomProperties.Description = description;
        }
    }
}
