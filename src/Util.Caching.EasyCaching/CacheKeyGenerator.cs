using System;
using System.Reflection;
using EasyCaching.Core.Interceptor;

namespace Util.Caching.EasyCaching {
    /// <summary>
    /// 缓存键生成器
    /// </summary>
    public class CacheKeyGenerator : ICacheKeyGenerator {
        /// <summary>
        /// EasyCaching缓存键生成器
        /// </summary>
        private readonly IEasyCachingKeyGenerator _keyGenerator;

        /// <summary>
        /// 初始化缓存键生成器
        /// </summary>
        /// <param name="keyGenerator">EasyCaching缓存键生成器</param>
        public CacheKeyGenerator( IEasyCachingKeyGenerator keyGenerator ) {
            _keyGenerator = keyGenerator ?? throw new ArgumentNullException( nameof(keyGenerator) );
        }

        /// <inheritdoc />
        public string CreateCacheKey( MethodInfo methodInfo, object[] args, string prefix ) {
            return _keyGenerator.GetCacheKey( methodInfo, args, prefix );
        }
    }
}
