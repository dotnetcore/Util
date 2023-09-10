using System.Linq;
using Util.Microservices.Dapr.Tests.Samples;
using Util.Microservices.Events;

namespace Util.Microservices.Dapr.Tests.Events; 

/// <summary>
/// 事件发布订阅测试 - 测试日志记录
/// </summary>
public partial class PubsubTest {
    /// <summary>
    /// 测试集成事件日志记录 - 事件状态:已发布
    /// </summary>
    [Fact]
    public async Task TestIntegrationEventLog_Published() {
        //清空集成事件计数
        await _eventManager.ClearCountAsync();

        //发布事件,没有订阅者
        var testEvent = new TestEvent( "1", "test" );
        await _eventBus.Topic( "a" ).PublishAsync( testEvent );

        //获取日志记录
        var log = await _eventManager.GetAsync( testEvent.EventId );
        Assert.True( log.State == EventState.Published );

        //获取计数
        var count = await _eventManager.GetCountAsync();
        Assert.Equal( 1,count );

        //再次发布事件
        testEvent = new TestEvent( "1", "test" );
        await _eventBus.Topic( "a" ).PublishAsync( testEvent );

        //获取计数
        count = await _eventManager.GetCountAsync();
        Assert.Equal( 2, count );
    }

    /// <summary>
    /// 测试集成事件日志记录 - 事件状态:成功
    /// </summary>
    [Fact]
    public async Task TestIntegrationEventLog_Success() {
        var testEvent = new TestEvent( Id.Create(), Id.Create() );
        await _eventBus.Topic( "b" ).PublishAsync( testEvent );

        //获取日志记录
        var log = await GetSuccessEventLog( testEvent.EventId );
        Assert.True( log.State == EventState.Success );
    }

    /// <summary>
    /// 获取集成事件日志记录 - 成功状态
    /// </summary>
    private async Task<IntegrationEventLog> GetSuccessEventLog( string eventId ) {
        for ( int i = 0; i < 100; i++ ) {
            var result = await _eventManager.GetAsync( eventId );
            if ( result is { State: EventState.Success } ) {
                _logger.LogInformation( "获取集成事件日志记录成功: i={i},eventId={eventId},data={@data}", i, eventId, result );
                return result;
            }
            await Task.Delay( 100 );
        }
        return null;
    }

    /// <summary>
    /// 测试集成事件日志记录 - 事件状态:失败
    /// </summary>
    [Fact]
    public async Task TestIntegrationEventLog_Fail() {
        var testEvent = new TestEvent( Id.Create(), Id.Create() );
        await _eventBus.Topic( "c" ).PublishAsync( testEvent );

        //获取日志记录
        var log = await GetFailEventLog( testEvent.EventId );
        Assert.True( log.State == EventState.Fail );
        Assert.Contains( log.SubscriptionLogs, t => t.RetryCount == 3 );
        Assert.Contains( log.SubscriptionLogs, t => t.RetryCount.SafeValue() == 0 );
    }

    /// <summary>
    /// 获取集成事件日志记录 - 失败状态
    /// </summary>
    private async Task<IntegrationEventLog> GetFailEventLog( string eventId ) {
        for ( int i = 0; i < 100; i++ ) {
            var result = await _eventManager.GetAsync( eventId );
            if ( result is { State: EventState.Fail } && result.SubscriptionLogs.Any( t => t.RetryCount == 3 ) ) {
                _logger.LogInformation( "获取集成事件日志记录成功: i={i},eventId={eventId},data={@data}", i, eventId, result );
                return result;
            }
            await Task.Delay( 100 );
        }
        return null;
    }
}