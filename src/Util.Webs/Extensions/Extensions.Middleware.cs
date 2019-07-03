using Microsoft.AspNetCore.Builder;
using Util.Webs.Middlewares;

namespace Util.Webs.Extensions {
    /// <summary>
    /// 中间件扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 注册错误日志管道
        /// </summary>
        /// <param name="builder">应用程序生成器</param>
        public static IApplicationBuilder UseErrorLog( this IApplicationBuilder builder ) {
            return builder.UseMiddleware<ErrorLogMiddleware>();
        }

        /// <summary>
        /// 注册真实Ip中间件
        /// </summary>
        /// <param name="builder">应用程序生成器</param>
        public static IApplicationBuilder UseRealIp(this IApplicationBuilder builder) {
            return builder.UseMiddleware<RealIpMiddleware>();
        }
    }
}
