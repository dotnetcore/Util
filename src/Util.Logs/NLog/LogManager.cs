using Util.Domains.Sessions;
using Util.Logs.Abstractions;
using Util.Logs.Formats;
using NLogs = NLog;

namespace Util.Logs.NLog {
    /// <summary>
    /// 日志服务
    /// </summary>
    public class LogManager : ILogManager {
        /// <summary>
        /// 初始化日志服务
        /// </summary>
        /// <param name="context">日志上下文</param>
        /// <param name="session">用户上下文</param>
        public LogManager( ILogContext context, ISession session ) {
            Context = context;
            Session = session;
            Format = new ContentFormat();
        }

        /// <summary>
        /// 日志上下文
        /// </summary>
        public ILogContext Context { get; set; }

        /// <summary>
        /// 用户上下文
        /// </summary>
        public ISession Session { get; set; }

        /// <summary>
        /// 日志格式化器
        /// </summary>
        public ILogFormat Format { get; set; }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        public ILog GetLog() {
            return GetLog( string.Empty );
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="instance">实例</param>
        public ILog GetLog( object instance ) {
            if( instance == null )
                return GetLog();
            var className = instance.GetType().ToString();
            return GetLog( className );
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="logName">日志名称</param>
        public ILog GetLog( string logName ) {
            return Log.GetLog( NLogs.LogManager.GetLogger( logName ), Context, Session, Format );
        }
    }
}
