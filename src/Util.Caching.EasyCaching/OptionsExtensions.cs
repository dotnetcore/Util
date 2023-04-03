using System;
using EasyCaching.InMemory;
using EasyCaching.Redis;
using Microsoft.Extensions.Configuration;
using Util.Configs;

namespace Util.Caching.EasyCaching {
    /// <summary>
    /// EasyCaching缓存操作扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 配置EasyCaching缓存操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="easyCachingOptions">缓存配置</param>
        private static Options UseEasyCaching( this Options options, EasyCachingOptions easyCachingOptions ) {
            options.AddExtension( new EasyCachingOptionsExtension( easyCachingOptions ) );
            return options;
        }

        /// <summary>
        /// 配置EasyCaching内存缓存操作
        /// </summary>
        /// <param name="options">配置项</param>
        public static Options UseMemoryCache( this Options options ) {
            return options.UseEasyCaching( new EasyCachingOptions { IsConfigMemoryCache = true } );
        }

        /// <summary>
        /// 配置EasyCaching内存缓存操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="configuration">配置</param>
        /// <param name="section">配置节名称</param>
        public static Options UseMemoryCache( this Options options, IConfiguration configuration, string section ) {
            return options.UseEasyCaching( new EasyCachingOptions { Configuration = configuration, MemoryConfigSection = section } );
        }

        /// <summary>
        /// 配置EasyCaching内存缓存操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">内存缓存配置操作</param>
        public static Options UseMemoryCache( this Options options, Action<InMemoryOptions> setupAction ) {
            return options.UseEasyCaching( new EasyCachingOptions { MemoryCacheSetupAction = setupAction } );
        }

        /// <summary>
        /// 配置EasyCaching Redis缓存操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="configuration">配置</param>
        /// <param name="section">配置节名称</param>
        public static Options UseRedisCache( this Options options, IConfiguration configuration, string section ) {
            return options.UseEasyCaching( new EasyCachingOptions { Configuration = configuration, RedisConfigSection = section } );
        }

        /// <summary>
        /// 配置EasyCaching Redis缓存操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">Redis缓存配置操作</param>
        public static Options UseRedisCache( this Options options, Action<RedisOptions> setupAction ) {
            return options.UseEasyCaching( new EasyCachingOptions { RedisCacheSetupAction = setupAction } );
        }
    }
}
