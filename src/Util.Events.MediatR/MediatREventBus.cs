namespace Util.Events;

/// <summary>
/// 基于MediatR的本地事件总线
/// </summary>
public class MediatREventBus : ILocalEventBus {
    /// <summary>
    /// 事件发布器
    /// </summary>
    private readonly IMediator _publisher;

    /// <summary>
    /// 初始化基于MediatR的本地事件总线
    /// </summary>
    /// <param name="publisher">事件发布器</param>
    public MediatREventBus( IMediator publisher ) {
        _publisher = publisher ?? throw new ArgumentNullException( nameof( publisher ) );
    }

    /// <inheritdoc />
    public async Task PublishAsync<TEvent>( TEvent @event,CancellationToken cancellationToken = default ) where TEvent : IEvent {
        cancellationToken.ThrowIfCancellationRequested();
        if ( @event == null )
            return;
        await _publisher.Publish( @event, cancellationToken );
    }
}