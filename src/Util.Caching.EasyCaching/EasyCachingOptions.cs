using System;
using EasyCaching.InMemory;
using EasyCaching.Redis;
using Microsoft.Extensions.Configuration;

namespace Util.Caching.EasyCaching {
    /// <summary>
    /// EasyCaching配置
    /// </summary>
    internal class EasyCachingOptions {
        /// <summary>
        /// 内存缓存配置操作
        /// </summary>
        public Action<InMemoryOptions> MemoryCacheSetupAction { get; set; }
        /// <summary>
        /// Redis缓存配置操作
        /// </summary>
        public Action<RedisOptions> RedisCacheSetupAction { get; set; }
        /// <summary>
        /// 配置
        /// </summary>
        public IConfiguration Configuration { get; set; }
        /// <summary>
        /// 内存缓存配置节名称
        /// </summary>
        public string MemoryConfigSection { get; set; }
        /// <summary>
        /// Redis缓存配置节名称
        /// </summary>
        public string RedisConfigSection { get; set; }
        /// <summary>
        /// 是否配置内存缓存
        /// </summary>
        public bool IsConfigMemoryCache { get; set; }
    }
}
