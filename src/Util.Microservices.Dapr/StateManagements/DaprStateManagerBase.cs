using Util.Helpers;
using Util.Microservices.Dapr.StateManagements.Queries;

namespace Util.Microservices.Dapr.StateManagements;

/// <summary>
/// Dapr状态管理
/// </summary>
public partial class DaprStateManagerBase<TStateManager> : IStateManagerBase<TStateManager> where TStateManager : IStateManagerBase<TStateManager> {

    #region 字段

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
    /// 过滤条件
    /// </summary>
    protected StateFilter Filter;
    /// <summary>
    /// 排序条件
    /// </summary>
    protected StateSort Sort;
    /// <summary>
    /// 分页条件
    /// </summary>
    protected StatePage Page;
    /// <summary>
    /// 状态组件名称
    /// </summary>
    private string _storeName;

    #endregion

    #region 构造方法

    /// <summary>
    /// 初始化Dapr状态管理
    /// </summary>
    /// <param name="client">Dapr客户端</param>
    /// <param name="options">Dapr配置</param>
    /// <param name="loggerFactory">日志工厂</param>
    /// <param name="keyGenerator">状态存储键生成器</param>
    public DaprStateManagerBase( DaprClient client, IOptions<DaprOptions> options, ILoggerFactory loggerFactory, IKeyGenerator keyGenerator ) {
        Client = client ?? throw new ArgumentNullException( nameof( client ) );
        Options = options?.Value ?? new DaprOptions();
        Logger = loggerFactory?.CreateLogger( typeof( DaprStateManager ) ) ?? NullLogger<DaprStateManager>.Instance;
        KeyGenerator = keyGenerator ?? throw new ArgumentNullException( nameof( keyGenerator ) );
        Metadatas = new Dictionary<string, string>();
        ConsistencyMode = ConsistencyMode.Eventual;
        StateTransactionRequests = new List<StateTransactionRequest>();
        Filter = new StateFilter();
        Sort = new StateSort();
        Page = new StatePage();
    }

    #endregion

    #region 辅助操作

    /// <summary>
    /// 返回
    /// </summary>
    private TStateManager Return() {
        return (TStateManager)(object)this;
    }

    /// <summary>
    /// 获取状态组件名称
    /// </summary>
    protected string GetStoreName() {
        return _storeName.IsEmpty() ? "statestore" : _storeName;
    }

    /// <summary>
    /// 获取存储键
    /// </summary>
    protected virtual string GetKey<TValue>( string key, TValue value ) where TValue : IDataKey {
        if ( key.IsEmpty() == false )
            return key;
        return KeyGenerator.CreateKey<TValue>( value.Id );
    }

    /// <summary>
    /// 是否实现IDataType接口
    /// </summary>
    protected bool IsDataType<TValue>() {
        return typeof( TValue ).IsAssignableTo( typeof( IDataType ) );
    }

    /// <summary>
    /// 是否实现IDataKey接口
    /// </summary>
    protected bool IsDataKey<TValue>() {
        return typeof( TValue ).IsAssignableTo( typeof( IDataKey ) );
    }

    /// <summary>
    /// 是否实现IETag接口
    /// </summary>
    protected bool IsETag<TValue>() {
        return typeof( TValue ).IsAssignableTo( typeof( IETag ) );
    }

    /// <summary>
    /// 设置数据类型查询条件
    /// </summary>
    protected void SetDataTypeCondition<TValue>() {
        EqualIf( "dataType", typeof( TValue ).FullName, IsDataType<TValue>() );
    }

    #endregion

    #region StoreName

    /// <inheritdoc />
    public TStateManager StoreName( string storeName ) {
        _storeName = storeName;
        return Return();
    }

    #endregion

    #region Clear

    /// <inheritdoc />
    public TStateManager Clear() {
        Metadatas.Clear();
        ConsistencyMode = ConsistencyMode.Eventual;
        StateTransactionRequests.Clear();
        IsTransaction = false;
        ClearQuery();
        return Return();
    }

    /// <summary>
    /// 清理查询条件
    /// </summary>
    protected void ClearQuery() {
        Filter.Clear();
        Sort.Clear();
        Page = new StatePage();
    }

    #endregion

    #region BeginTransaction

    /// <inheritdoc />
    public TStateManager BeginTransaction() {
        IsTransaction = true;
        return Return();
    }

    #endregion

    #region JsonSerializerOptions

    /// <inheritdoc />
    public TStateManager JsonSerializerOptions( JsonSerializerOptions options ) {
        SerializerOptions = options;
        return Return();
    }

    #endregion

    #region Metadata

    /// <summary>
    /// 设置元数据
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    public TStateManager Metadata( string key, string value ) {
        if ( key.IsEmpty() )
            return Return();
        if ( value.IsEmpty() )
            return Return();
        RemoveMetadata( key );
        Metadatas.Add( key, value );
        return Return();
    }

    /// <summary>
    /// 设置元数据
    /// </summary>
    /// <param name="metadata">元数据键值对集合</param>
    public TStateManager Metadata( IDictionary<string, string> metadata ) {
        if ( metadata == null )
            return Return();
        foreach ( var item in metadata )
            Metadata( item.Key, item.Value );
        return Return();
    }

    #endregion

    #region RemoveMetadata

    /// <summary>
    /// 移除元数据
    /// </summary>
    /// <param name="key">键</param>
    public TStateManager RemoveMetadata( string key ) {
        if ( key.IsEmpty() )
            return Return();
        if ( Metadatas.ContainsKey( key ) )
            Metadatas.Remove( key );
        return Return();
    }

    #endregion

    #region ContentType

    /// <inheritdoc />
    public TStateManager ContentType( string type ) {
        Metadata( "contentType", type );
        return Return();
    }

    #endregion

    #region JsonType

    /// <summary>
    /// 设置contentType为application/json
    /// </summary>
    public TStateManager JsonType() {
        return ContentType( "application/json" );
    }

    #endregion

    #region AddAsync

    /// <inheritdoc />
    public virtual async Task AddAsync<TValue>( string key, TValue value, CancellationToken cancellationToken = default ) {
        if ( key.IsEmpty() )
            throw new ArgumentNullException( nameof( key ) );
        InitAdd( value );
        if ( IsTransaction == false ) {
            await Client.SaveStateAsync( GetStoreName(), key, value, CreateStateOptions(), Metadatas, cancellationToken );
            Clear();
            return;
        }
        var request = new StateTransactionRequest( key, ToBytes( value ), StateOperationType.Upsert, null, Metadatas, CreateStateOptions() );
        StateTransactionRequests.Add( request );
    }

    /// <summary>
    /// 初始化新增
    /// </summary>
    protected virtual void InitAdd<TValue>( TValue value ) {
        InitId( value );
        InitDataType( value );
        InitJsonType<TValue>();
    }

    /// <summary>
    /// 初始化标识
    /// </summary>
    protected virtual void InitId<TValue>( TValue value ) {
        if ( value is not IDataKey data )
            return;
        if ( data.Id.IsEmpty() )
            data.Id = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// 初始化数据类型
    /// </summary>
    protected virtual void InitDataType<TValue>( TValue value ) {
        if ( value is IDataType dataType )
            dataType.DataType = typeof( TValue ).FullName;
    }

    /// <summary>
    /// 初始化Json内容类型
    /// </summary>
    protected virtual void InitJsonType<TValue>() {
        var type = typeof( TValue );
        if ( type == typeof( string ) )
            return;
        JsonType();
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
        return Json.ToBytes( value, SerializerOptions );
    }

    #endregion

    #region UpdateAsync

    /// <inheritdoc />
    public async Task<bool> UpdateAsync<TValue>( string key, TValue value, string etag, CancellationToken cancellationToken = default ) {
        if ( key.IsEmpty() )
            throw new ArgumentNullException( nameof( key ) );
        InitJsonType<TValue>();
        if ( IsTransaction == false ) {
            try {
                var result = await Client.TrySaveStateAsync( GetStoreName(), key, value, etag, CreateStateOptions(), Metadatas, cancellationToken );
                Clear();
                return result;
            }
            catch ( DaprException ex ) {
                Clear();
                var exception = ex.InnerException;
                if ( exception != null && exception.Message.Contains( "E11000" ) )
                    return false;
                throw;
            }
        }
        var request = new StateTransactionRequest( key, ToBytes( value ), StateOperationType.Upsert, etag, Metadatas, CreateStateOptions() );
        StateTransactionRequests.Add( request );
        return true;
    }

    #endregion

    #region RemoveAsync

    /// <inheritdoc />
    public async Task RemoveAsync( string key, CancellationToken cancellationToken = default ) {
        if ( key.IsEmpty() )
            throw new ArgumentNullException( nameof( key ) );
        if ( IsTransaction == false ) {
            await Client.DeleteStateAsync( GetStoreName(), key, CreateStateOptions(), Metadatas, cancellationToken );
            Clear();
            return;
        }
        var request = new StateTransactionRequest( key, null, StateOperationType.Delete, null, Metadatas, CreateStateOptions() );
        StateTransactionRequests.Add( request );
    }

    #endregion

    #region RemoveByIdAsync

    /// <summary>
    /// 通过标识删除数据
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="id">标识</param>
    /// <param name="cancellationToken">取消令牌</param>
    public async Task RemoveByIdAsync<TValue>( string id, CancellationToken cancellationToken = default ) where TValue : IDataKey {
        var key = await GetKeyByIdAsync<TValue>( id, cancellationToken );
        await RemoveAsync( key, cancellationToken );
    }

    #endregion

    #region SaveAsync

    /// <inheritdoc />
    public async Task<string> SaveAsync<TValue>( TValue value, CancellationToken cancellationToken = default, string key = null ) where TValue : IDataKey, IETag {
        value.CheckNull( nameof( value ) );
        InitSave( value );
        key = GetKey( key, value );
        if ( IsTransaction == false ) {
            var result = await UpdateAsync( key, value, value.ETag ?? string.Empty, cancellationToken );
            if ( result == false )
                throw new ConcurrencyException( $"保存状态失败,key:{key}" );
            Clear();
            return key;
        }
        var bytes = ToBytes( value );
        var request = new StateTransactionRequest( key, bytes, StateOperationType.Upsert, value.ETag ?? string.Empty, Metadatas, CreateStateOptions() );
        StateTransactionRequests.Add( request );
        return key;
    }

    /// <summary>
    /// 初始化保存数据
    /// </summary>
    protected virtual void InitSave<TValue>( TValue value ) where TValue : IDataKey, IETag {
        InitId( value );
        InitDataType( value );
    }

    /// <inheritdoc />
    public async Task SaveAsync<TValue>( IEnumerable<TValue> values, CancellationToken cancellationToken = default ) where TValue : IDataKey, IETag {
        values.CheckNull( nameof( values ) );
        InitJsonType<TValue>();
        var items = ToSaveStateItems( values );
        if ( IsTransaction == false ) {
            await Client.SaveBulkStateAsync( GetStoreName(), items, cancellationToken );
            Clear();
            return;
        }
        foreach ( var item in items ) {
            var bytes = ToBytes( item.Value );
            var request = new StateTransactionRequest( item.Key, bytes, StateOperationType.Upsert, item.ETag ?? string.Empty, Metadatas, CreateStateOptions() );
            StateTransactionRequests.Add( request );
        }
    }

    /// <summary>
    /// 转换为SaveStateItems
    /// </summary>
    protected List<SaveStateItem<TValue>> ToSaveStateItems<TValue>( IEnumerable<TValue> values ) where TValue : IDataKey, IETag {
        var result = new List<SaveStateItem<TValue>>();
        foreach ( var value in values ) {
            InitSave( value );
            var key = GetKey( null, value );
            var item = new SaveStateItem<TValue>( key, value, value.ETag, CreateStateOptions(), Metadatas );
            result.Add( item );
        }
        return result;
    }

    #endregion

    #region CommitAsync

    /// <inheritdoc />
    public async Task CommitAsync( CancellationToken cancellationToken = default ) {
        await Client.ExecuteStateTransactionAsync( GetStoreName(), StateTransactionRequests, Metadatas, cancellationToken );
        Clear();
    }

    #endregion
}