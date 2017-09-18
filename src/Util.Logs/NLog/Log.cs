using Util.Domains.Sessions;
using Util.Helpers;
using Util.Logs.Abstractions;
using Util.Logs.Contents;
using NLogs = NLog;
using Util.Logs.Core;
using Util.Logs.Formats;
using Util.Security;

namespace Util.Logs.NLog {
    /// <summary>
    /// 日志
    /// </summary>
    public class Log : LogBase<LogContent> {
        /// <summary>
        /// 类名
        /// </summary>
        private readonly string _class;

        /// <summary>
        /// 初始化日志操作
        /// </summary>
        /// <param name="provider">日志提供程序</param>
        /// <param name="context">日志上下文</param>
        /// <param name="session">用户上下文</param>
        /// <param name="class">类名</param>
        internal Log( ILogProvider provider, ILogContext context, ISession session, string @class ) : base( provider, context, session ) {
            _class = @class;
        }

        /// <summary>
        /// 获取日志内容
        /// </summary>
        protected override LogContent GetContent() {
            return new LogContent { Class = _class };
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Init( LogContent content ) {
            base.Init( content );
            content.Tenant = Session.GetTenant();
            content.Application = Session.GetApplication();
            content.Operator = Session.GetFullName();
            content.Role = Session.GetRoleName();
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
            return GetLog( className, className );
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="logName">日志名称</param>
        public static ILog GetLog( string logName ) {
            return GetLog( logName, string.Empty );
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        private static ILog GetLog( string logName, string @class ) {
            var context = Ioc.Create<ILogContext>();
            var session = Ioc.Create<ISession>();
            return GetLog( NLogs.LogManager.GetLogger( logName ), new ContentFormat(), context, session, @class );
        }

        /// <summary>
        /// 获取日志操作实例
        /// </summary>
        /// <param name="logger">日志操作</param>
        /// <param name="format">日志格式化器</param>
        /// <param name="context">日志上下文</param>
        /// <param name="session">用户上下文</param>
        /// <param name="class">类名</param>
        internal static ILog GetLog( NLogs.Logger logger, ILogFormat format, ILogContext context, ISession session, string @class ) {
            return new Log( new NLogProvider( logger, format ), context, session, @class );
        }
    }
}
