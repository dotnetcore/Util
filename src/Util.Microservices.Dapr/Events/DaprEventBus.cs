namespace Util.Microservices.Dapr.Events;

/// <summary>
/// Dapr事件总线
/// </summary>
[Ioc(1)]
public class DaprEventBus : IEventBus {
    /// <summary>
    /// 本地事件总线
    /// </summary>
    private readonly ILocalEventBus _localEventBus;
    /// <summary>
    /// 集成事件总线
    /// </summary>
    private readonly IIntegrationEventBus _integrationEventBus;

    /// <summary>
    /// 初始化Dapr事件总线
    /// </summary>
    /// <param name="localEventBus">本地事件总线</param>
    /// <param name="integrationEventBus">集成事件总线</param>
    public DaprEventBus( ILocalEventBus localEventBus, IIntegrationEventBus integrationEventBus ) {
        _localEventBus = localEventBus ?? throw new ArgumentNullException( nameof( localEventBus ) );
        _integrationEventBus = integrationEventBus ?? throw new ArgumentNullException( nameof( integrationEventBus ) );
    }

    /// <inheritdoc />
    public async Task PublishAsync<TEvent>( TEvent @event, CancellationToken cancellationToken = default ) where TEvent : IEvent {
        await _localEventBus.PublishAsync( @event, cancellationToken );
        if ( @event is not IIntegrationEvent integrationEvent  )
            return;
        await _integrationEventBus.PublishAsync( integrationEvent, cancellationToken );
    }
}