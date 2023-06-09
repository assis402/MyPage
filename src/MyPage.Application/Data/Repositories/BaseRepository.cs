using Google.Cloud.Firestore;
using MyPage.Application.Data.Repositories.Interfaces;

namespace MyPage.Application.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private string _projectId;
        private FirestoreDb _fireStoreDb;

        public BaseRepository()
        {
            string arquivoApiKey = @"D:\_blazor\Blazor_Firestorer\Blazor_Firestorer\Server\FirestoreApiKey\blazorcrudfirestore-1565827c5156.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", arquivoApiKey);
            _projectId = "blazorcrudfirestore";
            _fireStoreDb = FirestoreDb.Create(projectId);
        }

        public Task<ICollection<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Insert(TEntity employee)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity employee)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}