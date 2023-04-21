namespace MyPage.Application.Services.Interfaces
{
    public interface IMemoryCacheService<T> where T : class
    {
        public Task<T> GetOrCreate(Func<Task<T>> methodToCache);

        public void ClearCache();
    }
}