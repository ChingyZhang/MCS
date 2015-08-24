using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cache
{
    public interface ICache
    {
        /// <summary>
        /// 缓存最大保存时间
        /// </summary>
        DateTime MaxAbsoluteExpiration { get; }
        /// <summary>
        /// 缓存默认保存时间
        /// </summary>
        TimeSpan DefaultTimeSpan { get; }

        /// <summary>
        /// 向Cache中添加缓存对象
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="obj">要缓存的对象</param>
        void Add(string key, object obj);

        /// <summary>
        /// 向Cache中添加缓存对象，如果时间达到指定秒数即被移除
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="obj">要缓存的对象</param>
        /// <param name="seconds">固定的超时秒数</param>
        void Add(string key, object obj, int seconds);

        /// <summary>
        /// 向Cache中添加缓存对象
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="obj">要缓存的对象</param>
        /// <param name="slidingdExpiration">指定的时间段</param>
        void Add(string key, object obj, TimeSpan slidingdExpiration);

        /// <summary>
        /// 从Cache中判断指定的Key是否已经有缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns>true/false</returns>
        bool Exists(string key);

        /// <summary>
        /// 从Cache中获取缓存的对象
        /// </summary>
        /// <typeparam name="T">缓存对象的类型</typeparam>
        /// <param name="key">缓存Key</param>
        /// <returns>缓存的对象</returns>
        T Get<T>(string key);

        /// <summary>
        /// 向Cache中永久缓存对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        void Max(string key, object obj);

        /// <summary>
        /// 测试Cache是否可用
        /// </summary>
        /// <returns></returns>
        bool Test();
    }
}
