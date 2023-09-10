namespace Util.Microservices.Events;

/// <summary>
/// 集成事件管理器
/// </summary>
public interface IIntegrationEventManager : ITransientDependency {
    /// <summary>
    /// 集成事件总条数加1
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task IncrementAsync( CancellationToken cancellationToken = default );
    /// <summary>
    /// 获取集成事件总条数
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task<int> GetCountAsync( CancellationToken cancellationToken = default );
    /// <summary>
    /// 清空集成事件总条数
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    Task ClearCountAsync( CancellationToken cancellationToken = default );
    /// <summary>
    /// 获取集成事件日志记录
    /// </summary>
    /// <param name="eventId">事件标识</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<IntegrationEventLog> GetAsync( string eventId, CancellationToken cancellationToken = default );
    /// <summary>
    /// 保存集成事件日志记录
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task SaveAsync( IntegrationEventLog eventLog, CancellationToken cancellationToken = default );
    /// <summary>
    /// 是否允许处理订阅
    /// </summary>
    /// <param name="eventId">事件标识</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<bool> CanSubscriptionAsync( string eventId, CancellationToken cancellationToken = default );
    /// <summary>
    /// 是否允许处理订阅
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    bool CanSubscription( IntegrationEventLog eventLog );
    /// <summary>
    /// 订阅是否已处理成功
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    bool IsSubscriptionSuccess( IntegrationEventLog eventLog );
    /// <summary>
    /// 创建集成事件发布日志记录
    /// </summary>
    /// <param name="argument">发布订阅参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<IntegrationEventLog> CreatePublishLogAsync( PubsubArgument argument, CancellationToken cancellationToken = default );
    /// <summary>
    /// 创建集成事件订阅日志记录
    /// </summary>
    /// <param name="eventId">事件标识</param>
    /// <param name="routeUrl">订阅地址</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<IntegrationEventLog> CreateSubscriptionLogAsync( string eventId, string routeUrl, CancellationToken cancellationToken = default );
    /// <summary>
    /// 创建集成事件订阅日志记录
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    /// <param name="routeUrl">订阅地址</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<IntegrationEventLog> CreateSubscriptionLogAsync( IntegrationEventLog eventLog, string routeUrl, CancellationToken cancellationToken = default );
    /// <summary>
    /// 集成事件订阅处理成功
    /// </summary>
    /// <param name="eventId">事件标识</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<IntegrationEventLog> SubscriptionSuccessAsync( string eventId, CancellationToken cancellationToken = default );
    /// <summary>
    /// 集成事件订阅处理成功
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<IntegrationEventLog> SubscriptionSuccessAsync( IntegrationEventLog eventLog, CancellationToken cancellationToken = default );
    /// <summary>
    /// 集成事件订阅处理失败
    /// </summary>
    /// <param name="eventId">事件标识</param>
    /// <param name="message">消息</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<IntegrationEventLog> SubscriptionFailAsync( string eventId, string message, CancellationToken cancellationToken = default );
    /// <summary>
    /// 集成事件订阅处理失败
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    /// <param name="message">消息</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task<IntegrationEventLog> SubscriptionFailAsync( IntegrationEventLog eventLog, string message, CancellationToken cancellationToken = default );
}