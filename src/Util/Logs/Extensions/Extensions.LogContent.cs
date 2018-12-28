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
        public static void Append( this ILogContent content, StringBuilder result, string value ) {
            if( string.IsNullOrWhiteSpace( value ) )
                return;
            result.Append( value );
        }

        /// <summary>
        /// 追加内容并换行
        /// </summary>
        public static void AppendLine( this ILogContent content, StringBuilder result, string value ) {
            content.Append( result, value );
            result.AppendLine();
        }

        /// <summary>
        /// 设置内容并换行
        /// </summary>
        /// <param name="content">日志内容</param>
        /// <param name="value">值</param>
        public static void Content( this ILogContent content, string value ) {
            content.AppendLine( content.Content, value );
        }
    }
}
