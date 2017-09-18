using System;
using Exceptionless;
using Microsoft.Extensions.DependencyInjection;
using Util.Logs.Abstractions;

namespace Util.Logs.Extensions {
    /// <summary>
    /// 日志扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 注册NLog日志操作
        /// </summary>
        /// <param name="services">服务集合</param>
        public static void AddNLog( this IServiceCollection services ) {
            services.AddScoped<ILogContext, Util.Logs.Core.LogContext>();
            services.AddScoped<ILogManager, Util.Logs.NLog.LogManager>();
        }

        /// <summary>
        /// 注册Exceptionless日志操作
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configAction">配置操作</param>
        public static void AddExceptionless( this IServiceCollection services,Action<ExceptionlessConfiguration> configAction ) {
            services.AddScoped<ILogContext, Util.Logs.Exceptionless.LogContext>();
            services.AddScoped<ILogManager, Util.Logs.Exceptionless.LogManager>();
            configAction?.Invoke( ExceptionlessClient.Default.Configuration );
        }
    }
}
