namespace Util.Scheduling; 

/// <summary>
/// 后台任务调度器
/// </summary>
public interface IScheduler {
    /// <summary>
    /// 启动
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task StartAsync( CancellationToken cancellationToken = default );
    /// <summary>
    /// 停止
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task StopAsync( CancellationToken cancellationToken = default );
}