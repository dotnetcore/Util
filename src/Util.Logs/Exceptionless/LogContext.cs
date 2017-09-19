using System;
using System.Diagnostics;
using Util.Contexts;
using Util.Helpers;
using Util.Logs.Internal;

namespace Util.Logs.Exceptionless {
    /// <summary>
    /// Exceptionless日志上下文
    /// </summary>
    public class LogContext : Util.Logs.Core.LogContext {
        /// <summary>
        /// 初始化日志上下文
        /// </summary>
        /// <param name="context">上下文</param>
        public LogContext( IContext context ) : base( context ) {
        }

        /// <summary>
        /// 创建日志上下文信息
        /// </summary>
        /// <param name="traceId">跟踪号</param>
        /// <param name="stopwatch">计时器</param>
        protected override LogContextInfo CreateInfo( string traceId, Stopwatch stopwatch ) {
            return new LogContextInfo {
                TraceId = Guid.NewGuid().ToString(),
                Stopwatch = stopwatch,
                Url = Web.Url
            };
        }
    }
}
