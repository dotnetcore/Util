namespace Util.Microservices.Dapr.StateManagements;

/// <summary>
/// Dapr状态管理
/// </summary>
public class DaprStateManage : IStateManage {
    /// <summary>
    /// Dapr客户端
    /// </summary>
    protected readonly DaprClient Client;
    /// <summary>
    /// 配置
    /// </summary>
    protected DaprOptions Options;
    /// <summary>
    /// 日志操作
    /// </summary>
    protected readonly ILogger Logger;
    /// <summary>
    /// 状态存储键生成器
    /// </summary>
    protected IKeyGenerator KeyGenerator;
    /// <summary>
    /// 元数据
    /// </summary>
    protected Dictionary<string, string> Metadatas;
    /// <summary>
    /// 一致性模式
    /// </summary>
    protected ConsistencyMode ConsistencyMode;
    /// <summary>
    /// 事务参数列表
    /// </summary>
    protected List<StateTransactionRequest> StateTransactionRequests;
    /// <summary>
    /// Json序列化配置
    /// </summary>
    protected JsonSerializerOptions SerializerOptions;
    /// <summary>
    /// 是否开启事务
    /// </summary>
    protected bool IsTransaction;
    /// <summary>
    /// 状态组件名称
    /// </summary>
    private string _storeName;

    /// <summary>
    /// 初始化Dapr状态管理
    /// </summary>
    /// <param name="client">Dapr客户端</param>
    /// <param name="options">Dapr配置</param>
    /// <param name="loggerFactory">日志工厂</param>
    /// <param name="keyGenerator">状态存储键生成器</param>
    public DaprStateManage( DaprClient client, IOptions<DaprOptions> options, ILoggerFactory loggerFactory, IKeyGenerator keyGenerator ) {
        Client = client ?? throw new ArgumentNullException( nameof( client ) );
        Options = options?.Value ?? new DaprOptions();
        Logger = loggerFactory?.CreateLogger( typeof( DaprStateManage ) ) ?? NullLogger<DaprStateManage>.Instance;
        KeyGenerator = keyGenerator ?? throw new ArgumentNullException( nameof( keyGenerator ) );
        Metadatas = new Dictionary<string, string>();
        ConsistencyMode = ConsistencyMode.Eventual;
        StateTransactionRequests = new List<StateTransactionRequest>();
    }

    /// <inheritdoc />
    public IStateManage StoreName( string storeName ) {
        _storeName = storeName;
        return this;
    }

    /// <inheritdoc />
    public IStateManage Clear() {
        Metadatas.Clear();
        ConsistencyMode = ConsistencyMode.Eventual;
        StateTransactionRequests.Clear();
        IsTransaction = false;
        return this;
    }

    /// <inheritdoc />
    public IStateManage BeginTransaction() {
        IsTransaction = true;
        return this;
    }

    /// <inheritdoc />
    public async Task CommitAsync( CancellationToken cancellationToken = default ) {
        await Client.ExecuteStateTransactionAsync( GetStoreName(), StateTransactionRequests, Metadatas,cancellationToken );
        StateTransactionRequests.Clear();
        IsTransaction = false;
    }

    /// <inheritdoc />
    public IStateManage JsonSerializerOptions( JsonSerializerOptions options ) {
        SerializerOptions = options;
        return this;
    }

    /// <inheritdoc />
    public async Task<TValue> GetStateAsync<TValue>( string key, CancellationToken cancellationToken = default ) {
        return await Client.GetStateAsync<TValue>( GetStoreName(), key, ConsistencyMode, Metadatas, cancellationToken );
    }

    /// <summary>
    /// 获取状态组件名称
    /// </summary>
    protected string GetStoreName() {
        return _storeName.IsEmpty() ? "statestore" : _storeName;
    }

    /// <inheritdoc />
    public async Task<(TValue value, string etag)> GetStateAndETagAsync<TValue>( string key, CancellationToken cancellationToken = default ) {
        return await Client.GetStateAndETagAsync<TValue>( GetStoreName(), key, ConsistencyMode, Metadatas, cancellationToken );
    }

    /// <inheritdoc />
    public virtual async Task AddAsync<TValue>( string key, TValue value, CancellationToken cancellationToken = default ) {
        if ( IsTransaction == false ) {
            await Client.SaveStateAsync( GetStoreName(), key, value, CreateStateOptions(), Metadatas, cancellationToken );
            return;
        }
        var request = new StateTransactionRequest( key, ToBytes( value ), StateOperationType.Upsert, null, Metadatas, CreateStateOptions() );
        StateTransactionRequests.Add( request );
    }

    /// <summary>
    /// 创建状态配置
    /// </summary>
    protected StateOptions CreateStateOptions() {
        return new StateOptions {
            Consistency = ConsistencyMode,
            Concurrency = ConcurrencyMode.FirstWrite
        };
    }

    /// <summary>
    /// 转换为字节数组
    /// </summary>
    protected virtual byte[] ToBytes<TValue>( TValue value ) {
        return Util.Helpers.Json.ToBytes( value, SerializerOptions );
    }

    /// <inheritdoc />
    public async Task<bool> UpdateAsync<TValue>( string key, TValue value, string etag, CancellationToken cancellationToken = default ) {
        if ( IsTransaction == false )
            return await Client.TrySaveStateAsync( GetStoreName(), key, value, etag, CreateStateOptions(), Metadatas, cancellationToken );
        var request = new StateTransactionRequest( key, ToBytes( value ), StateOperationType.Upsert, etag, Metadatas, CreateStateOptions() );
        StateTransactionRequests.Add( request );
        return true;
    }

    /// <inheritdoc />
    public async Task RemoveAsync( string key, CancellationToken cancellationToken = default ) {
        if ( IsTransaction == false ) {
            await Client.DeleteStateAsync( GetStoreName(), key, CreateStateOptions(), Metadatas, cancellationToken );
            return;
        }
        var request = new StateTransactionRequest( key, null, StateOperationType.Delete, null, Metadatas, CreateStateOptions() );
        StateTransactionRequests.Add( request );
    }

    /// <inheritdoc />
    public async Task<TValue> GetAsync<TValue>( string key, CancellationToken cancellationToken = default ) where TValue : IDataKey, IETag {
        var result = await GetStateAndETagAsync<TValue>( key, cancellationToken );
        if ( result.value == null )
            return default;
        result.value.ETag = result.etag;
        return result.value;
    }

    /// <inheritdoc />
    public async Task<IList<TValue>> GetAsync<TValue>( IReadOnlyList<string> keys, int? parallelism = 0, CancellationToken cancellationToken = default ) where TValue : IDataKey, IETag {
        var result = new List<TValue>();
        var items = await Client.GetBulkStateAsync( GetStoreName(), keys, parallelism, Metadatas, cancellationToken );
        if ( items == null || items.Count == 0 )
            return result;
        foreach ( var item in items ) {
            var state = Util.Helpers.Json.ToObject<TValue>( item.Value,SerializerOptions );
            state.ETag = item.ETag;
            result.Add( state );
        }
        return result;
    }

    /// <inheritdoc />
    public async Task<string> SaveAsync<TValue>( TValue value, string key = null, CancellationToken cancellationToken = default ) where TValue : IDataKey, IETag {
        value.CheckNull( nameof( value ) );
        if ( value.Id.IsEmpty() )
            value.Id = Guid.NewGuid().ToString();
        key = GetKey( value, key );
        if ( IsTransaction == false ) {
            var result = await UpdateAsync( key, value, value.ETag ?? string.Empty, cancellationToken );
            if ( result == false )
                throw new ConcurrencyException( $"保存状态失败,key:{key}" );
            return key;
        }
        var request = new StateTransactionRequest( key, ToBytes( value ), StateOperationType.Upsert, value.ETag ?? string.Empty, Metadatas, CreateStateOptions() );
        StateTransactionRequests.Add( request );
        return key;
    }

    /// <summary>
    /// 获取存储键
    /// </summary>
    protected virtual string GetKey<TValue>( TValue value, string key ) where TValue : IDataKey, IETag {
        if ( key.IsEmpty() == false )
            return key;
        return KeyGenerator.CreateKey( value );
    }
}