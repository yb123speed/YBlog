using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YBlog.Core.AOP
{
    /// <summary>
    /// 实例化缓存接口ICaching
    /// </summary>
    public class MemoryCaching : ICaching
    {
        #region private fileds and constructor

        //引用Microsoft.Extensions.Caching.Memory;这个和.net 还是不一样，没有了Httpruntime了
        private readonly IMemoryCache _memoryCache;

        public MemoryCaching(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        #endregion
        public object Get(string cacheKey)
        {
            return _memoryCache.Get(cacheKey);
        }

        public void Set(string cacheKey, object cacheValue, TimeSpan? expiration)
        {
            if (expiration == null)
            {
                _memoryCache.Set(cacheKey, cacheValue, TimeSpan.FromHours(2));
            }
            else
            {
                _memoryCache.Set(cacheKey, cacheValue, expiration.Value);
            }
            
        }
    }
}
