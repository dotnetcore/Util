using Util.Ui.Razor;

namespace Util.Ui.NgZorro;

/// <summary>
/// Razor页面监视服务
/// </summary>
public class WatchHostedService : IHostedService {
    /// <summary>
    /// Razor页面监听服务
    /// </summary>
    private readonly IRazorWatchService _service;

    /// <summary>
    /// 初始化Razor页面监视服务
    /// </summary>
    /// <param name="service">Razor页面监听服务</param>
    public WatchHostedService( IRazorWatchService service ) {
        _service = service;
    }

    /// <summary>
    /// 启动服务
    /// </summary>
    public async Task StartAsync( CancellationToken cancellationToken ) {
        await _service.StartAsync( cancellationToken );
    }

    /// <summary>
    /// 停止服务
    /// </summary>
    public async Task StopAsync( CancellationToken cancellationToken ) {
        await _service.StopAsync( cancellationToken );
    }
}