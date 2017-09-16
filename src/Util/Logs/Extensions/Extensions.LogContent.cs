using System.Text;
using Util.Logs.Abstractions;

namespace Util.Logs.Extensions {
    /// <summary>
    /// 日志扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 追加内容
        /// </summary>
        public static void Append( this ILogContent content, StringBuilder result, string value, params object[] args ) {
            if( args == null || args.Length == 0 ) {
                result.Append( value );
                return;
            }
            result.AppendFormat( value, args );
        }

        /// <summary>
        /// 追加内容并换行
        /// </summary>
        public static void AppendLine( this ILogContent content, StringBuilder result, string value, params object[] args ) {
            content.Append( result, value, args );
            result.AppendLine();
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="content">日志内容</param>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public static void Content( this ILogContent content, string value, params object[] args ) {
            content.Append( content.Content, value, args );
        }

        /// <summary>
        /// 设置内容并换行
        /// </summary>
        /// <param name="content">日志内容</param>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public static void ContentLine( this ILogContent content, string value, params object[] args ) {
            content.AppendLine( content.Content, value, args );
        }
    }
}
