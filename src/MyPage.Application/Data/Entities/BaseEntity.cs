using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Data.Entities
{
    public abstract class BaseEntity
    {
        [FirestoreProperty]
        public string Id { get; set; }
    }
}
