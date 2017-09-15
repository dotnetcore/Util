using Util.Domains.Sessions;
using Util.Logs.Abstractions;
using Util.Security;

namespace Util.Logs.Core {
    /// <summary>
    /// 内容日志操作
    /// </summary>
    public abstract class ContentLogBase : LogBase<Content> {
        /// <summary>
        /// 初始化日志操作
        /// </summary>
        /// <param name="provider">日志提供程序</param>
        /// <param name="context">日志上下文</param>
        /// <param name="session">用户上下文</param>
        /// <param name="logName">日志名称</param>
        protected ContentLogBase( ILogProvider provider, ILogContext context, ISession session, string logName ) : base( provider, context, logName ) {
            Session = session;
        }

        /// <summary>
        /// 用户上下文
        /// </summary>
        public ISession Session { get; set; }

        /// <summary>
        /// 获取日志内容
        /// </summary>
        protected override Content GetContent() {
            return new Content();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Init( Content content ) {
            base.Init( content );
            content.Application = Session.GetApplication();
            content.Tenant = Session.GetTenant();
        }
    }
}
