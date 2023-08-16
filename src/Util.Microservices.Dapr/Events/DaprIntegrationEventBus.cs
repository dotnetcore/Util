namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 基于Dapr的集成事件总线
/// </summary>
public class DaprIntegrationEventBus : IIntegrationEventBus {
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
    /// 工作单元操作管理器
    /// </summary>
    protected readonly IUnitOfWorkActionManager ActionManager;
    /// <summary>
    /// 发布订阅回调操作
    /// </summary>
    protected IPubsubCallback PubsubCallback;
    /// <summary>
    /// 是否立即发送事件
    /// </summary>
    protected bool? IsSend;
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
        ActionManager = serviceProvider.GetService<IUnitOfWorkActionManager>();
        ActionManager.CheckNull( nameof( ActionManager ) );
        PubsubCallback = serviceProvider.GetService<IPubsubCallback>() ?? NullPubsubCallback.Instance;
        Headers = new Dictionary<string, string>();
        ImportHeaderKeys = new List<string>();
        RemoveHeaderKeys = new List<string>();
        Metadatas = new Dictionary<string, string>();
    }

    /// <inheritdoc />
    public IIntegrationEventBus SendNow( bool isSend ) {
        IsSend = isSend;
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus PubsubName( string pubsubName ) {
        Pubsub = pubsubName;
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus Topic( string topic ) {
        TopicName = topic;
        return this;
    }

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

    /// <inheritdoc />
    public IIntegrationEventBus Metadata( string key, string value ) {
        if ( key.IsEmpty() )
            return this;
        if ( value.IsEmpty() )
            return this;
        if ( Metadatas.ContainsKey( key ) )
            Metadatas.Remove( key );
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

    /// <inheritdoc />
    public IIntegrationEventBus Type( string value ) {
        CloudEventType = value;
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus OnBefore( Func<IIntegrationEvent, Dictionary<string, string>, Dictionary<string, string>, bool> action ) {
        OnBeforeAction = action;
        return this;
    }

    /// <inheritdoc />
    public IIntegrationEventBus OnAfter( Func<IIntegrationEvent, Dictionary<string, string>, Dictionary<string, string>, Task> action ) {
        OnAfterAction = action;
        return this;
    }

    /// <inheritdoc />
    public virtual async Task PublishAsync<TEvent>( TEvent @event, CancellationToken cancellationToken = default ) where TEvent : IIntegrationEvent {
        @event.CheckNull( nameof( @event ) );
        cancellationToken.ThrowIfCancellationRequested();
        ImportHeaders();
        var cloudEvent = CreateCloudEvent( @event );
        if ( OnBeforeAction != null && OnBeforeAction( cloudEvent.Data, cloudEvent.Headers, Metadatas ) == false )
            return;
        if ( cloudEvent.Data.SendNow ) {
            await PublishEventAsync( cloudEvent, cancellationToken );
            return;
        }
        ActionManager.Register( async () => {
            await PublishEventAsync( cloudEvent, cancellationToken );
        } );
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
        var headers = Util.Helpers.Web.Request?.Headers;
        if ( headers == null )
            return result;
        foreach ( var key in ImportHeaderKeys.Distinct() ) {
            if ( headers.TryGetValue( key, out var value ) )
                result.Add( key, value );
        }
        return result;
    }

    /// <summary>
    /// 创建云事件
    /// </summary>
    protected CloudEvent<IIntegrationEvent> CreateCloudEvent( IIntegrationEvent @event ) {
        var integrationEvent = GetIntegrationEvent( @event );
        return new CloudEvent<IIntegrationEvent>( integrationEvent.EventId, integrationEvent ) {
            Type = CloudEventType,
            Headers = Headers
        };
    }

    /// <summary>
    /// 获取事件
    /// </summary>
    protected virtual IIntegrationEvent GetIntegrationEvent( IIntegrationEvent integrationEvent ) {
        if ( integrationEvent.SendNow == IsSend && integrationEvent.PubsubName == Pubsub && integrationEvent.Topic == TopicName )
            return integrationEvent;
        if ( integrationEvent is not IntegrationEvent @event )
            return integrationEvent;
        return @event with { SendNow = GetSendNow( integrationEvent ), PubsubName = GetPubsubName( integrationEvent ),Topic = GetTopic(integrationEvent) };
    }

    /// <summary>
    /// 获取是否立即发送
    /// </summary>
    protected bool GetSendNow( IIntegrationEvent integrationEvent ) {
        return IsSend == null ? integrationEvent.SendNow : IsSend.SafeValue();
    }

    /// <summary>
    /// 获取发布订阅配置名称
    /// </summary>
    protected string GetPubsubName( IIntegrationEvent integrationEvent ) {
        return Pubsub.IsEmpty()? integrationEvent.PubsubName : Pubsub;
    }

    /// <summary>
    /// 获取事件主题
    /// </summary>
    protected string GetTopic( IIntegrationEvent integrationEvent ) {
        return TopicName.IsEmpty() ? integrationEvent.Topic : TopicName;
    }

    /// <summary>
    /// 发布事件
    /// </summary>
    protected virtual async Task PublishEventAsync( CloudEvent<IIntegrationEvent> cloudEvent, CancellationToken cancellationToken ) {
        Logger.LogTrace( "Publishing event {@Event} to {PubsubName}.{Topic}", cloudEvent.Data, cloudEvent.Data.PubsubName, cloudEvent.Data.Topic );
        var argument = new PubsubArgument( cloudEvent, Metadatas );
        await PubsubCallback.OnPublishBefore( argument );
        await Client.PublishEventAsync( cloudEvent.Data.PubsubName, cloudEvent.Data.Topic, cloudEvent, Metadatas, cancellationToken );
        await PubsubCallback.OnPublishAfter( argument );
        if ( OnAfterAction != null )
            await OnAfterAction( cloudEvent.Data, Headers, Metadatas );
    }
}