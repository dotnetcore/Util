using AspectCore.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace Util.Caching {
    /// <summary>
    /// Redis缓存拦截器
    /// </summary>
    public class RedisCacheAttribute : CacheAttribute {
        /// <summary>
        /// 获取缓存服务
        /// </summary>
        protected override ICache GetCache( AspectContext context ) {
            return context.ServiceProvider.GetService<IRedisCache>();
        }
    }
}
