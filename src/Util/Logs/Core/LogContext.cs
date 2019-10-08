using System.Diagnostics;
using Util.Contexts;
using Util.Helpers;
using Util.Logs.Abstractions;
using Util.Logs.Internal;

namespace Util.Logs.Core {
    /// <summary>
    /// 日志上下文
    /// </summary>
    public class LogContext : ILogContext {
        /// <summary>
        /// 日志上下文信息
        /// </summary>
        private LogContextInfo _info;
        /// <summary>
        /// 序号
        /// </summary>
        private int _orderId;
        /// <summary>
        /// 上下文
        /// </summary>
        private IContext _context;

        /// <summary>
        /// 初始化日志上下文
        /// </summary>
        public LogContext() {
            _orderId = 0;
        }

        /// <summary>
        /// 上下文
        /// </summary>
        public virtual IContext Context => _context ?? ( _context = ContextFactory.Create() );

        /// <summary>
        /// 日志标识
        /// </summary>
        public string LogId => $"{GetInfo().TraceId}-{++_orderId}";

        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId => $"{GetInfo().TraceId}";

        /// <summary>
        /// 计时器
        /// </summary>
        public Stopwatch Stopwatch => GetInfo().Stopwatch;

        /// <summary>
        /// IP
        /// </summary>
        public string Ip => GetInfo().Ip;
        /// <summary>
        /// 主机
        /// </summary>
        public string Host => GetInfo().Host;
        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser => GetInfo().Browser;
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url => GetInfo().Url;

        /// <summary>
        /// 获取日志上下文信息
        /// </summary>
        private LogContextInfo GetInfo() {
            if ( _info != null )
                return _info;
            var key = "Util.Logs.LogContext";
            _info = Context.Get<LogContextInfo>( key );
            if( _info != null )
                return _info;
            _info = CreateInfo();
            Context.Add( key, _info );
            return _info;
        }

        /// <summary>
        /// 创建日志上下文信息
        /// </summary>
        protected virtual LogContextInfo CreateInfo() {
            return new LogContextInfo {
                TraceId = GetTraceId(),
                Stopwatch = GetStopwatch(),
                Ip = Web.Ip,
                Host = Web.Host,
                Browser = Web.Browser,
                Url = Web.Url
            };
        }

        /// <summary>
        /// 获取跟踪号
        /// </summary>
        protected string GetTraceId() {
            var traceId = Context.TraceId;
            return string.IsNullOrWhiteSpace( traceId ) ? Id.Guid() : traceId;
        }

        /// <summary>
        /// 获取计时器
        /// </summary>
        protected Stopwatch GetStopwatch() {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            return stopwatch;
        }
    }
}
