using Util.Exceptions;
using Util.Microservices.Dapr.Events;
using Util.Microservices.Dapr.PubsubSample.Events;

namespace Util.Microservices.Dapr.PubsubSample.Controllers; 

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
    [HttpPost( "Pubsub_Test1" )]
    [Topic( nameof( TestEvent ) )]
    public async Task<IActionResult> Test1Async( TestEvent @event ) {
        _log.LogInformation( "========================================================Pubsub_Test1:{@TestEvent}", @event );
        await _stateManager.StoreName( "event-state-store" ).AddAsync( $"pubsub_{@event.Code}", @event );
        return Success();
    }

    /// <summary>
    /// 订阅B
    /// </summary>
    [HttpPost( "Pubsub_B" )]
    [Topic( "b" )]
    public async Task<IActionResult> TestBAsync( TestEvent @event ) {
        _log.LogInformation( "========================================================Pubsub_B:{@TestEvent}", @event );
        await Task.CompletedTask;
        return Success();
    }

    /// <summary>
    /// 订阅C
    /// </summary>
    [HttpPost( "Pubsub_C" )]
    [Topic( "c" )]
    public async Task<IActionResult> TestCAsync( TestEvent @event ) {
        _log.LogInformation( "========================================================Pubsub_C:{@TestEvent}", @event );
        await Task.CompletedTask;
        throw new Warning( "Pubsub_Warning_C" );
        return Success();
    }
}