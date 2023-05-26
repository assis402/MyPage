namespace MyPage.Application.Services.Interfaces
{
    public interface ITagsCacheService : IMemoryCacheService<IEnumerable<string>>
    {
    }
}