using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Util.Locks.Default {
    /// <summary>
    /// 业务锁扩展
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 注册业务锁
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddLock( this IServiceCollection services ) {
            services.TryAddScoped<ILock, DefaultLock>();
        }
    }
}
