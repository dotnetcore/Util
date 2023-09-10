using Util.Microservices.Dapr.Events;
using Util.Microservices.Dapr.WebApiSample.Events;

namespace Util.Microservices.Dapr.WebApiSample.Controllers; 

/// <summary>
/// 集成事件控制器
/// </summary>
public class IntegrationEventController : IntegrationEventControllerBase {
    /// <summary>
    /// 状态管理操作
    /// </summary>
    private readonly IStateManager _stateManager;
    /// <summary>
    /// 日志操作
    /// </summary>
    private readonly ILogger _log;

    /// <summary>
    /// 初始化集成事件控制器
    /// </summary>
    public IntegrationEventController( IStateManager stateManager, ILogger<IntegrationEventController> log ) {
        _stateManager = stateManager;
        _log = log;
    }

    /// <summary>
    /// 订阅1
    /// </summary>
    [HttpPost( "WebApi_Test1" )]
    [Topic( nameof( TestEvent ) )]
    public async Task<IActionResult> Test1Async( TestEvent @event ) {
        _log.LogInformation( "========================================================WebApi_Test1:{@TestEvent}", @event );
        await _stateManager.StoreName( "event-state-store" ).AddAsync( $"webapi_{@event.Code}", @event );
        return Success();
    }

    /// <summary>
    /// 订阅B
    /// </summary>
    [HttpPost( "WebApi_B" )]
    [Topic( "b" )]
    public async Task<IActionResult> TestBAsync( TestEvent @event ) {
        _log.LogInformation( "========================================================WebApi_B:{@TestEvent}", @event );
        await Task.CompletedTask;
        return Success();
    }

    /// <summary>
    /// 订阅C
    /// </summary>
    [HttpPost( "WebApi_C" )]
    [Topic( "c" )]
    public async Task<IActionResult> TestCAsync( TestEvent @event ) {
        _log.LogInformation( "========================================================WebApi_C:{@TestEvent}", @event );
        await Task.CompletedTask;
        throw new Exception( "WebApi_Exception_C" );
        return Success();
    }
}