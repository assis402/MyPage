namespace MyPage.Application.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public Task<ICollection<TEntity>> GetAll();

        public Task Insert(TEntity employee);

        public Task Update(TEntity employee);

        public Task Delete(string id);
    }
}