namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 集成事件日志记录存储器
/// </summary>
public class IntegrationEventLogStore : IIntegrationEventLogStore {
    /// <summary>
    /// 初始化集成事件日志记录存储器
    /// </summary>
    /// <param name="stateManage">状态管理操作</param>
    /// <param name="options">配置</param>
    public IntegrationEventLogStore( IStateManage stateManage, IOptions<DaprOptions> options ) {
        StateManage = stateManage ?? throw new ArgumentNullException( nameof( stateManage ) );
        StateManage.StoreName( options?.Value.Pubsub?.EventLogStoreName ?? "statestore" );
    }

    /// <summary>
    /// 状态管理操作
    /// </summary>
    protected IStateManage StateManage;

    /// <inheritdoc />
    public virtual async Task<IntegrationEventLog> GetAsync( string eventId, CancellationToken cancellationToken = default ) {
        return await StateManage.GetByIdAsync<IntegrationEventLog>( eventId, cancellationToken );
    }

    /// <summary>
    /// 保存集成事件日志记录
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    /// <param name="cancellationToken">取消令牌</param>
    public virtual async Task SaveAsync( IntegrationEventLog eventLog, CancellationToken cancellationToken = default ) {
        await StateManage.SaveAsync( eventLog, cancellationToken );
    }
}