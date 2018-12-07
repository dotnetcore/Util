using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Webs.Middlewares {
    /// <summary>
    /// 错误日志中间件
    /// </summary>
    public class ErrorLogMiddleware {
        /// <summary>
        /// 方法
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// 初始化错误日志中间件
        /// </summary>
        /// <param name="next">方法</param>
        public ErrorLogMiddleware( RequestDelegate next ) {
            _next = next;
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="context">Http上下文</param>
        public async Task Invoke( HttpContext context ) {
            try {
                await _next( context );
            }
            catch( Exception ex ) {
                WriteLog( context, ex );
                throw;
            }
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        private void WriteLog( HttpContext context, Exception ex ) {
            if( context == null )
                return;
            var log = (ILog)context.RequestServices.GetService(typeof(ILog));
            log.Caption( "全局异常捕获 - 错误日志中间件" ).Content( $"状态码：{context.Response.StatusCode}" );
            ex.Log( log );
        }
    }
}
