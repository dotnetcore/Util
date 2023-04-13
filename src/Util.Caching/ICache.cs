using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Util.Caching {
    /// <summary>
    /// 缓存
    /// </summary>
    public interface ICache {
        /// <summary>
        /// 缓存是否已存在
        /// </summary>
        /// <param name="key">缓存键</param>
        bool Exists( CacheKey key );
        /// <summary>
        /// 缓存是否已存在
        /// </summary>
        /// <param name="key">缓存键</param>
        bool Exists( string key );
        /// <summary>
        /// 缓存是否已存在
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<bool> ExistsAsync( CacheKey key, CancellationToken cancellationToken = default );
        /// <summary>
        /// 缓存是否已存在
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<bool> ExistsAsync( string key, CancellationToken cancellationToken = default );
        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        T Get<T>( CacheKey key );
        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        T Get<T>( string key );
        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="keys">缓存键集合</param>
        List<T> Get<T>( IEnumerable<CacheKey> keys );
        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="keys">缓存键集合</param>
        List<T> Get<T>( IEnumerable<string> keys );
        /// <summary>
        /// 从缓存中获取数据，如果不存在，则执行获取数据操作并添加到缓存中
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="action">获取数据操作</param>
        /// <param name="options">缓存配置</param>
        T Get<T>( CacheKey key, Func<T> action, CacheOptions options = null );
        /// <summary>
        /// 从缓存中获取数据，如果不存在，则执行获取数据操作并添加到缓存中
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="action">获取数据操作</param>
        /// <param name="options">缓存配置</param>
        T Get<T>( string key, Func<T> action, CacheOptions options = null );
        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="type">缓存数据类型</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<object> GetAsync( string key, Type type, CancellationToken cancellationToken = default );
        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<T> GetAsync<T>( CacheKey key, CancellationToken cancellationToken = default );
        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<T> GetAsync<T>( string key, CancellationToken cancellationToken = default );
        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="keys">缓存键集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<List<T>> GetAsync<T>( IEnumerable<CacheKey> keys, CancellationToken cancellationToken = default );
        /// <summary>
        /// 从缓存中获取数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="keys">缓存键集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<List<T>> GetAsync<T>( IEnumerable<string> keys, CancellationToken cancellationToken = default );
        /// <summary>
        /// 从缓存中获取数据，如果不存在，则执行获取数据操作并添加到缓存中
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="action">获取数据操作</param>
        /// <param name="options">缓存配置</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<T> GetAsync<T>( CacheKey key, Func<Task<T>> action, CacheOptions options = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 从缓存中获取数据，如果不存在，则执行获取数据操作并添加到缓存中
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="action">获取数据操作</param>
        /// <param name="options">缓存配置</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<T> GetAsync<T>( string key, Func<Task<T>> action, CacheOptions options = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 通过缓存键前缀获取数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="prefix">缓存键前缀</param>
        List<T> GetByPrefix<T>( string prefix );
        /// <summary>
        /// 通过缓存键前缀获取数据
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="prefix">缓存键前缀</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<List<T>> GetByPrefixAsync<T>( string prefix, CancellationToken cancellationToken = default );
        /// <summary>
        /// 设置缓存,当缓存已存在则忽略，设置成功返回true
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">值</param>
        /// <param name="options">缓存配置</param>
        bool TrySet<T>( CacheKey key, T value, CacheOptions options = null );
        /// <summary>
        /// 设置缓存,当缓存已存在则忽略，设置成功返回true
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">值</param>
        /// <param name="options">缓存配置</param>
        bool TrySet<T>( string key, T value, CacheOptions options = null );
        /// <summary>
        /// 设置缓存,当缓存已存在则忽略，设置成功返回true
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">值</param>
        /// <param name="options">缓存配置</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<bool> TrySetAsync<T>( CacheKey key, T value, CacheOptions options = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 设置缓存,当缓存已存在则忽略，设置成功返回true
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">值</param>
        /// <param name="options">缓存配置</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<bool> TrySetAsync<T>( string key, T value, CacheOptions options = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 设置缓存,当缓存已存在则覆盖
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">值</param>
        /// <param name="options">缓存配置</param>
        void Set<T>( CacheKey key, T value, CacheOptions options = null );
        /// <summary>
        /// 设置缓存,当缓存已存在则覆盖
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">值</param>
        /// <param name="options">缓存配置</param>
        void Set<T>( string key, T value, CacheOptions options = null );
        /// <summary>
        /// 设置缓存集合
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="items">缓存项集合</param>
        /// <param name="options">缓存配置</param>
        void Set<T>( IDictionary<CacheKey,T> items, CacheOptions options = null );
        /// <summary>
        /// 设置缓存集合
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="items">缓存项集合</param>
        /// <param name="options">缓存配置</param>
        void Set<T>( IDictionary<string, T> items, CacheOptions options = null );
        /// <summary>
        /// 设置缓存,当缓存已存在则覆盖
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">值</param>
        /// <param name="options">缓存配置</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task SetAsync<T>( CacheKey key, T value, CacheOptions options = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 设置缓存,当缓存已存在则覆盖
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="value">值</param>
        /// <param name="options">缓存配置</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task SetAsync<T>( string key, T value, CacheOptions options = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 设置缓存集合
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="items">缓存项集合</param>
        /// <param name="options">缓存配置</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task SetAsync<T>( IDictionary<CacheKey, T> items, CacheOptions options = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 设置缓存集合
        /// </summary>
        /// <typeparam name="T">缓存数据类型</typeparam>
        /// <param name="items">缓存项集合</param>
        /// <param name="options">缓存配置</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task SetAsync<T>( IDictionary<string, T> items, CacheOptions options = null, CancellationToken cancellationToken = default );
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        void Remove( CacheKey key );
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        void Remove( string key );
        /// <summary>
        /// 移除缓存集合
        /// </summary>
        /// <param name="keys">缓存键集合</param>
        void Remove( IEnumerable<CacheKey> keys );
        /// <summary>
        /// 移除缓存集合
        /// </summary>
        /// <param name="keys">缓存键集合</param>
        void Remove( IEnumerable<string> keys );
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( CacheKey key, CancellationToken cancellationToken = default );
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( string key, CancellationToken cancellationToken = default );
        /// <summary>
        /// 移除缓存集合
        /// </summary>
        /// <param name="keys">缓存键集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( IEnumerable<CacheKey> keys, CancellationToken cancellationToken = default );
        /// <summary>
        /// 移除缓存集合
        /// </summary>
        /// <param name="keys">缓存键集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( IEnumerable<string> keys, CancellationToken cancellationToken = default );
        /// <summary>
        /// 通过缓存键前缀移除缓存
        /// </summary>
        /// <param name="prefix">缓存键前缀</param>
        void RemoveByPrefix( string prefix );
        /// <summary>
        /// 通过缓存键前缀移除缓存
        /// </summary>
        /// <param name="prefix">缓存键前缀</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveByPrefixAsync( string prefix, CancellationToken cancellationToken = default );
        /// <summary>
        /// 通过缓存键模式移除缓存
        /// </summary>
        /// <param name="pattern">缓存键模式,范例: test*</param>
        void RemoveByPattern( string pattern );
        /// <summary>
        /// 通过缓存键模式移除缓存
        /// </summary>
        /// <param name="pattern">缓存键模式,范例: test*</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveByPatternAsync( string pattern, CancellationToken cancellationToken = default );
        /// <summary>
        /// 清空缓存
        /// </summary>
        void Clear();
        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        Task ClearAsync( CancellationToken cancellationToken = default );
    }
}
