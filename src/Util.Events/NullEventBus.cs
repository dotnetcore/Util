namespace Util.Events; 

/// <summary>
/// 空事件总线
/// </summary>
public class NullEventBus : ILocalEventBus {
    /// <summary>
    /// 空事件总线实例
    /// </summary>
    public static readonly ILocalEventBus Instance = new NullEventBus();

    /// <summary>
    /// 发布事件
    /// </summary>
    /// <typeparam name="TEvent">事件类型</typeparam>
    /// <param name="event">事件</param>
    /// <param name="cancellationToken">取消令牌</param>
    public Task PublishAsync<TEvent>( TEvent @event, CancellationToken cancellationToken = default ) where TEvent : IEvent {
        return Task.CompletedTask;
    }
}