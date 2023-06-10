using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class CollectionAttribute : Attribute
    {
        public string CollectionName { get; private set; }

        public CollectionAttribute(string collectionName) => CollectionName = collectionName;
    }
}
