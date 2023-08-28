namespace Util.Microservices.Events;

/// <summary>
/// 集成事件日志记录存储器
/// </summary>
public interface IIntegrationEventLogStore : ITransientDependency {
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
}