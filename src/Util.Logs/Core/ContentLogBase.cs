using Util.Logs.Abstractions;

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
        protected ContentLogBase( ILogProvider provider ,ILogContext context ) : base( provider, context ) {
        }

        /// <summary>
        /// 获取日志内容
        /// </summary>
        protected override Content GetContent() {
            return new Content();
        }
    }
}
