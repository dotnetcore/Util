using System;
using EasyCaching.Core.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Util.Configs;

namespace Util.Caching.EasyCaching {
    /// <summary>
    /// EasyCaching缓存操作配置扩展
    /// </summary>
    public class EasyCachingOptionsExtension : OptionsExtensionBase {
        /// <summary>
        /// EasyCaching缓存配置操作
        /// </summary>
        private readonly Action<EasyCachingOptions> _setupAction;

        /// <summary>
        /// 初始化EasyCaching缓存操作配置扩展
        /// </summary>
        /// <param name="setupAction">EasyCaching缓存配置操作</param>
        public EasyCachingOptionsExtension( Action<EasyCachingOptions> setupAction ) {
            _setupAction = setupAction;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            services.TryAddScoped<ICache, CacheManager>();
            services.AddEasyCaching( _setupAction );
        }
    }
}
