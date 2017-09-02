using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyCache
{
    public class CustomerCache : ICache
    {
        private static Dictionary<string, KeyValuePair<object,DateTime>> _CacheDictionary = new Dictionary<string, KeyValuePair<object, DateTime>>();
        public object this[string key]
        {
            get
            {
                return _CacheDictionary[key];
            }
            set
            {
                _CacheDictionary[key] = new KeyValuePair<object, DateTime>(value, DateTime.Now.AddMinutes(30));
            }
        }

        public int count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(string key, object data, int cacheTime = 30)
        {
            _CacheDictionary[key] = new KeyValuePair<object, DateTime>(data, DateTime.Now.AddMinutes(cacheTime));
        }

        public bool Contains(string key)
        {
            if (_CacheDictionary[key].Key != null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 主动 过期
        /// </summary>
        static CustomerCache()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    if (_CacheDictionary != null)
                    {
                        List<string> keyList = new List<string>();
                        foreach (var key in _CacheDictionary.Keys)
                        {
                            keyList.Add(key);
                        }
                        for (int i=0;i<_CacheDictionary.Keys.Count;i++)
                        {   
                            string key=keyList[i];
                            KeyValuePair<object, DateTime> valueTime = _CacheDictionary[key];
                            if (valueTime.Value < DateTime.Now)
                                _CacheDictionary.Remove(key);
                        }
                    }
                }
            });
        }
        /// <summary>
        /// 被动  过期
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            if (!this.Contains(key))
                return default(T);
            else
            {
                KeyValuePair<object, DateTime> valueTime = _CacheDictionary[key];
                if (valueTime.Value < DateTime.Now)
                {
                    _CacheDictionary.Remove(key);
                    return default(T);
                }
                else
                    return (T)valueTime.Key;
            }
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }
    }
}
