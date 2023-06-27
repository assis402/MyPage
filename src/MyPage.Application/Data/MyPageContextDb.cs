using Google.Cloud.Firestore;
using MyPage.Application.Helpers;

namespace MyPage.Application.Data
{
    public class MyPageContextDb
    {
        public FirestoreDb Database { get; }

        public MyPageContextDb(Settings settings)
        {
            var root = Directory.GetCurrentDirectory();
            var filePath = Path.GetFullPath(Path.Combine(root, $@"..\firebase.json"));

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            Database = FirestoreDb.Create(settings.GoogleSettings.FirebaseProjectId);
        }
    }
}