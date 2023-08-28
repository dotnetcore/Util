namespace Util.Microservices.Events; 

/// <summary>
/// 发布订阅回调操作
/// </summary>
public interface IPubsubCallback : ISingletonDependency {
    /// <summary>
    /// 发布前操作
    /// </summary>
    /// <param name="argument">发布订阅参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task OnPublishBefore( PubsubArgument argument, CancellationToken cancellationToken = default );
    /// <summary>
    /// 发布后操作
    /// </summary>
    /// <param name="argument">发布订阅参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task OnPublishAfter( PubsubArgument argument, CancellationToken cancellationToken = default );
    /// <summary>
    /// 订阅前操作
    /// </summary>
    /// <param name="integrationEventLog">集成事件日志</param>
    /// <param name="routeUrl">订阅地址</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task OnSubscriptionBefore( IntegrationEventLog integrationEventLog,string routeUrl, CancellationToken cancellationToken = default );
    /// <summary>
    /// 订阅后操作
    /// </summary>
    /// <param name="eventId">事件标识</param>
    /// <param name="isSuccess">是否处理成功</param>
    /// <param name="message">消息</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task OnSubscriptionAfter( string eventId, bool isSuccess, string message, CancellationToken cancellationToken = default );
    /// <summary>
    /// 重新发布前操作
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task OnRepublishBefore( IntegrationEventLog eventLog, CancellationToken cancellationToken = default );
    /// <summary>
    /// 重新发布后操作
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task OnRepublishAfter( IntegrationEventLog eventLog, CancellationToken cancellationToken = default );
}