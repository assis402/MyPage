namespace MyPage.Application.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class CollectionAttribute : Attribute
    {
        public string CollectionName { get; private set; }

        public CollectionAttribute(string collectionName) => CollectionName = collectionName;
    }
}