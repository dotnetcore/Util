namespace Util.Scheduling; 

/// <summary>
/// Hangfire调度器
/// </summary>
public class HangfireScheduler : IScheduler {
    /// <summary>
    /// Hangfire后台任务服务器
    /// </summary>
    private BackgroundJobServer _jobServer;
    /// <summary>
    /// 服务器配置
    /// </summary>
    private readonly BackgroundJobServerOptions _options;

    /// <summary>
    /// 初始化Hangfire调度器
    /// </summary>
    /// <param name="options">服务器配置</param>
    public HangfireScheduler( BackgroundJobServerOptions options ) {
        _options = options;
    }

    /// <inheritdoc />
    public virtual Task StartAsync( CancellationToken cancellationToken = default ) {
        _jobServer = new BackgroundJobServer( _options );
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public virtual Task StopAsync( CancellationToken cancellationToken = default ) {
        _jobServer.Dispose();
        return Task.CompletedTask;
    }
}