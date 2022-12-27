using Microsoft.AspNetCore.Builder;

namespace Util.Applications.Logging {
    /// <summary>
    /// 日志上下文中间件扩展
    /// </summary>
    public static class LogContextMiddlewareExtensions {
        /// <summary>
        /// 注册日志上下文中间件
        /// </summary>
        /// <param name="builder">应用程序生成器</param>
        public static IApplicationBuilder UseLogContext( this IApplicationBuilder builder ) {
            return builder.UseMiddleware<LogContextMiddleware>();
        }
    }
}
