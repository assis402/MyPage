using MyPage.Application.Helpers;
using MyPage.Application.Models.Enums;
using Newtonsoft.Json;

namespace MyPage.Application.Models.GitHubIntegration
{
    public class GitHubRepositoryModel
    {
        [JsonProperty("html_url")]
        public string Url { get; set; }

        private string title;

        [JsonProperty("name")]
        public string Title
        {
            get { return title.Captalize(); }
            set { title = value; }
        }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("topics")]
        public IEnumerable<string> Topics { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        public GitHubCustomPropertiesModel CustomProperties { get; set; }

        public void SetDescriptionByLanguage(Language currentLanguage)
        {
            if (CustomProperties.DescriptionDictonary.TryGetValue(currentLanguage, out string description))
                CustomProperties.Description = description;
        }

        public bool Contains(string text)
        {
            text = text.ToLower().Trim();

            return Title.ToLower().Contains(text) ||
                   CustomProperties.Description.ToLower().Contains(text);
        }
    }
}