using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Application.Services.Interfaces
{
    public interface IMemoryCacheService<T> where T : class
    {
        public Task<T> GetOrCreate(Func<Task<T>> methodToCache);

        public void ClearCache();
    }
}
