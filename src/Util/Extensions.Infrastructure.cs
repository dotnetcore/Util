using System;
using System.Text;
using AspectCore.Configuration;
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
            return AddUtil( services, null, configs );
        }

        /// <summary>
        /// 注册Util基础设施服务
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="aopConfigAction">Aop配置操作</param>
        /// <param name="configs">依赖配置</param>
        public static IServiceProvider AddUtil( this IServiceCollection services, Action<IAspectConfiguration> aopConfigAction, params IConfig[] configs ) {
            services.AddHttpContextAccessor();
            Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );
            return Bootstrapper.Run( services, configs, aopConfigAction );
        }
    }
}
