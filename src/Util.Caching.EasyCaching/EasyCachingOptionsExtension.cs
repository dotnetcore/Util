using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EasyCaching.Core.Interceptor;
using EasyCaching.Serialization.SystemTextJson.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Util.Configs;
using EasyCachingConfig = EasyCaching.Core.Configurations;

namespace Util.Caching.EasyCaching {
    /// <summary>
    /// EasyCaching缓存操作配置扩展
    /// </summary>
    internal class EasyCachingOptionsExtension : OptionsExtensionBase {
        /// <summary>
        /// 缓存配置
        /// </summary>
        private readonly EasyCachingOptions _options;

        /// <summary>
        /// 初始化EasyCaching缓存操作配置扩展
        /// </summary>
        /// <param name="options">缓存配置</param>
        public EasyCachingOptionsExtension( EasyCachingOptions options ) {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            services.TryAddSingleton<ICache, CacheManager>();
            services.TryAddSingleton<ILocalCache, MemoryCacheManager>();
            services.TryAddSingleton<IRedisCache, RedisCacheManager>();
            services.TryAddSingleton<ICacheKeyGenerator, CacheKeyGenerator>();
            services.AddEasyCaching( ConfigEasyCaching );
            services.TryAddSingleton<IEasyCachingKeyGenerator, DefaultEasyCachingKeyGenerator>();
        }

        /// <summary>
        /// 配置缓存
        /// </summary>
        private void ConfigEasyCaching( EasyCachingConfig.EasyCachingOptions options ) {
            ConfigMemoryCache( options );
            ConfigRedisCache( options );
        }

        /// <summary>
        /// 配置内存缓存
        /// </summary>
        private void ConfigMemoryCache( EasyCachingConfig.EasyCachingOptions options ) {
            if ( _options.Configuration != null && _options.MemoryConfigSection.IsEmpty() == false ) {
                options.UseInMemory( _options.Configuration, CacheProviderKey.MemoryCache, _options.MemoryConfigSection );
                return;
            }
            if ( _options.MemoryCacheSetupAction != null ) {
                options.UseInMemory( _options.MemoryCacheSetupAction, CacheProviderKey.MemoryCache );
                return;
            }
            if ( _options.IsConfigMemoryCache ) {
                options.UseInMemory( CacheProviderKey.MemoryCache );
            }
        }

        /// <summary>
        /// 配置Redis缓存
        /// </summary>
        private void ConfigRedisCache( EasyCachingConfig.EasyCachingOptions options ) {
            if ( _options.Configuration != null && _options.RedisConfigSection.IsEmpty() == false ) {
                ConfigRedisSerializer( options );
                options.UseRedis( _options.Configuration, CacheProviderKey.RedisCache, _options.RedisConfigSection );
                return;
            }
            if ( _options.RedisCacheSetupAction == null )
                return;
            ConfigRedisSerializer( options );
            options.UseRedis( _options.RedisCacheSetupAction, CacheProviderKey.RedisCache );
        }

        /// <summary>
        /// 配置Redis序列化
        /// </summary>
        private void ConfigRedisSerializer( EasyCachingConfig.EasyCachingOptions options ) {
            options.WithSystemTextJson( t => t.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, CacheProviderKey.RedisCache );
        }
    }
}
