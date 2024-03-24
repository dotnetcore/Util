namespace Util.Ui.Razor;

/// <summary>
/// Razor页面监听服务,当保存Razor页面时生成该页面的html文件
/// </summary>
public interface IRazorWatchService {
    /// <summary>
    /// 启动监听
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task StartAsync( CancellationToken cancellationToken );
    /// <summary>
    /// 停止监听
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task StopAsync( CancellationToken cancellationToken );
}