using Google.Cloud.Firestore;
using Google.Protobuf;
using MyPage.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            Database = FirestoreDb.Create(settings.FirebaseProjectId);
        }
    }
}
