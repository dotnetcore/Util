using Util.Microservices.Dapr.Events;
using Util.Microservices.Dapr.Tests.Samples;
using Util.Microservices.Events;

namespace Util.Microservices.Dapr.Tests.Events; 

/// <summary>
/// 事件发布订阅测试 - 测试日志记录
/// </summary>
public partial class PubsubTest {

    [Fact]
    public async Task Test() {
        var testEvent = new TestEvent( "a", "b" );
        
        await _eventBus.PublishAsync( testEvent );
    }

    [Fact]
    public async Task Test_2() {
        var key = "IntegrationEventLog_bb72679c-9e83-4969-8c7c-ad1eecf12f74";
        var log = await _stateManage.GetAsync<IntegrationEventLog>( key );
    }
}