using Util.Configs;
using SerilogLog = Serilog.Log;

namespace Util.Logging.Serilog;

/// <summary>
/// Serilog日志操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置Serilog日志操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    public static IAppBuilder AddSerilog( this IAppBuilder builder ) {
        return builder.AddSerilog( false );
    }

    /// <summary>
    /// 配置Serilog日志操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="isClearProviders">是否清除默认设置的日志提供程序</param>
    public static IAppBuilder AddSerilog( this IAppBuilder builder, bool isClearProviders ) {
        return builder.AddSerilog( options => {
            options.IsClearProviders = isClearProviders;
        } );
    }

    /// <summary>
    /// 配置Serilog日志操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="appName">应用程序名称</param>
    public static IAppBuilder AddSerilog( this IAppBuilder builder, string appName ) {
        return builder.AddSerilog( options => {
            options.Application = appName;
        } );
    }

    /// <summary>
    /// 配置Serilog日志操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">日志配置操作</param>
    public static IAppBuilder AddSerilog( this IAppBuilder builder, Action<LogOptions> setupAction ) {
        builder.CheckNull( nameof( builder ) );
        var options = new LogOptions();
        setupAction?.Invoke( options );
        builder.Host.ConfigureServices( ( context, services ) => {
            services.AddSingleton<ILogFactory, LogFactory>();
            services.AddTransient( typeof( ILog<> ), typeof( Log<> ) );
            services.AddTransient( typeof( ILog ), t => t.GetService<ILogFactory>()?.CreateLog( "default" ) ?? NullLog.Instance );
            var configuration = context.Configuration;
            services.AddLogging( loggingBuilder => {
                if ( options.IsClearProviders )
                    loggingBuilder.ClearProviders();
                SerilogLog.Logger = new LoggerConfiguration()
                    .Enrich.WithProperty( "Application", options.Application )
                    .Enrich.FromLogContext()
                    .Enrich.WithLogLevel()
                    .Enrich.WithLogContext()
                    .ReadFrom.Configuration( configuration )
                    .ConfigLogLevel( configuration )
                    .CreateLogger();
                loggingBuilder.AddSerilog();
            } );
        } );
        return builder;
    }
}