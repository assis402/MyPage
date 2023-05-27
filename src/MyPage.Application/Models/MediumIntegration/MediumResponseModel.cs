using MyPage.Application.Helpers;
using Newtonsoft.Json;

namespace MyPage.Application.Models.MediumIntegration
{
    public class MediumResponseModel
    {
        public MediumDataModel Data { get; set; }
        public string Next { get; set; }
    }

    public class MediumDataModel
    {
        public IEnumerable<MediumPublicationModel> Posts { get; set; }
    }

    public class MediumPublicationModel
    {
        [JsonConstructor]
        public MediumPublicationModel(long createdAt)
        {
            CreatedAt = DateTimeOffset.FromUnixTimeMilliseconds(createdAt).DateTime;
        }

        public string Id { get; set; }

        public string Url { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string GetFormatedDate() => CreatedAt.ToString("Y").Captalize();
    }
}