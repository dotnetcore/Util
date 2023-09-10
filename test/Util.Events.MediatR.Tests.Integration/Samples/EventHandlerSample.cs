using System.Threading;
using System.Threading.Tasks;

namespace Util.Events.Tests.Samples; 

/// <summary>
/// 本地事件处理器样例
/// </summary>
public class EventHandlerSample : EventHandlerBase<EventSample> {
    /// <summary>
    /// 处理事件
    /// </summary>
    /// <param name="event">事件</param>
    /// <param name="cancellationToken">取消令牌</param>
    public override Task HandleAsync( EventSample @event, CancellationToken cancellationToken = default ) {
        @event.Result = $"1:{@event.Value}";
        return Task.CompletedTask;
    }
}

/// <summary>
/// 本地事件处理器样例2
/// </summary>
public class EventHandlerSample2 : EventHandlerBase<EventSample2> {
    /// <summary>
    /// 处理事件
    /// </summary>
    /// <param name="event">事件</param>
    /// <param name="cancellationToken">取消令牌</param>
    public override Task HandleAsync( EventSample2 @event, CancellationToken cancellationToken = default ) {
        @event.Result += "2";
        return Task.CompletedTask;
    }
}


/// <summary>
/// 本地事件处理器样例4
/// </summary>
public class EventHandlerSample4 : EventHandlerBase<EventSample3> {
    /// <summary>
    /// 处理事件
    /// </summary>
    /// <param name="event">事件</param>
    /// <param name="cancellationToken">取消令牌</param>
    public override Task HandleAsync( EventSample3 @event, CancellationToken cancellationToken = default ) {
        @event.Result += "3";
        return Task.CompletedTask;
    }
}