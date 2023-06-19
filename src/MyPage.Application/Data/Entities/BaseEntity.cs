using Google.Cloud.Firestore;

namespace MyPage.Application.Data.Entities
{
    public abstract class BaseEntity
    {
        [FirestoreProperty]
        public string Id { get; set; }
    }
}