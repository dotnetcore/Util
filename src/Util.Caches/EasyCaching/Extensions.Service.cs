using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Util.Caches.EasyCaching {
    /// <summary>
    /// EasyCaching缓存扩展
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 注册EasyCaching缓存提供器
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddEasyCaching( this IServiceCollection services ) {
            services.TryAddScoped<ICache, CacheManager>();
        }
    }
}
