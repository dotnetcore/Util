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
        public LogManager( ILogContext context ) {
            Context = context;
            Format = new ContentFormat();
        }

        /// <summary>
        /// 日志上下文
        /// </summary>
        public ILogContext Context { get; set; }

        /// <summary>
        /// 日志格式化器
        /// </summary>
        public ILogFormat Format { get; set; }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        public ILog GetLog() {
            return new Log( new NLogProvider( NLogs.LogManager.GetCurrentClassLogger(), Format ), Context );
        }
    }
}
