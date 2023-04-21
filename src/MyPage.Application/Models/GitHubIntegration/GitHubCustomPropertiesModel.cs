using MyPage.Application.Models.Enums;
using Newtonsoft.Json;

namespace MyPage.Application.Models.GitHubIntegration
{
    public class GitHubCustomPropertiesModel
    {
        [JsonIgnore]
        public string Description { get; set; }

        public IDictionary<Language, string> DescriptionDictonary { get; set; }

        public string VideoUrl { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}