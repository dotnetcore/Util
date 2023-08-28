namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 空发布订阅回调操作
/// </summary>
[Ioc(-9)]
public class NullPubsubCallback : IPubsubCallback {
    /// <summary>
    /// 空发布订阅回调操作实例
    /// </summary>
    public static readonly IPubsubCallback Instance = new NullPubsubCallback();

    /// <inheritdoc />
    public Task OnPublishBefore( PubsubArgument argument, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task OnPublishAfter( PubsubArgument argument, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task OnSubscriptionBefore( IntegrationEventLog integrationEventLog, string routeUrl, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task OnSubscriptionAfter( string eventId, bool isSuccess,string message, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task OnRepublishBefore( IntegrationEventLog eventLog, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task OnRepublishAfter( IntegrationEventLog eventLog, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }
}