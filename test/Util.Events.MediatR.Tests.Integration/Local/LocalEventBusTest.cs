using System.Threading;
using System.Threading.Tasks;
using Util.Events.Tests.Samples;

namespace Util.Events.Tests.Local; 

/// <summary>
/// 本地事件总线测试
/// </summary>
public class LocalEventBusTest {
    /// <summary>
    /// 本地事件总线
    /// </summary>
    private readonly ILocalEventBus _eventBus;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public LocalEventBusTest( ILocalEventBus eventBus ) {
        _eventBus = eventBus;
    }

    /// <summary>
    /// 测试发布事件 - 传入事件参数是具体事件类型
    /// </summary>
    [Fact]
    public async Task TestPublishAsync() {
        var token = new CancellationTokenSource().Token;
        var @event = new EventSample { Value = "a" };
        await _eventBus.PublishAsync( @event, token );
        Assert.Equal( "1:a", @event.Result );
    }

    /// <summary>
    /// 测试发布事件 - 传入事件参数是IEvent接口
    /// </summary>
    [Fact]
    public async Task TestPublishAsync_2() {
        IEvent @event = new EventSample { Value = "a" };
        await _eventBus.PublishAsync( @event );
        Assert.Equal( "1:a", ((EventSample)@event).Result );
    }
}