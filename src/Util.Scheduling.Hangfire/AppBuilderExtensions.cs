using Util.Configs;

namespace Util.Scheduling;

/// <summary>
/// Hangfire后台任务操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置Hangfire后台任务操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddHangfire( this IAppBuilder builder, Action<IGlobalConfiguration> setupAction ) {
        return builder.AddHangfire( setupAction, true );
    }

    /// <summary>
    /// 配置Hangfire后台任务操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    /// <param name="serverSetupAction">服务器配置操作</param>
    public static IAppBuilder AddHangfire( this IAppBuilder builder, Action<IGlobalConfiguration> setupAction, Action<BackgroundJobServerOptions> serverSetupAction ) {
        return builder.AddHangfire( setupAction, serverSetupAction, true );
    }

    /// <summary>
    /// 配置Hangfire后台任务操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    /// <param name="isScanJobs">是否扫描加载后台任务</param>
    public static IAppBuilder AddHangfire( this IAppBuilder builder, Action<IGlobalConfiguration> setupAction, bool isScanJobs ) {
        return builder.AddHangfire( setupAction, null, isScanJobs );
    }

    /// <summary>
    /// 配置Hangfire后台任务操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    /// <param name="serverSetupAction">服务器配置操作</param>
    /// <param name="isScanJobs">是否扫描加载后台任务</param>
    public static IAppBuilder AddHangfire( this IAppBuilder builder, Action<IGlobalConfiguration> setupAction, Action<BackgroundJobServerOptions> serverSetupAction, bool isScanJobs ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            AddHangfire( services, setupAction, serverSetupAction );
            AddSchedulerBuilder( services );
            AddSchedulerOptions( services, isScanJobs );
            AddHostedService( services );
        } );
        return builder;
    }

    /// <summary>
    /// 添加Hangfire服务
    /// </summary>
    private static void AddHangfire( IServiceCollection services, Action<IGlobalConfiguration> setupAction, Action<BackgroundJobServerOptions> serverSetupAction ) {
        services.AddHangfire( setupAction );
        if ( serverSetupAction != null )
            services.Configure( serverSetupAction );
    }

    /// <summary>
    /// 添加后台任务调度器服务
    /// </summary>
    private static void AddSchedulerBuilder( IServiceCollection services ) {
        services.TryAddSingleton<ISchedulerManager, HangfireSchedulerManager>();
    }

    /// <summary>
    /// 添加后台任务调度器配置
    /// </summary>
    private static void AddSchedulerOptions( IServiceCollection services, bool isScanJobs ) {
        void Action( SchedulerOptions t ) => t.IsScanJobs = isScanJobs;
        services.Configure( (Action<SchedulerOptions>)Action );
    }

    /// <summary>
    /// 添加启动服务
    /// </summary>
    private static void AddHostedService( IServiceCollection services ) {
        services.AddHostedService<HostService>();
    }
}