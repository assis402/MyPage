using Google.Cloud.Firestore;

namespace MyPage.Application.Data.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }

        [FirestoreProperty]
        public string Id { get; private set; }
    }
}