using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using MyPage.Application.Data.Entities;
using MyPage.Application.Data.Repositories.Interfaces;
using MyPage.Application.Helpers;

namespace MyPage.Application.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly CollectionReference _entityCollection;

        public BaseRepository(MyPageContextDb myPageContextDb)
        {
            _entityCollection = myPageContextDb.Database.Collection(Utils.GetCollectionName<TEntity>());
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            var entityList = new List<TEntity>();

            var snapshot = await _entityCollection.GetSnapshotAsync();

            foreach (var document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    var dictionayDocument = document.ToDictionary();
                    var entity = dictionayDocument.ToJson().ToObject<TEntity>();
                    entityList.Add(entity);
                }
            }

            return entityList;
        }

        public async Task Insert(TEntity entity)
        {
            await _entityCollection.AddAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            var documentReference = _entityCollection.Document(entity.Id);
            await documentReference.SetAsync(entity, SetOptions.Overwrite);
        }

        public async Task Delete(string id)
        {
            var documentReference = _entityCollection.Document(id);
            await documentReference.DeleteAsync();
        }
    }
}