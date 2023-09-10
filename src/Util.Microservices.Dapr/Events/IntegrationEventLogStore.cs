namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 集成事件日志记录存储器
/// </summary>
public class IntegrationEventLogStore : IIntegrationEventLogStore {
    /// <summary>
    /// 初始化集成事件日志记录存储器
    /// </summary>
    /// <param name="stateManager">状态管理操作</param>
    /// <param name="options">配置</param>
    public IntegrationEventLogStore( IStateManager stateManager, IOptions<DaprOptions> options ) {
        StateManager = stateManager ?? throw new ArgumentNullException( nameof( stateManager ) );
        StateManager.StoreName( options?.Value.Pubsub?.EventLogStoreName ?? "statestore" );
    }

    /// <summary>
    /// 集成事件总条数键名
    /// </summary>
    public const string KeyCount = "IntegrationEventCount";
    /// <summary>
    /// 状态管理操作
    /// </summary>
    protected IStateManager StateManager;

    /// <inheritdoc />
    public virtual async Task<IntegrationEventLog> GetAsync( string eventId, CancellationToken cancellationToken = default ) {
        return await StateManager.GetByIdAsync<IntegrationEventLog>( eventId, cancellationToken );
    }

    /// <inheritdoc />
    public virtual async Task SaveAsync( IntegrationEventLog eventLog, CancellationToken cancellationToken = default ) {
        await StateManager.SaveAsync( eventLog, cancellationToken );
    }

    /// <inheritdoc />
    public virtual async Task IncrementAsync( CancellationToken cancellationToken = default ) {
        var result = await GetIntegrationEventCount( cancellationToken );
        result.Count = result.Count.SafeValue() + 1;
        await StateManager.SaveAsync( result, cancellationToken, KeyCount );
    }

    /// <summary>
    /// 获取集成事件计数
    /// </summary>
    protected async Task<IntegrationEventCount> GetIntegrationEventCount( CancellationToken cancellationToken ) {
        return await StateManager.GetAsync<IntegrationEventCount>( KeyCount,cancellationToken ) ?? new IntegrationEventCount();
    }

    /// <inheritdoc />
    public virtual async Task<int> GetCountAsync( CancellationToken cancellationToken = default ) {
        var result = await GetIntegrationEventCount( cancellationToken );
        return result.Count.SafeValue();
    }

    /// <inheritdoc />
    public virtual async Task ClearCountAsync( CancellationToken cancellationToken = default ) {
        await StateManager.RemoveAsync( KeyCount, cancellationToken );
    }
}