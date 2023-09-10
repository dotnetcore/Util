namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 发布订阅回调操作 - 集成事件日志记录
/// </summary>
public class EventLogPubsubCallback : IPubsubCallback {
    /// <summary>
    /// 初始化发布订阅回调操作
    /// </summary>
    /// <param name="manager">集成事件管理器</param>
    public EventLogPubsubCallback( IIntegrationEventManager manager ) {
        Manager = manager ?? throw new ArgumentNullException( nameof( manager ) );
    }

    /// <summary>
    /// 集成事件管理器
    /// </summary>
    protected IIntegrationEventManager Manager;

    /// <inheritdoc />
    public virtual Task OnPublishBefore( PubsubArgument argument, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public virtual async Task OnPublishAfter( PubsubArgument argument, CancellationToken cancellationToken = default ) {
        var result = await Manager.CreatePublishLogAsync( argument, cancellationToken );
        if ( result == NullIntegrationEventLog.Instance )
            return;
        await Manager.IncrementAsync( cancellationToken );
    }

    /// <inheritdoc />
    public virtual async Task OnSubscriptionBefore( IntegrationEventLog eventLog, string routeUrl, CancellationToken cancellationToken = default ) {
        await Manager.CreateSubscriptionLogAsync( eventLog, routeUrl, cancellationToken );
    }

    /// <inheritdoc />
    public virtual async Task OnSubscriptionAfter( string eventId, bool isSuccess,string message, CancellationToken cancellationToken = default ) {
        if ( isSuccess ) {
            await Manager.SubscriptionSuccessAsync( eventId, cancellationToken );
            return;
        }
        await Manager.SubscriptionFailAsync( eventId, message, cancellationToken );
    }

    /// <inheritdoc />
    public virtual Task OnRepublishBefore( IntegrationEventLog eventLog, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public virtual Task OnRepublishAfter( IntegrationEventLog eventLog, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }
}