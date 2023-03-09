using MyPage.Application.Models.Enums;

namespace MyPage.Application.Models
{
    public class CustomPropertiesModel
    {
        public IDictionary<Language, string> Description { get; set; }

        public string VideoUrl { get; set; }
    }
}
