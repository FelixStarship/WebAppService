using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace MyCache
{
  public  class MemoryCacheCache:ICache
    {
        public MemoryCacheCache() { }
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }
        public T Get<T>(string key)
        {
            if (Cache.Contains(key))
            {
                return (T)Cache[key];
            }
            else
            {
                return default(T);
            }
        }
        public void Add(string key, object data, int cacheTime = 30)
        {
            if (data == null)
                return;
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }
        public bool Contains(string key)
        {
           return Cache.Contains(key);
        }
        public int count { get { return (int)Cache.GetCount(); } }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }
        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<string>();
            foreach (var item in Cache)
                if (regex.IsMatch(item.Key))
                    keysToRemove.Add(item.Key);
            foreach (var key in keysToRemove)
                Remove(key);
        }
        public object this[string key]
        {
            get { return Cache.Get(key); }
            set { Add(key, value); }
        }

        public void RemoveAll()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }
    }
}
