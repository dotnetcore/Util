using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Util.Logging.Serilog {
    /// <summary>
    /// Serilog日志配置操作扩展
    /// </summary>
    public static class LoggerConfigurationExtensions {
        /// <summary>
        /// 配置Serilog日志级别
        /// </summary>
        /// <param name="source">Serilog日志配置</param>
        /// <param name="configuration">配置</param>
        public static LoggerConfiguration ConfigLogLevel( this LoggerConfiguration source, IConfiguration configuration ) {
            source.CheckNull( nameof( source ) );
            configuration.CheckNull( nameof( configuration ) );
            var section = configuration.GetSection( "Logging:LogLevel" );
            foreach ( var item in section.GetChildren() ) {
                if ( item.Key == "Default" ) {
                    source.MinimumLevel.ControlledBy( new LoggingLevelSwitch( GetLogLevel( item.Value ) ) );
                    continue;
                }
                source.MinimumLevel.Override( item.Key, GetLogLevel( item.Value ) );
            }
            return source;
        }

        /// <summary>
        /// 获取日志级别
        /// </summary>
        private static LogEventLevel GetLogLevel( string logLevel ) {
            switch ( logLevel.ToUpperInvariant() ) {
                case "TRACE":
                    return LogEventLevel.Verbose;
                case "DEBUG":
                    return LogEventLevel.Debug;
                case "INFORMATION":
                    return LogEventLevel.Information;
                case "ERROR":
                    return LogEventLevel.Error;
                case "CRITICAL":
                    return LogEventLevel.Fatal;
                case "NONE":
                    return LogEventLevel.Fatal;
                default:
                    return LogEventLevel.Warning;
            }
        }
    }
}
