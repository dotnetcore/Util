using Util.Events;
using Util.Microservices.Dapr.Tests.Samples;
using Util.Microservices.Events;

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
    private readonly IStateManager _stateManager;
    /// <summary>
    /// 集成事件日志记录存储器
    /// </summary>
    private readonly IIntegrationEventLogStore _eventLogStore;
    /// <summary>
    /// 集成事件管理器
    /// </summary>
    private readonly IIntegrationEventManager _eventManager;
    /// <summary>
    /// 日志
    /// </summary>
    private readonly ILogger<PubsubTest> _logger;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public PubsubTest( IIntegrationEventBus eventBus, IStateManager stateManager, IIntegrationEventLogStore eventLogStore,
        IIntegrationEventManager eventManager,ILogger<PubsubTest> logger ) {
        _eventBus = eventBus;
        _eventManager = eventManager;
        _stateManager = stateManager;
        _eventLogStore = eventLogStore;
        _logger = logger;
    }

    /// <summary>
    /// 测试发布订阅
    /// </summary>
    [Fact]
    public async Task TestPublishAsync() {
        var code = Id.Create();
        var name = Id.Create();
        var testEvent = new TestEvent( code, name );
        await _eventBus.PublishAsync( testEvent );

        //验证webapi订阅写入的数据
        var result = await GetResult( $"webapi_{code}" );
        Assert.NotNull( result );

        //验证pubsub订阅写入的数据
        result = await GetResult( $"pubsub_{code}" );
        Assert.NotNull( result );
    }

    /// <summary>
    /// 获取测试结果 - 由订阅服务写入的数据
    /// </summary>
    private async Task<TestEvent> GetResult( string key ) {
        for ( int i = 0; i < 100; i++ ) {
            var result = await _stateManager.StoreName( "event-state-store" ).GetAsync<TestEvent>( key );
            if ( result != null ) {
                _logger.LogInformation( "成功获取事件发布订阅测试数据: i={i},key={key},data={@data}", i, key, result );
                return result;
            }
            await Task.Delay( 100 );
        }
        return null;
    }

    /// <summary>
    /// 测试重新发布集成事件
    /// </summary>
    [Fact]
    public async Task TestRepublishAsync() {
        var testEvent = new TestEvent( Id.Create(), Id.Create() );
        await _eventBus.Topic( "c" ).PublishAsync( testEvent );

        //执行失败
        var log = await GetFailEventLog( testEvent.EventId );
        Assert.True( log.State == EventState.Fail );
        
        //重发事件
        await _eventBus.RepublishAsync( testEvent.EventId );

        //验证
        log = await GetFailEventLog( testEvent.EventId );
        Assert.Contains( log.SubscriptionLogs, t => t.RetryLogs?.Count == 7 );
        Assert.Contains( log.SubscriptionLogs, t => t.RetryLogs?.Count == 2 );
    }
}