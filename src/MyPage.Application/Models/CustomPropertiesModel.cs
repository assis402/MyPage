using MyPage.Application.Models.Enums;

namespace MyPage.Application.Models
{
    public class CustomPropertiesModel
    {
        public string Description { get; set; }
        
        public IDictionary<Language, string> DescriptionDictonary { get; set; }

        public string VideoUrl { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
