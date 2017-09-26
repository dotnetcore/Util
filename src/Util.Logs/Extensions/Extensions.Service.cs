using System;
using Exceptionless;
using Microsoft.Extensions.DependencyInjection;
using Util.Logs.Abstractions;
using Util.Logs.Core;
using Util.Logs.Formats;

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
            services.AddScoped<ILogProviderFactory, Util.Logs.NLog.LogProviderFactory>();
            services.AddSingleton<ILogFormat, ContentFormat>();
            services.AddScoped<ILogContext, LogContext>();
            services.AddScoped<ILog, Log>();
        }

        /// <summary>
        /// 注册Exceptionless日志操作
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configAction">配置操作</param>
        public static void AddExceptionless( this IServiceCollection services, Action<ExceptionlessConfiguration> configAction ) {
            services.AddScoped<ILogProviderFactory, Util.Logs.Exceptionless.LogProviderFactory>();
            services.AddSingleton( typeof( ILogFormat ), t => NullLogFormat.Instance );
            services.AddScoped<ILogContext, Util.Logs.Exceptionless.LogContext>();
            services.AddScoped<ILog, Log>();
            configAction?.Invoke( ExceptionlessClient.Default.Configuration );
        }
    }
}
