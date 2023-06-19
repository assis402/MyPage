using MyPage.Application.Data.Entities;

namespace MyPage.Application.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<ICollection<TEntity>> GetAll();

        public Task<TEntity> GetById(string id);

        public Task Add(TEntity entity);

        public Task Update(TEntity entity);

        public Task Delete(string id);
    }
}