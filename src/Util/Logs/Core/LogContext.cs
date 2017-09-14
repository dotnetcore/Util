using System;
using System.Diagnostics;
using Util.Contexts;
using Util.Logs.Internal;

namespace Util.Logs.Core {
    /// <summary>
    /// 日志上下文
    /// </summary>
    public class LogContext : ILogContext {
        /// <summary>
        /// 上下文
        /// </summary>
        private readonly IContext _context;
        /// <summary>
        /// 日志上下文信息
        /// </summary>
        private LogContextInfo _info;

        /// <summary>
        /// 初始化日志上下文
        /// </summary>
        /// <param name="context">上下文</param>
        public LogContext( IContext context ) {
            _context = context;
        }

        /// <summary>
        /// 获取日志上下文信息
        /// </summary>
        private LogContextInfo GetInfo() {
            if ( _info != null )
                return _info;
            var key = "Util.Logs.LogContext";
            _info = _context.Get<LogContextInfo>( key );
            if( _info != null )
                return _info;
            _info = CreateInfo();
            _context.Add( key, _info );
            return _info;
        }

        /// <summary>
        /// 创建日志上下文信息
        /// </summary>
        private LogContextInfo CreateInfo() {
            var traceId = _context.TraceId;
            if( string.IsNullOrWhiteSpace( traceId ) )
                traceId = Guid.NewGuid().ToString();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            return new LogContextInfo( traceId, stopwatch );
        }
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId => GetInfo().TraceId;

        /// <summary>
        /// 计时器
        /// </summary>
        public Stopwatch Stopwatch => GetInfo().Stopwatch;
    }
}
