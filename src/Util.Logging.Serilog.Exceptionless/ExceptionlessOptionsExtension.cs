using System;
using Exceptionless;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Util.Configs;
using SerilogLog = Serilog.Log;

namespace Util.Logging.Serilog {
    /// <summary>
    /// Exceptionless日志操作配置扩展
    /// </summary>
    public class ExceptionlessOptionsExtension : OptionsExtensionBase {
        /// <summary>
        /// Exceptionless日志配置操作
        /// </summary>
        private readonly Action<ExceptionlessConfiguration> _configAction;
        /// <summary>
        /// 是否清除日志提供程序
        /// </summary>
        private readonly bool _isClearProviders;

        /// <summary>
        /// 初始化Exceptionless日志操作配置扩展
        /// </summary>
        /// <param name="configAction">Exceptionless日志配置操作</param>
        /// <param name="isClearProviders">是否清除日志提供程序</param>
        public ExceptionlessOptionsExtension( Action<ExceptionlessConfiguration> configAction, bool isClearProviders ) {
            _configAction = configAction;
            _isClearProviders = isClearProviders;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            services.AddSingleton<ILogFactory, LogFactory>();
            services.AddTransient( typeof( ILog<> ), typeof( Log<> ) );
            services.AddTransient( typeof( ILog ), t => t.GetService<ILogFactory>()?.CreateLog( "default" ) ?? NullLog.Instance );
            var configuration = context.Configuration;
            services.AddLogging( loggingBuilder => {
                if ( _isClearProviders )
                    loggingBuilder.ClearProviders();
                ConfigExceptionless( configuration );
                SerilogLog.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .Enrich.WithLogLevel()
                    .Enrich.WithLogContext()
                    .WriteTo.Exceptionless()
                    .ReadFrom.Configuration( configuration )
                    .ConfigLogLevel( configuration )
                    .CreateLogger();
                loggingBuilder.AddSerilog();
            } );
        }

        /// <summary>
        /// 配置Exceptionless
        /// </summary>
        private void ConfigExceptionless( IConfiguration configuration ) {
            ExceptionlessClient.Default.Startup();
            if ( _configAction != null ) {
                _configAction( ExceptionlessClient.Default.Configuration );
                ConfigLogLevel( configuration, ExceptionlessClient.Default.Configuration );
                return;
            }
            ExceptionlessClient.Default.Configuration.ReadFromConfiguration( configuration );
            ConfigLogLevel( configuration, ExceptionlessClient.Default.Configuration );
        }

        /// <summary>
        /// 配置日志级别
        /// </summary>
        private void ConfigLogLevel( IConfiguration configuration, ExceptionlessConfiguration options ) {
            var section = configuration.GetSection( "Logging:LogLevel" );
            foreach( var item in section.GetChildren() ) {
                if( item.Key == "Default" ) {
                    options.Settings.Add( "@@log:*", GetLogLevel( item.Value ) );
                    continue;
                }
                options.Settings.Add( $"@@log:{item.Key}*", GetLogLevel( item.Value ) );
            }
        }

        /// <summary>
        /// 获取日志级别
        /// </summary>
        private string GetLogLevel( string logLevel ) {
            switch( logLevel.ToUpperInvariant() ) {
                case "TRACE":
                    return "Trace";
                case "DEBUG":
                    return "Debug";
                case "INFORMATION":
                    return "Info";
                case "ERROR":
                    return "Error";
                case "CRITICAL":
                    return "Fatal";
                case "NONE":
                    return "Off";
                default:
                    return "Warn";
            }
        }
    }
}
