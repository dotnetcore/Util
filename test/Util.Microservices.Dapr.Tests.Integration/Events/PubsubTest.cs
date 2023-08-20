using Util.Events;

namespace Util.Microservices.Dapr.Tests.Events;

/// <summary>
/// 事件发布订阅测试
/// </summary>
[Collection( "Global" )]
public partial class PubsubTest {
    /// <summary>
    /// 集成事件总线
    /// </summary>
    private readonly IIntegrationEventBus _eventBus;
    /// <summary>
    /// 状态管理
    /// </summary>
    private IStateManage _stateManage;
    /// <summary>
    /// 日志
    /// </summary>
    private readonly ILogger<PubsubTest> _logger;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public PubsubTest( IIntegrationEventBus eventBus, IStateManage stateManage, ILogger<PubsubTest> logger ) {
        _eventBus = eventBus;
        _stateManage = stateManage;
        _logger = logger;
    }
}