namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 集成事件存储器
/// </summary>
public interface IIntegrationEventStore : ITransientDependency {
    /// <summary>
    /// 重新发布集成事件
    /// </summary>
    /// <param name="eventId">事件标识</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task RepublishAsync( string eventId, CancellationToken cancellationToken = default );
    /// <summary>
    /// 创建准备发布状态的集成事件日志记录
    /// </summary>
    /// <param name="argument">发布订阅参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task CreatePrePublishLogAsync( PubsubArgument argument, CancellationToken cancellationToken = default );
}