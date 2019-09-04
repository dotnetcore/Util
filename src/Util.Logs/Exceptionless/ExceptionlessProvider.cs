using System.Linq;
using Exceptionless;
using Microsoft.Extensions.Logging;
using el = Exceptionless;
using NLogs = NLog;
using Util.Logs.Abstractions;
using Util.Logs.Contents;
using Util.Logs.NLog;

namespace Util.Logs.Exceptionless {
    /// <summary>
    /// Exceptionless日志提供程序
    /// </summary>
    public class ExceptionlessProvider : ILogProvider {
        /// <summary>
        /// NLog日志操作，用于控制日志级别是否启用
        /// </summary>
        private readonly NLogs.ILogger _logger;
        /// <summary>
        /// 客户端
        /// </summary>
        private readonly el.ExceptionlessClient _client;
        /// <summary>
        /// 行号
        /// </summary>
        private int _line;

        /// <summary>
        /// 初始化Exceptionless日志提供程序
        /// </summary>
        /// <param name="logName">日志名称</param>
        public ExceptionlessProvider( string logName ) {
            _logger = NLogProvider.GetLogger( logName );
            _client = el.ExceptionlessClient.Default;
        }

        /// <summary>
        /// 日志名称
        /// </summary>
        public string LogName => _logger.Name;

        /// <summary>
        /// 调试级别是否启用
        /// </summary>
        public bool IsDebugEnabled => _logger.IsDebugEnabled;

        /// <summary>
        /// 跟踪级别是否启用
        /// </summary>
        public bool IsTraceEnabled => _logger.IsTraceEnabled;

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="level">日志等级</param>
        /// <param name="content">日志内容</param>
        public void WriteLog( LogLevel level, ILogContent content ) {
            InitLine();
            var builder = CreateBuilder( level, content );
            SetUser( content );
            SetSource( builder, content );
            SetReferenceId( builder, content );
            AddProperties( builder, content as ILogConvert );
            AddTags(builder, content);
            builder.Submit();
        }

        /// <summary>
        /// 初始化行号
        /// </summary>
        private void InitLine() {
            _line = 1;
        }

        /// <summary>
        /// 创建事件生成器
        /// </summary>
        private EventBuilder CreateBuilder( LogLevel level, ILogContent content ) {
            if (content.Exception != null && (level == LogLevel.Error || level == LogLevel.Critical))
                return _client.CreateException(content.Exception);
            var builder = _client.CreateLog(GetMessage(content), ConvertTo(level));
            if (content.Exception != null && level == LogLevel.Warning)
                builder.SetException(content.Exception);
            return builder;
        }

        /// <summary>
        /// 获取日志消息
        /// </summary>
        /// <param name="content">日志内容</param>
        private string GetMessage( ILogContent content ) {
            if ( content is ICaption caption && string.IsNullOrWhiteSpace( caption.Caption ) == false )
                return caption.Caption;
            if( content.Content.Length > 0 )
                return content.Content.ToString();
            return content.LogId;
        }

        /// <summary>
        /// 转换日志等级
        /// </summary>
        private el.Logging.LogLevel ConvertTo( LogLevel level ) {
            switch( level ) {
                case LogLevel.Trace:
                    return el.Logging.LogLevel.Trace;
                case LogLevel.Debug:
                    return el.Logging.LogLevel.Debug;
                case LogLevel.Information:
                    return el.Logging.LogLevel.Info;
                case LogLevel.Warning:
                    return el.Logging.LogLevel.Warn;
                case LogLevel.Error:
                    return el.Logging.LogLevel.Error;
                case LogLevel.Critical:
                    return el.Logging.LogLevel.Fatal;
                default:
                    return el.Logging.LogLevel.Off;
            }
        }

        /// <summary>
        /// 设置用户信息
        /// </summary>
        private void SetUser( ILogContent content ) {
            if ( string.IsNullOrWhiteSpace( content.UserId ) )
                return;
            _client.Configuration.SetUserIdentity( content.UserId );
        }

        /// <summary>
        /// 设置来源
        /// </summary>
        private void SetSource( EventBuilder builder, ILogContent content ) {
            if ( string.IsNullOrWhiteSpace( content.Url ) )
                return;
            builder.SetSource( content.Url );
        }

        /// <summary>
        /// 设置跟踪号
        /// </summary>
        private void SetReferenceId( EventBuilder builder, ILogContent content ) => builder.SetReferenceId($"{content.LogId}");

        /// <summary>
        /// 添加属性集合
        /// </summary>
        private void AddProperties( EventBuilder builder, ILogConvert content ) {
            if ( content == null )
                return;
            foreach ( var parameter in content.To().OrderBy( t => t.SortId ) ) {
                if ( string.IsNullOrWhiteSpace( parameter.Value.SafeString() ) )
                    continue;
                builder.SetProperty( $"{GetLine()}. {parameter.Text}", parameter.Value );
            }
        }

        /// <summary>
        /// 添加标签
        /// </summary>
        private void AddTags(EventBuilder builder, ILogContent content) => builder.AddTags(content.Level, content.LogName, content.TraceId);

        /// <summary>
        /// 获取行号
        /// </summary>
        private string GetLine() {
            return _line++.ToString().PadLeft( 2, '0' );
        }
    }
}
