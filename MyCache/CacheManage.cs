using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCache
{
   public class CacheManage
    {
        private CacheManage()
        { }

        private static ICache cache=null;
        /// <summary>
        /// 由CLR保证  程序运行前创建
        /// </summary>
        static CacheManage()
        {
            Console.WriteLine("开始缓存的初始化..........");
            cache = (ICache)Activator.CreateInstance(typeof(MemoryCacheCache));
        }
        public static int Count
        {
            get { return cache.count; }
        }

        public static bool Contains(string key)
        {
            return cache.Contains(key);
        }

        public static T GetData<T>(string key)
        {
            return cache.Get<T>(key);
        }
        public static T Get<T>(string key, Func<T> acquire, int cacheTime = 30)
        {
            if (cache.Contains(key))
                return GetData<T>(key);
            else
            {
                T result = acquire.Invoke();
                cache.Add(key, result, cacheTime);
                return result;
            }
        }
        public static void Add(string key, object value, int expiratTime = 30)
        {
            if (Contains(key))
                cache.Remove(key);
            cache.Add(key, value, expiratTime);
        }
        public static void Remove(string key)
        {
            cache.Remove(key);
        }

        public static void RemoveAll()
        {
            cache.RemoveAll();
        } 
    }
}
