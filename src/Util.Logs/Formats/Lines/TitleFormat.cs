using System.Text;
using Util.Logs.Core;

namespace Util.Logs.Formats.Lines {
    /// <summary>
    /// 标题格式化器
    /// </summary>
    public class TitleFormat : FormatBase {
        /// <summary>
        /// 格式化
        /// </summary>
        public override void Format( StringBuilder result, Content content ) {
            AddLevel( result, content );
            AddTraceId( result, content );
            AddTime( result, content );
            AddTotalSeconds( result, content );
        }

        /// <summary>
        /// 添加日志级别
        /// </summary>
        private void AddLevel( StringBuilder result, Content content ) {
            //result.AppendFormat( "{0}:{1} >> ", content.Level, content.LogName );
        }

        /// <summary>
        /// 添加跟踪号
        /// </summary>
        private void AddTraceId( StringBuilder result, Content content ) {
            result.AppendFormat( "跟踪号: {0}   ", content.TraceId );
        }

        /// <summary>
        /// 添加操作时间
        /// </summary>
        private void AddTime( StringBuilder result, Content content ) {
            result.AppendFormat( "操作时间: {0}   ", content.OperationTime );
        }

        /// <summary>
        /// 添加已执行时间
        /// </summary>
        private void AddTotalSeconds( StringBuilder result, Content content ) {
            //if ( string.IsNullOrWhiteSpace( content.Duration ) )
            //    return;
            //result.AppendFormat( "已执行: {0} 秒", content.Duration );
        }
    }
}
