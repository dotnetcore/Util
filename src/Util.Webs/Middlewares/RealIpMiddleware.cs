using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Util.Logs;
using Util.Logs.Extensions;

namespace Util.Webs.Middlewares
{
    /// <summary>
    /// 真实Ip中间件
    /// </summary>
    public class RealIpMiddleware {
        /// <summary>
        /// 方法
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// 真实Ip选项
        /// </summary>
        private readonly RealIpOptions _options;

        /// <summary>
        /// 初始化一个<see cref="RealIpMiddleware"/>类型的实例
        /// </summary>
        /// <param name="next">方法</param>
        /// <param name="options">真实Ip选项</param>
        public RealIpMiddleware(RequestDelegate next, IOptions<RealIpOptions> options) {
            _next = next;
            _options = options.Value;
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="context">Http上下文</param>
        public async Task Invoke(HttpContext context) {
            var headers = context.Request.Headers;
            try {
                if (headers.ContainsKey(_options.HeaderKey)) {
                    context.Connection.RemoteIpAddress = IPAddress.Parse(
                        _options.HeaderKey.ToLower() == "x-forwarded-for"
                            ? headers["X-Forwarded-For"].ToString().Split(',')[0]
                            : headers[_options.HeaderKey].ToString());
                    WriteLog(context, context.Connection.RemoteIpAddress);
                }
            }
            finally {
                await _next(context);
            }
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="context">Http上下文</param>
        /// <param name="address">Ip地址</param>
        private void WriteLog(HttpContext context, IPAddress address) {
            if(context==null)
                return;
            var log = Log.GetLog(this);
            if (!log.IsDebugEnabled)
                return;
            log.Caption("真实Ip中间件")
                .Content($"解析真实IP成功 : {address}")
                .Debug();
        }
    }

    /// <summary>
    /// 真实Ip选项
    /// </summary>
    public class RealIpOptions {
        /// <summary>
        /// 请求头键名
        /// </summary>
        public string HeaderKey { get; set; } = "X-Forwarded-For";
    }
}
