namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 空发布订阅回调操作
/// </summary>
[Ioc(-2)]
public class NullPubsubCallback : IPubsubCallback {
    /// <summary>
    /// 空发布订阅回调操作实例
    /// </summary>
    public static readonly IPubsubCallback Instance = new NullPubsubCallback();

    /// <inheritdoc />
    public Task OnPublishBefore( PubsubArgument argument ) {
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task OnPublishAfter( PubsubArgument argument ) {
        return Task.CompletedTask;
    }
}