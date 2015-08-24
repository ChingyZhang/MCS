using System;
using System.Web;
using System.Web.Caching;

namespace Core.Cache
{
    public class RuntimeCache : ICache
    {
        private readonly System.Web.Caching.Cache _cache;

        public RuntimeCache()
        {
            _cache = System.Web.HttpContext.Current.Cache;
        }

        public DateTime MaxAbsoluteExpiration
        {
            get
            {
                return DateTime.MaxValue;
            }
        }

        public TimeSpan DefaultTimeSpan
        {
            get
            {
                TimeSpan _ts = new TimeSpan(0, 20, 0);
                return _ts;
            }
        }

        public void Add(string key, object obj)
        {
            _cache.Add(key, obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration, DefaultTimeSpan, CacheItemPriority.Default, null);
            Core.Log.LoggerWriter.WriteLog(string.Format("字典{0}成功加入内存", key));
        }

        public void Add(string key, object obj, int seconds)
        {
            TimeSpan _ts = new TimeSpan(0, 0, seconds);
            _cache.Add(key, obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration, DefaultTimeSpan, CacheItemPriority.Default, null);
            Core.Log.LoggerWriter.WriteLog(string.Format("字典{0}成功加入内存", key));
        }

        public void Add(string key, object obj, TimeSpan slidingdExpiration)
        {
            _cache.Add(key, obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration, slidingdExpiration, CacheItemPriority.Default, null);
            Core.Log.LoggerWriter.WriteLog(string.Format("字典{0}成功加入内存", key));
        }

        public bool Exists(string key)
        {
            return _cache.Get(key) != null;
        }

        public T Get<T>(string key)
        {
            T t;
            try
            {
                t = (T)_cache.Get(key);
            }
            catch (Exception ex)
            {
                t = default(T);
            }
            Core.Log.LoggerWriter.AddLog(new System.Diagnostics.StackTrace());
            return t;
        }

        public void Max(string key, object obj)
        {
            _cache.Add(key, obj, null, MaxAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            Core.Log.LoggerWriter.WriteLog(string.Format("字典{0}成功加入内存", key));
        }

        public bool Test()
        {
            throw new NotImplementedException();
        }

       

    }
}
