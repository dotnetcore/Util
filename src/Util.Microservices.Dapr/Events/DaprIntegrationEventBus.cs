using Util.Helpers;

namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 基于Dapr的集成事件总线
/// </summary>
public class DaprIntegrationEventBus : IIntegrationEventBus {

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
    /// 发布订阅回调操作
    /// </summary>
    protected IPubsubCallback PubsubCallback;
    /// <summary>
    /// 集成事件管理器
    /// </summary>
    protected IIntegrationEventManager EventManager;
    /// <summary>
    /// 发布订阅配置名称
    /// </summary>
    protected string Pubsub;
    /// <summary>
    /// 事件主题
    /// </summary>
    protected string TopicName;
    /// <summary>
    /// 事件类型
    /// </summary>
    protected string CloudEventType;
    /// <summary>
    /// 请求头集合
    /// </summary>
    protected Dictionary<string, string> Headers;
    /// <summary>
    /// 导入请求头键名集合
    /// </summary>
    protected List<string> ImportHeaderKeys;
    /// <summary>
    /// 移除请求头键名集合
    /// </summary>
    protected IList<string> RemoveHeaderKeys;
    /// <summary>
    /// 元数据
    /// </summary>
    protected Dictionary<string, string> Metadatas;
    /// <summary>
    /// 发布前操作
    /// </summary>
    protected Func<IIntegrationEvent, Dictionary<string, string>, Dictionary<string, string>, bool> OnBeforeAction;
    /// <summary>
    /// 发布后操作
    /// </summary>
    protected Func<IIntegrationEvent, Dictionary<string, string>, Dictionary<string, string>, Task> OnAfterAction;

    #endregion

    #region 构造方法

    /// <summary>
    /// 初始化Dapr集成事件总线
    /// </summary>
    /// <param name="client">Dapr客户端</param>
    /// <param name="options">Dapr配置</param>
    /// <param name="loggerFactory">日志工厂</param>
    /// <param name="serviceProvider">服务提供器</param>
    public DaprIntegrationEventBus( DaprClient client, IOptions<DaprOptions> options, ILoggerFactory loggerFactory, IServiceProvider serviceProvider ) {
        Client = client ?? throw new ArgumentNullException( nameof( client ) );
        Options = options?.Value ?? new DaprOptions();
        Logger = loggerFactory?.CreateLogger( typeof( DaprEventBus ) ) ?? NullLogger<DaprEventBus>.Instance;
        serviceProvider.CheckNull( nameof( serviceProvider ) );
        PubsubCallback = serviceProvider.GetService<IPubsubCallback>() ?? NullPubsubCallback.Instance;
        EventManager = serviceProvider.GetRequiredService<IIntegrationEventManager>();
        Headers = new Dictionary<string, string>();
        ImportHeaderKeys = new List<string>();
        RemoveHeaderKeys = new List<string>();
        Metadatas = new Dictionary<string, string>();
    }

    #endregion

    #region PubsubName

    /// <inheritdoc />
    public IIntegrationEventBus PubsubName( string pubsubName ) {
        Pubsub = pubsubName;
        return this;
    }

    #endregion

    #region Topic

    /// <inheritdoc />
    public IIntegrationEventBus Topic( string topic ) {
        TopicName = topic;
        return this;
    }

    #endregion

    #region Header

    /// <inheritdoc />
    public IIntegrationEventBus Header( string key, string value ) {
        if ( key.IsEmpty() )
            return this;
        if ( Headers.ContainsKey( key ) )
            Headers.Remove( key );
        Headers.Add( key, value );
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus Header( IDictionary<string, string> headers ) {
        if ( headers == null )
            return this;
        foreach ( var header in headers )
            Header( header.Key, header.Value );
        return this;
    }

    #endregion

    #region ImportHeader

    /// <summary>
    /// 从当前HttpContext导入请求头
    /// </summary>
    /// <param name="key">请求头键名</param>
    public IIntegrationEventBus ImportHeader( string key ) {
        if ( key.IsEmpty() )
            return this;
        if ( ImportHeaderKeys.Contains( key ) == false )
            ImportHeaderKeys.Add( key );
        return this;
    }

    /// <summary>
    /// 从当前HttpContext导入请求头
    /// </summary>
    /// <param name="keys">请求头键名集合</param>
    public IIntegrationEventBus ImportHeader( IEnumerable<string> keys ) {
        if ( keys == null )
            return this;
        foreach ( var key in keys )
            ImportHeader( key );
        return this;
    }

    #endregion

    #region RemoveHeader

    /// <summary>
    /// 移除请求头
    /// </summary>
    /// <param name="key">请求头键名</param>
    public IIntegrationEventBus RemoveHeader( string key ) {
        if ( key.IsEmpty() )
            return this;
        if ( RemoveHeaderKeys.Contains( key ) == false )
            RemoveHeaderKeys.Add( key );
        return this;
    }

    #endregion

    #region Metadata

    /// <inheritdoc />
    public IIntegrationEventBus Metadata( string key, string value ) {
        if ( key.IsEmpty() )
            return this;
        if ( value.IsEmpty() )
            return this;
        RemoveMetadata( key );
        Metadatas.Add( key, value );
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus Metadata( IDictionary<string, string> metadata ) {
        if ( metadata == null )
            return this;
        foreach ( var item in metadata )
            Metadata( item.Key, item.Value );
        return this;
    }

    #endregion

    #region RemoveMetadata

    /// <inheritdoc />
    public IIntegrationEventBus RemoveMetadata( string key ) {
        if ( key.IsEmpty() )
            return this;
        if ( Metadatas.ContainsKey( key ) )
            Metadatas.Remove( key );
        return this;
    }

    #endregion

    #region Type

    /// <inheritdoc />
    public IIntegrationEventBus Type( string value ) {
        CloudEventType = value;
        return this;
    }

    #endregion

    #region OnBefore

    /// <inheritdoc />
    public IIntegrationEventBus OnBefore( Func<IIntegrationEvent, Dictionary<string, string>, Dictionary<string, string>, bool> action ) {
        OnBeforeAction = action;
        return this;
    }

    #endregion

    #region OnAfter

    /// <inheritdoc />
    public IIntegrationEventBus OnAfter( Func<IIntegrationEvent, Dictionary<string, string>, Dictionary<string, string>, Task> action ) {
        OnAfterAction = action;
        return this;
    }

    #endregion

    #region PublishAsync

    /// <inheritdoc />
    public virtual async Task PublishAsync<TEvent>( TEvent @event, CancellationToken cancellationToken = default ) where TEvent : IIntegrationEvent {
        @event.CheckNull( nameof( @event ) );
        cancellationToken.ThrowIfCancellationRequested();
        ImportHeaders();
        Init( @event );
        if ( OnBeforeAction != null && OnBeforeAction( @event, Headers, Metadatas ) == false )
            return;
        await PublishEventAsync( @event, cancellationToken );
    }

    /// <summary>
    /// 导入请求头
    /// </summary>
    protected virtual void ImportHeaders() {
        RemoveHeaders();
        SetHeaders();
    }

    /// <summary>
    /// 移除请求头
    /// </summary>
    private void RemoveHeaders() {
        foreach ( var key in RemoveHeaderKeys ) {
            Headers.Remove( key );
            ImportHeaderKeys.Remove( key );
            Options.Pubsub.ImportHeaderKeys.Remove( key );
        }
    }

    /// <summary>
    /// 设置请求头
    /// </summary>
    private void SetHeaders() {
        var headers = GetImportHeaders();
        foreach ( var item in headers )
            Headers.TryAdd( item.Key, item.Value );
    }

    /// <summary>
    /// 获取导入的请求头
    /// </summary>
    private IDictionary<string, string> GetImportHeaders() {
        var result = new Dictionary<string, string>();
        ImportHeaderKeys.AddRange( Options.Pubsub.ImportHeaderKeys );
        if ( ImportHeaderKeys.Count == 0 )
            return result;
        var headers = Web.Request?.Headers;
        if ( headers == null )
            return result;
        foreach ( var key in ImportHeaderKeys.Distinct() ) {
            if ( headers.TryGetValue( key, out var value ) )
                result.Add( key, value );
        }
        return result;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    protected void Init( IIntegrationEvent integrationEvent ) {
        InitPubsubName( integrationEvent );
        InitTopic( integrationEvent );
    }

    /// <summary>
    /// 初始化发布订阅名称
    /// </summary>
    protected void InitPubsubName( IIntegrationEvent integrationEvent ) {
        if ( Pubsub.IsEmpty() == false )
            return;
        Pubsub = PubsubNameAttribute.GetName( integrationEvent.GetType() );
    }

    /// <summary>
    /// 初始化事件主题
    /// </summary>
    protected void InitTopic( IIntegrationEvent integrationEvent ) {
        if ( TopicName.IsEmpty() == false )
            return;
        TopicName = TopicNameAttribute.GetName( integrationEvent.GetType() );
    }

    /// <summary>
    /// 发布事件
    /// </summary>
    protected virtual async Task PublishEventAsync( IIntegrationEvent @event, CancellationToken cancellationToken ) {
        Logger.LogTrace( "Publishing event {@Event} to {PubsubName}.{Topic}", @event, Pubsub, TopicName );
        var cloudEvent = CreateCloudEvent( @event );
        var argument = CreatePubsubArgument( cloudEvent );
        await PubsubCallback.OnPublishBefore( argument, cancellationToken );
        await Client.PublishEventAsync( Pubsub, TopicName, cloudEvent, Metadatas, cancellationToken );
        await PubsubCallback.OnPublishAfter( argument, cancellationToken );
        if ( OnAfterAction != null )
            await OnAfterAction( @event, Headers, Metadatas );
    }

    /// <summary>
    /// 创建云事件
    /// </summary>
    protected CloudEvent<object> CreateCloudEvent( IIntegrationEvent @event ) {
        var result = new CloudEvent<object>( @event.EventId, @event ) {
            Type = CloudEventType,
            Headers = Headers.Count > 0 ? Headers : null
        };
        return result;
    }

    /// <summary>
    /// 创建发布订阅参数
    /// </summary>
    protected PubsubArgument CreatePubsubArgument( CloudEvent<object> cloudEvent ) {
        return Metadatas.Count > 0 ? new PubsubArgument( Pubsub, TopicName, cloudEvent, Metadatas ) : new PubsubArgument( Pubsub, TopicName, cloudEvent );
    }

    #endregion

    #region RepublishAsync

    /// <inheritdoc />
    public virtual async Task RepublishAsync( string eventId, CancellationToken cancellationToken = default ) {
        if ( Options.Pubsub.EnableEventLog == false )
            return;
        if ( eventId.IsEmpty() ) {
            Logger.LogWarning( "重新发布集成事件失败,事件标识不能为空." );
            return;
        }
        var eventLog = await EventManager.GetAsync( eventId, cancellationToken );
        await RepublishAsync( eventLog, cancellationToken );
    }

    /// <summary>
    /// 重新发布集成事件
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    /// <param name="cancellationToken">取消令牌</param>
    protected virtual async Task RepublishAsync( IntegrationEventLog eventLog, CancellationToken cancellationToken = default ) {
        eventLog.CheckNull( nameof( eventLog ) );
        eventLog.SubscriptionLogs.ForEach( t => {
            if ( t.State == SubscriptionState.Fail )
                t.RetryCount = 0;
        } );
        await EventManager.SaveAsync( eventLog, cancellationToken );
        var json = Util.Helpers.Json.ToJson( eventLog.Value );
        var argument = Util.Helpers.Json.ToObject<PubsubArgument<CloudEvent<object>>>( json );
        var cloudEvent = argument.GetEventData<CloudEvent<object>>();
        Logger.LogTrace( "Republishing event {@Event} to {PubsubName}.{Topic}", cloudEvent.Data, eventLog.PubsubName, eventLog.Topic );
        await PubsubCallback.OnRepublishBefore( eventLog, cancellationToken );
        await Client.PublishEventAsync( eventLog.PubsubName, eventLog.Topic, cloudEvent, argument.Metadata ?? new Dictionary<string, string>(), cancellationToken );
        await PubsubCallback.OnRepublishAfter( eventLog, cancellationToken );
    }

    #endregion
}