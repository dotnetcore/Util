using Util.Logs.Abstractions;

namespace Util.Logs.Extensions {
    /// <summary>
    /// 日志扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public static ILog Content( this ILog log, string value, params object[] args ) {
            return log.Set<ILogContent>( content => content.ContentLine( value, args ) );
        }
    }
}
