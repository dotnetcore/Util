using Microsoft.Extensions.DependencyInjection;
using Util.Logs.Abstractions;
using Util.Logs.Core;

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
            services.AddScoped<ILogContext, LogContext>();
            services.AddScoped<ILogManager, Util.Logs.NLog.LogManager>();
        }
    }
}
