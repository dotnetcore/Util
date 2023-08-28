namespace Util.Events;

/// <summary>
/// 空事件总线
/// </summary>
[Ioc(-9)]
public class NullEventBus : IEventBus {
    /// <summary>
    /// 空事件总线实例
    /// </summary>
    public static readonly IEventBus Instance = new NullEventBus();

    /// <inheritdoc />
    public Task PublishAsync<TEvent>( TEvent @event, CancellationToken cancellationToken = default ) where TEvent : IEvent {
        return Task.CompletedTask;
    }
}

/// <summary>
/// 空事件总线
/// </summary>
[Ioc( -9 )]
public class NullLocalEventBus : ILocalEventBus {
    /// <summary>
    /// 空事件总线实例
    /// </summary>
    public static readonly ILocalEventBus Instance = new NullLocalEventBus();

    /// <inheritdoc />
    public Task PublishAsync<TEvent>( TEvent @event, CancellationToken cancellationToken = default ) where TEvent : IEvent {
        return Task.CompletedTask;
    }
}

/// <summary>
/// 空事件总线
/// </summary>
[Ioc( -9 )]
public class NullIntegrationEventBus : IIntegrationEventBus {
    /// <summary>
    /// 空事件总线实例
    /// </summary>
    public static readonly IIntegrationEventBus Instance = new NullIntegrationEventBus();

    /// <inheritdoc />
    public IIntegrationEventBus SendNow( bool isSend = true ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus PubsubName( string pubsubName ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus Topic( string topic ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus Header( string key, string value ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus Header( IDictionary<string, string> headers ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus ImportHeader( string key ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus ImportHeader( IEnumerable<string> keys ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus RemoveHeader( string key ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus Metadata( string key, string value ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus Metadata( IDictionary<string, string> metadata ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus RemoveMetadata( string key ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus Type( string value ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus OnBefore( Func<IIntegrationEvent, Dictionary<string, string>, Dictionary<string, string>, bool> action ) {
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus OnAfter( Func<IIntegrationEvent, Dictionary<string, string>, Dictionary<string, string>, Task> action ) {
        return this;
    }

    /// <inheritdoc />
    public Task PublishAsync<TEvent>( TEvent @event, CancellationToken cancellationToken = default ) where TEvent : IIntegrationEvent {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task RepublishAsync( string eventId, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }
}