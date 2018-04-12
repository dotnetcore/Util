using System;
using Microsoft.Extensions.DependencyInjection;
using Util.Dependency;

namespace Util {
    /// <summary>
    /// 系统扩展 - 基础设施
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 注册Util基础设施服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        public static IServiceProvider AddUtil( this IServiceCollection services, params IConfig[] configs ) {
            services.AddHttpContextAccessor();
            return new DependencyConfiguration( services, configs ).Config();
        }
    }
}
