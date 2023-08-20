using Util.Microservices.Dapr.Events;
using Util.Microservices.Dapr.WebApiSample.Events;

namespace Util.Microservices.Dapr.WebApiSample.Controllers; 

/// <summary>
/// 集成事件控制器
/// </summary>
public class IntegrationEventController : IntegrationEventControllerBase {
    /// <summary>
    /// 订阅1
    /// </summary>
    [HttpPost( "Test1" )]
    [Topic( nameof( TestEvent ) )]
    public async Task<IActionResult> Test1Async( TestEvent @event ) {
        await Task.CompletedTask;
        return Success();
    }
}