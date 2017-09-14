using Util.Helpers;
using NLogs = NLog;
using Util.Logs.Core;
using Util.Logs.Formats;

namespace Util.Logs.NLog {
    /// <summary>
    /// 日志
    /// </summary>
    public class Log : ContentLogBase {
        /// <summary>
        /// 初始化日志操作
        /// </summary>
        /// <param name="provider">日志提供程序</param>
        /// <param name="context">日志上下文</param>
        internal Log( ILogProvider provider, ILogContext context ) : base( provider, context ) {
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        public static ILog GetLog() {
            var context = Ioc.Create<ILogContext>();
            return new Log( new NLogProvider( NLogs.LogManager.GetCurrentClassLogger(),new ContentFormat() ), context );
        }
    }
}
