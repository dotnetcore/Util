using System.Text;
using Util.Logs.Core;

namespace Util.Logs.Formats.Lines {
    /// <summary>
    /// 日志消息格式器
    /// </summary>
    public abstract class FormatBase {
        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="result">结果</param>
        /// <param name="content">内容</param>
        public abstract void Format( StringBuilder result, Content content );

        /// <summary>
        /// 添加日志内容
        /// </summary>
        protected void Append( StringBuilder result, string caption,string value ) {
            if ( string.IsNullOrWhiteSpace( value ) )
                return;
            result.AppendFormat( "{0}: {1}   ", caption, value );
        }
    }
}
