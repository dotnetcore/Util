using Serilog.Core;
using Serilog.Events;

namespace Util.Logging.Serilog.Enrichers {
    /// <summary>
    /// 日志级别扩展属性 - 用于显示标准日志级别
    /// </summary>
    public class LogLevelEnricher : ILogEventEnricher {
        /// <summary>
        /// 扩展属性
        /// </summary>
        /// <param name="logEvent">日志事件</param>
        /// <param name="propertyFactory">日志事件属性工厂</param>
        public void Enrich( LogEvent logEvent, ILogEventPropertyFactory propertyFactory ) {
            var property = propertyFactory.CreateProperty( "LogLevel", GetLogLevel( logEvent.Level ) );
            logEvent.AddOrUpdateProperty( property );
        }

        /// <summary>
        /// 获取日志级别
        /// </summary>
        private string GetLogLevel( LogEventLevel logLevel ) {
            switch ( logLevel ) {
                case LogEventLevel.Verbose:
                    return "Trace";
                case LogEventLevel.Debug:
                    return "Debug";
                case LogEventLevel.Information:
                    return "Information";
                case LogEventLevel.Warning:
                    return "Warning";
                case LogEventLevel.Error:
                    return "Error";
                case LogEventLevel.Fatal:
                    return "Critical";
                default:
                    return null;
            }
        }
    }
}
