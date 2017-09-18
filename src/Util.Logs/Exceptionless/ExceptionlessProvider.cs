using Exceptionless;
using Microsoft.Extensions.Logging;
using el = Exceptionless;
using Util.Logs.Abstractions;
using Util.Logs.Contents;

namespace Util.Logs.Exceptionless {
    /// <summary>
    /// Exceptionless日志提供程序
    /// </summary>
    public class ExceptionlessProvider : ILogProvider {
        /// <summary>
        /// 客户端
        /// </summary>
        private readonly el.ExceptionlessClient _client;

        /// <summary>
        /// 初始化Exceptionless日志提供程序
        /// </summary>
        /// <param name="logName">日志名称</param>
        public ExceptionlessProvider( string logName ) {
            _client = el.ExceptionlessClient.Default;
            LogName = logName;
        }

        /// <summary>
        /// 日志名称
        /// </summary>
        public string LogName { get; }

        /// <summary>
        /// 调试级别是否启用
        /// </summary>
        public bool IsDebugEnabled { get; }

        /// <summary>
        /// 跟踪级别是否启用
        /// </summary>
        public bool IsTraceEnabled { get; }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="level">日志等级</param>
        /// <param name="content">日志内容</param>
        public void WriteLog( LogLevel level, ILogContent content ) {
            var builder = CreateBuilder( level, content );
            AddProperties( builder, content as ILogConvert );
            builder.Submit();
        }

        /// <summary>
        /// 创建事件生成器
        /// </summary>
        private EventBuilder CreateBuilder( LogLevel level, ILogContent content ) {
            if( content.Exception != null )
                return _client.CreateException( content.Exception );
            return _client.CreateLog( GetMessage( content ), ConvertTo( level ) );
        }

        /// <summary>
        /// 获取日志消息
        /// </summary>
        /// <param name="content">日志内容</param>
        private string GetMessage( ILogContent content ) {
            if( content is ICaption caption )
                return caption.Caption;
            if( content.Content.Length > 0 )
                return content.Content.ToString();
            return content.TraceId;
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
        /// 添加属性集合
        /// </summary>
        private void AddProperties( EventBuilder builder, ILogConvert content ) {
            if ( content == null )
                return;
            foreach ( var parameter in content.To() )
                builder.SetProperty( parameter.Key, parameter.Value );
        }
    }
}
