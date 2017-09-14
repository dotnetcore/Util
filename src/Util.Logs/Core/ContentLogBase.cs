namespace Util.Logs.Core {
    /// <summary>
    /// 内容日志操作
    /// </summary>
    public abstract class ContentLogBase : LogBase {
        /// <summary>
        /// 初始化日志操作
        /// </summary>
        /// <param name="provider">日志提供程序</param>
        /// <param name="context">日志上下文</param>
        protected ContentLogBase( ILogProvider provider ,ILogContext context ) : base( provider ) {
            Context = context;
            LogContent = new Content();
        }

        /// <summary>
        /// 日志上下文
        /// </summary>
        public ILogContext Context { get; }
        /// <summary>
        /// 日志内容
        /// </summary>
        protected Content LogContent { get;  }

        /// <summary>
        /// 获取日志内容
        /// </summary>
        protected override ILogContent GetContent() {
            LogContent.TraceId = Context.TraceId;
            return LogContent;
        }
    }
}
