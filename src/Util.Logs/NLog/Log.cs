using Util.Domains.Sessions;
using Util.Helpers;
using Util.Logs.Abstractions;
using NLogs = NLog;
using Util.Logs.Core;
using Util.Logs.Extensions;
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
        /// <param name="session">用户上下文</param>
        /// <param name="logName">日志名称</param>
        internal Log( ILogProvider provider, ILogContext context, ISession session, string logName ) : base( provider, context, session, logName ) {
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        public static ILog GetLog() {
            return GetLog( string.Empty );
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="instance">实例</param>
        public static ILog GetLog( object instance ) {
            if( instance == null )
                return GetLog();
            var className = instance.GetType().ToString();
            return GetLog( className ).Class( className );
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="logName">日志名称</param>
        public static ILog GetLog( string logName ) {
            var context = Ioc.Create<ILogContext>();
            var session = Ioc.Create<ISession>();
            return GetLog( NLogs.LogManager.GetLogger( logName ), context, session, new ContentFormat() );
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="logger">日志操作</param>
        /// <param name="context">日志上下文</param>
        /// <param name="session">用户上下文</param>
        /// <param name="format">日志格式化器</param>
        internal static ILog GetLog( NLogs.Logger logger, ILogContext context, ISession session, ILogFormat format ) {
            return new Log( new NLogProvider( logger, format ), context, session, logger.Name );
        }
    }
}
