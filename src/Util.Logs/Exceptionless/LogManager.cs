using Util.Domains.Sessions;
using Util.Logs.Abstractions;
using Util.Logs.Core;

namespace Util.Logs.Exceptionless {
    /// <summary>
    /// 日志服务
    /// </summary>
    public class LogManager : LogManagerBase {
        /// <summary>
        /// 初始化日志服务
        /// </summary>
        /// <param name="context">日志上下文</param>
        /// <param name="session">用户上下文</param>
        public LogManager( ILogContext context, ISession session ) {
            Context = context;
            Session = session;
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
        /// 获取日志操作实例
        /// </summary>
        protected override ILog GetLog( string logName, string @class ) {
            return Log.GetLog( Context, Session, logName, @class );
        }
    }
}
