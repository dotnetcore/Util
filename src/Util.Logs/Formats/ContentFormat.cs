using System;
using System.Text;
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
            var content = logContent as LogContent;
            if( content == null )
                return string.Empty;
            return Format( content );
        }

        /// <summary>
        /// 格式化
        /// </summary>
        private string Format( LogContent content ) {
            StringBuilder result = new StringBuilder();
            Line1( result, content );
            Line2( result, content );
            Line3( result, content );
            Line4( result, content );
            Line5( result, content );
            Line6( result, content );
            Line7( result, content );
            Line8( result, content );
            Line9( result, content );
            Line10( result, content );
            Line11( result, content );
            Line12( result, content );
            Line13( result, content );
            Line14( result, content );
            Finish( result );
            return result.ToString();
        }

        /// <summary>
        /// 添加行
        /// </summary>
        protected void AppendLine( StringBuilder result, LogContent content, Action<StringBuilder, LogContent> action ) {
            result.AppendFormat( "{0}. ", _line++ );
            action( result, content );
            result.AppendLine();
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
        private void Line1( StringBuilder result, LogContent content ) {
            AppendLine( result, content, ( r, c ) => {
                r.AppendFormat( "{0}: {1} >> ", c.Level, c.LogName );
                r.AppendFormat( "跟踪号: {0}   ", c.TraceId );
                r.AppendFormat( "操作时间: {0}   ", c.OperationTime );
                if( string.IsNullOrWhiteSpace( c.Duration ) )
                    return;
                r.AppendFormat( "已执行: {0} ", c.Duration );
            } );
        }

        /// <summary>
        /// 第2行
        /// </summary>
        public void Line2( StringBuilder result, LogContent content ) {
            AppendLine( result, content, ( r, c ) => {
                Append( r, "Ip", c.Ip );
                Append( r, "主机", c.Host );
                Append( r, "线程号", c.ThreadId );
            } );
        }

        /// <summary>
        /// 第3行
        /// </summary>
        public void Line3( StringBuilder result, LogContent content ) {
            if( string.IsNullOrWhiteSpace( content.Browser ) )
                return;
            AppendLine( result, content, ( r, c ) => Append( r, "浏览器", c.Browser ) );
        }

        /// <summary>
        /// 第4行
        /// </summary>
        public void Line4( StringBuilder result, LogContent content ) {
            if( string.IsNullOrWhiteSpace( content.Url ) )
                return;
            AppendLine( result, content, ( r, c ) => r.Append( "Url: " + c.Url ) );
        }

        /// <summary>
        /// 第5行
        /// </summary>
        public void Line5( StringBuilder result, LogContent content ) {
            if( string.IsNullOrWhiteSpace( content.UserId ) && string.IsNullOrWhiteSpace( content.Operator )
                && string.IsNullOrWhiteSpace( content.Role ) )
                return;
            AppendLine( result, content, ( r, c ) => {
                Append( r, "操作人编号", c.UserId );
                Append( r, "姓名", c.Operator );
                Append( r, "角色", c.Role );
            } );
        }

        /// <summary>
        /// 第6行
        /// </summary>
        public void Line6( StringBuilder result, LogContent content ) {
            if( string.IsNullOrWhiteSpace( content.BusinessId ) && string.IsNullOrWhiteSpace( content.Tenant )
                 && string.IsNullOrWhiteSpace( content.Application ) && string.IsNullOrWhiteSpace( content.Module ) )
                return;
            AppendLine( result, content, ( r, c ) => {
                Append( r, "业务编号", c.BusinessId );
                Append( r, "租户", c.Tenant );
                Append( r, "应用程序", c.Application );
                Append( r, "模块", c.Module );
            } );
        }

        /// <summary>
        /// 第7行
        /// </summary>
        public void Line7( StringBuilder result, LogContent content ) {
            if( string.IsNullOrWhiteSpace( content.Class ) && string.IsNullOrWhiteSpace( content.Method ) )
                return;
            AppendLine( result, content, ( r, c ) => {
                Append( r, "类名", c.Class );
                Append( r, "方法", c.Method );
            } );
        }

        /// <summary>
        /// 第8行
        /// </summary>
        public void Line8( StringBuilder result, LogContent content ) {
            if( content.Params.Length == 0 )
                return;
            AppendLine( result, content, ( r, c ) => {
                r.AppendLine( "参数:" );
                r.Append( c.Params );
            } );
        }

        /// <summary>
        /// 第9行
        /// </summary>
        public void Line9( StringBuilder result, LogContent content ) {
            if( string.IsNullOrWhiteSpace( content.Caption ) )
                return;
            AppendLine( result, content, ( r, c ) => {
                r.AppendFormat( "标题: {0}", c.Caption );
            } );
        }

        /// <summary>
        /// 第10行
        /// </summary>
        public void Line10( StringBuilder result, LogContent content ) {
            if( content.Content.Length == 0 )
                return;
            AppendLine( result, content, ( r, c ) => {
                r.AppendLine( "内容:" );
                r.Append( c.Content );
            } );
        }

        /// <summary>
        /// 第11行
        /// </summary>
        public void Line11( StringBuilder result, LogContent content ) {
            if( content.Sql.Length == 0 )
                return;
            AppendLine( result, content, ( r, c ) => {
                r.AppendLine( "Sql语句:" );
                r.Append( c.Sql );
            } );
        }

        /// <summary>
        /// 第12行
        /// </summary>
        public void Line12( StringBuilder result, LogContent content ) {
            if( content.SqlParams.Length == 0 )
                return;
            AppendLine( result, content, ( r, c ) => {
                r.AppendLine( "Sql参数:" );
                r.Append( c.SqlParams );
            } );
        }

        /// <summary>
        /// 第13行
        /// </summary>
        public void Line13( StringBuilder result, LogContent content ) {
            if( string.IsNullOrWhiteSpace( content.Exception ) )
                return;
            AppendLine( result, content, ( r, c ) => {
                r.AppendLine( $"异常: { GetErrorCode( content.ErrorCode ) }" );
                r.Append( $"   { c.Exception }" );
            } );
        }

        /// <summary>
        /// 获取错误码
        /// </summary>
        private string GetErrorCode( string errorCode ) {
            if( string.IsNullOrWhiteSpace( errorCode ) )
                return string.Empty;
            return $"-- 错误码: {errorCode}";
        }

        /// <summary>
        /// 第14行
        /// </summary>
        public void Line14( StringBuilder result, LogContent content ) {
            if( string.IsNullOrWhiteSpace( content.StackTrace ) )
                return;
            AppendLine( result, content, ( r, c ) => {
                r.AppendLine( "堆栈跟踪:" );
                r.Append( c.StackTrace );
            } );
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
