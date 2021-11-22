using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Util.Applications.Logging {
    /// <summary>
    /// 日志上下文启动过滤器
    /// </summary>
    public class LogContextStartupFilter : IStartupFilter {
        /// <summary>
        /// 配置日志上下文中间件
        /// </summary>
        /// <param name="next">下个中间件操作</param>
        public Action<IApplicationBuilder> Configure( Action<IApplicationBuilder> next ) {
            return app => {
                app.UseLogContext();
                next( app );
            };
        }
    }
}
