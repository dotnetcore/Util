using Util.Configs;
using SerilogLog = Serilog.Log;

namespace Util.Logging.Serilog;

/// <summary>
/// Exceptionless日志操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置Serilog日志操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="configAction">Exceptionless日志配置操作</param>
    /// <param name="isClearProviders">是否清除默认设置的日志提供程序</param>
    public static IAppBuilder AddSerilog( this IAppBuilder builder, Action<SerilogExceptionlessConfiguration> configAction, bool isClearProviders = false ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            var config = new SerilogExceptionlessConfiguration();
            configAction( config );
            services.AddSingleton<ILogFactory, LogFactory>();
            services.AddTransient( typeof( ILog<> ), typeof( Log<> ) );
            services.AddTransient( typeof( ILog ), t => t.GetService<ILogFactory>()?.CreateLog( "default" ) ?? NullLog.Instance );
            var configuration = context.Configuration;
            services.AddLogging( loggingBuilder => {
                if ( isClearProviders )
                    loggingBuilder.ClearProviders();
                ConfigExceptionless( config.ConfigAction, configuration );
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
        } );
        return builder;
    }

    /// <summary>
    /// 配置Exceptionless
    /// </summary>
    private static void ConfigExceptionless( Action<ExceptionlessConfiguration> configAction, IConfiguration configuration ) {
        ExceptionlessClient.Default.Startup();
        if ( configAction != null ) {
            configAction( ExceptionlessClient.Default.Configuration );
            ConfigLogLevel( configuration, ExceptionlessClient.Default.Configuration );
            return;
        }
        ExceptionlessClient.Default.Configuration.ReadFromConfiguration( configuration );
        ConfigLogLevel( configuration, ExceptionlessClient.Default.Configuration );
    }

    /// <summary>
    /// 配置日志级别
    /// </summary>
    private static void ConfigLogLevel( IConfiguration configuration, ExceptionlessConfiguration options ) {
        var section = configuration.GetSection( "Logging:LogLevel" );
        foreach ( var item in section.GetChildren() ) {
            if ( item.Key == "Default" ) {
                options.Settings.Add( "@@log:*", GetLogLevel( item.Value ) );
                continue;
            }
            options.Settings.Add( $"@@log:{item.Key}*", GetLogLevel( item.Value ) );
        }
    }

    /// <summary>
    /// 获取日志级别
    /// </summary>
    private static string GetLogLevel( string logLevel ) {
        switch ( logLevel.ToUpperInvariant() ) {
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