namespace Util.Events;

/// <summary>
/// 基于MediatR的本地事件处理器基类
/// </summary>
/// <typeparam name="TEvent">事件类型</typeparam>
public abstract class EventHandlerBase<TEvent> : INotificationHandler<TEvent> where TEvent : IEvent, INotification {
    /// <summary>
    /// 是否启用
    /// </summary>
    public virtual bool Enabled => true;

    /// <summary>
    /// 处理事件
    /// </summary>
    /// <param name="event">事件</param>
    /// <param name="cancellationToken">取消令牌</param>
    public async Task Handle( TEvent @event, CancellationToken cancellationToken ) {
        if ( Enabled == false )
            return;
        await HandleAsync( @event, cancellationToken );
    }

    /// <summary>
    /// 处理事件
    /// </summary>
    /// <param name="event">事件</param>
    /// <param name="cancellationToken">取消令牌</param>
    public abstract Task HandleAsync( TEvent @event, CancellationToken cancellationToken );
}