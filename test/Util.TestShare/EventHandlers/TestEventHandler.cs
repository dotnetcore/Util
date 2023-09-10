using System.Threading;
using System.Threading.Tasks;
using Util.Events;
using Util.Exceptions;
using Util.Tests.Events;

namespace Util.Tests.EventHandlers; 

/// <summary>
/// 测试事件2处理器
/// </summary>
public class TestEvent2Handler : EventHandlerBase<TestEvent2> {
    /// <summary>
    /// 处理事件
    /// </summary>
    public override async Task HandleAsync( TestEvent2 @event, CancellationToken cancellationToken ) {
        await Task.CompletedTask;
        throw new Warning( @event.Id.ToString() );
    }
}

/// <summary>
/// 测试事件3处理器
/// </summary>
public class TestEvent3Handler : EventHandlerBase<TestEvent3> {
    /// <summary>
    /// 处理事件
    /// </summary>
    public override async Task HandleAsync( TestEvent3 @event, CancellationToken cancellationToken ) {
        await Task.CompletedTask;
        throw new Warning( @event.Id.ToString() );
    }
}