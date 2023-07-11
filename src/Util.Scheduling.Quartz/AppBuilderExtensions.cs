using Util.Configs;

namespace Util.Scheduling;

/// <summary>
/// Quartz后台任务操作扩展
/// </summary>
public static class AppBuilderExtensions {
    /// <summary>
    /// 配置Quartz后台任务操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="isScanJobs">是否扫描加载后台任务</param>
    public static IAppBuilder AddQuartz( this IAppBuilder builder, bool isScanJobs = true ) {
        return builder.AddQuartz( null, isScanJobs );
    }

    /// <summary>
    /// 配置Quartz后台任务操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    public static IAppBuilder AddQuartz( this IAppBuilder builder, Action<IServiceCollectionQuartzConfigurator> setupAction ) {
        return builder.AddQuartz( setupAction, true );
    }

    /// <summary>
    /// 配置Quartz后台任务操作
    /// </summary>
    /// <param name="builder">应用生成器</param>
    /// <param name="setupAction">配置操作</param>
    /// <param name="isScanJobs">是否扫描加载后台任务</param>
    public static IAppBuilder AddQuartz( this IAppBuilder builder, Action<IServiceCollectionQuartzConfigurator> setupAction, bool isScanJobs ) {
        builder.CheckNull( nameof( builder ) );
        builder.Host.ConfigureServices( ( context, services ) => {
            AddQuartz( services, setupAction );
            AddSchedulerBuilder( services );
            AddSchedulerOptions( services, isScanJobs );
            AddHostedService( services );
        } );
        return builder;
    }

    /// <summary>
    /// 添加Quartz服务
    /// </summary>
    private static void AddQuartz( IServiceCollection services, Action<IServiceCollectionQuartzConfigurator> setupAction ) {
        if ( setupAction == null ) {
            services.AddQuartz( options => {
                options.UseMicrosoftDependencyInjectionJobFactory();
            } );
            return;
        }
        services.AddQuartz( options => {
            options.UseMicrosoftDependencyInjectionJobFactory();
            setupAction( options );
        } );
    }

    /// <summary>
    /// 添加后台任务调度器服务
    /// </summary>
    private static void AddSchedulerBuilder( IServiceCollection services ) {
        services.TryAddSingleton<ISchedulerManager, QuartzSchedulerManager>();
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