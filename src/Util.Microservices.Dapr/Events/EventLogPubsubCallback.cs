namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 发布订阅回调操作 - 集成事件日志记录
/// </summary>
public class EventLogPubsubCallback : IPubsubCallback {
    /// <summary>
    /// 初始化发布订阅回调操作
    /// </summary>
    /// <param name="store">集成事件存储器</param>
    public EventLogPubsubCallback( IIntegrationEventStore store ) {
        Store = store ?? throw new ArgumentNullException( nameof( store ) );
    }

    /// <summary>
    /// 集成事件存储器
    /// </summary>
    protected IIntegrationEventStore Store;

    /// <inheritdoc />
    public virtual async Task OnPublishBefore( PubsubArgument argument, CancellationToken cancellationToken = default ) {
        await Store.CreatePrePublishLogAsync( argument, cancellationToken );
    }

    /// <inheritdoc />
    public Task OnPublishAfter( PubsubArgument argument, CancellationToken cancellationToken = default ) {
        return Task.CompletedTask;
    }
}