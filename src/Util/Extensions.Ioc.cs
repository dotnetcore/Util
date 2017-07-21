using System;
using Microsoft.Extensions.DependencyInjection;
using Util.DependencyInjection;
using Util.Helpers;

namespace Util {
    /// <summary>
    /// 系统扩展 - Ioc
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 注册依赖配置
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configs">依赖配置</param>
        public static IServiceProvider AddIoc( this IServiceCollection services, params IConfig[] configs ) {
            return Ioc.Register( services, configs );
        }
    }
}
