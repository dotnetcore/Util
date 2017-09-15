using System;
using System.Text;
using Util.Helpers;
using Util.Logs.Abstractions;
using Util.Logs.Core;

namespace Util.Logs.Formats {
    /// <summary>
    /// 内容格式化器
    /// </summary>
    public class ContentFormat : ILogFormat {
        /// <summary>
        /// 行号
        /// </summary>
        private int _line;

        /// <summary>
        /// 初始化内容格式化器
        /// </summary>
        public ContentFormat() {
            InitLine();
        }

        /// <summary>
        /// 初始化行号
        /// </summary>
        private void InitLine() {
            _line = 1;
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="logContent">日志内容</param>
        public string Format( ILogContent logContent ) {
            var content = logContent as Content;
            if( content == null )
                return string.Empty;
            return Format( content );
        }

        /// <summary>
        /// 格式化
        /// </summary>
        private string Format( Content content ) {
            StringBuilder result = new StringBuilder();
            AppendLine( result, content, OneLine );
            AppendLine( result, content, TwoLine );
            AppendLine( result, content, ThreeLine );
            Finish( result );
            return result.ToString();
        }

        /// <summary>
        /// 添加行
        /// </summary>
        protected void AppendLine( StringBuilder result, Content content, Action<StringBuilder, Content> action ) {
            result.AppendFormat( "{0}. ", _line++ );
            action( result, content );
            result.Append( Common.Line );
        }

        /// <summary>
        /// 添加日志内容
        /// </summary>
        protected void Append( StringBuilder result, string caption, string value ) {
            if( string.IsNullOrWhiteSpace( value ) )
                return;
            result.AppendFormat( "{0}: {1}   ", caption, value );
        }

        /// <summary>
        /// 第1行
        /// </summary>
        private void OneLine( StringBuilder result, Content content ) {
            result.AppendFormat( "{0}:{1} >> ", content.Level, content.LogName );
            result.AppendFormat( "跟踪号: {0}   ", content.TraceId );
            result.AppendFormat( "操作时间: {0}   ", content.OperationTime );
            if( string.IsNullOrWhiteSpace( content.Duration ) )
                return;
            result.AppendFormat( "已执行: {0} ", content.Duration );
        }

        /// <summary>
        /// 第2行
        /// </summary>
        public void TwoLine( StringBuilder result, Content content ) {
            if( string.IsNullOrWhiteSpace( content.Url ) )
                return;
            result.AppendFormat( "Url: {0}", content.Url );
        }

        /// <summary>
        /// 第3行
        /// </summary>
        public void ThreeLine( StringBuilder result, Content content ) {
            Append( result, "业务编号", content.BusinessId );
            Append( result, "应用程序", content.Application );
            Append( result, "租户", content.Tenant );
        }

        /// <summary>
        /// 结束
        /// </summary>
        private void Finish( StringBuilder result ) {
            for( int i = 0; i < 125; i++ )
                result.Append( "-" );
            InitLine();
        }
    }
}
