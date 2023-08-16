namespace Util.Events; 

/// <summary>
/// 本地事件处理器基类
/// </summary>
/// <typeparam name="TEvent">事件类型</typeparam>
public abstract class EventHandlerBase<TEvent> : IEventHandler<TEvent>, ILocalEventHandler where TEvent : IEvent {
    /// <summary>
    /// 处理事件
    /// </summary>
    /// <param name="event">事件</param>
    /// <param name="cancellationToken">取消令牌</param>
    public abstract Task HandleAsync( TEvent @event, CancellationToken cancellationToken );

    /// <summary>
    /// 序号
    /// </summary>
    public virtual int Order => 0;

    /// <summary>
    /// 是否启用
    /// </summary>
    public virtual bool Enabled => true;
}