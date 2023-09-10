using Util.Helpers;

namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 集成事件管理器
/// </summary>
public class IntegrationEventManager : IIntegrationEventManager {

    #region 字段

    /// <summary>
    /// 集成事件日志记录存储器
    /// </summary>
    protected IIntegrationEventLogStore Store;
    /// <summary>
    /// 用户会话
    /// </summary>
    protected Util.Sessions.ISession Session;
    /// <summary>
    /// 获取应用标识服务
    /// </summary>
    protected IGetAppId GetAppIdService;
    /// <summary>
    /// 配置
    /// </summary>
    protected DaprOptions Options;
    /// <summary>
    /// 日志
    /// </summary>
    protected ILogger<IntegrationEventManager> Log;

    #endregion

    #region 构造方法

    /// <summary>
    /// 初始化集成事件日志记录存储器
    /// </summary>
    /// <param name="store">集成事件日志记录存储器</param>
    /// <param name="session">用户会话</param>
    /// <param name="getAppIdService">获取应用标识服务</param>
    /// <param name="options">Dapr配置</param>
    /// <param name="logger">日志</param>
    public IntegrationEventManager( IIntegrationEventLogStore store, Util.Sessions.ISession session, IGetAppId getAppIdService, 
        IOptions<DaprOptions> options, ILogger<IntegrationEventManager> logger ) {
        Store = store ?? throw new ArgumentNullException( nameof( store ) );
        Session = session ?? Util.Sessions.NullSession.Instance;
        GetAppIdService = getAppIdService ?? throw new ArgumentNullException( nameof( getAppIdService ) );
        Options = options?.Value ?? new DaprOptions();
        Log = logger ?? NullLogger<IntegrationEventManager>.Instance;
    }

    #endregion

    #region IncrementAsync

    /// <inheritdoc />
    public virtual async Task IncrementAsync( CancellationToken cancellationToken = default ) {
        try {
            await Store.IncrementAsync( cancellationToken );
        }
        catch ( ConcurrencyException ) {
            Log.LogDebug( "更新集成事件计数出现并发异常,即将重试" );
            await IncrementAsync( cancellationToken );
        }
        catch ( Exception exception ) {
            Log.LogError( exception, "更新集成事件计数失败" );
        }
    }

    #endregion

    #region GetCountAsync

    /// <inheritdoc />
    public virtual async Task<int> GetCountAsync( CancellationToken cancellationToken = default ) {
        return await Store.GetCountAsync( cancellationToken );
    }

    #endregion

    #region ClearCountAsync

    /// <inheritdoc />
    public virtual async Task ClearCountAsync( CancellationToken cancellationToken = default ) {
        await Store.ClearCountAsync( cancellationToken );
    }

    #endregion

    #region GetAsync

    /// <inheritdoc />
    public virtual async Task<IntegrationEventLog> GetAsync( string eventId, CancellationToken cancellationToken = default ) {
        if ( Options.Pubsub.EnableEventLog == false )
            return NullIntegrationEventLog.Instance;
        return await Store.GetAsync( eventId, cancellationToken );
    }

    #endregion

    #region SaveAsync

    /// <summary>
    /// 保存集成事件日志记录
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    /// <param name="cancellationToken">取消令牌</param>
    public virtual async Task SaveAsync( IntegrationEventLog eventLog, CancellationToken cancellationToken = default ) {
        eventLog.CheckNull( nameof( eventLog ) );
        await Store.SaveAsync( eventLog, cancellationToken );
    }

    #endregion

    #region CanSubscriptionAsync

    /// <inheritdoc />
    public async Task<bool> CanSubscriptionAsync( string eventId, CancellationToken cancellationToken = default ) {
        if ( Options.Pubsub.EnableEventLog == false )
            return true;
        var eventLog = await GetAsync( eventId, cancellationToken );
        return CanSubscription( eventLog );
    }

    #endregion

    #region CanSubscription

    /// <inheritdoc />
    public virtual bool CanSubscription( IntegrationEventLog eventLog ) {
        if ( Options.Pubsub.EnableEventLog == false )
            return true;
        if ( eventLog == null )
            return false;
        var subscriptionLog = GetSubscriptionLog( eventLog );
        if ( subscriptionLog == null )
            return true;
        return subscriptionLog.State == SubscriptionState.Fail && subscriptionLog.RetryCount.SafeValue() < Options.Pubsub.MaxRetry;
    }

    /// <summary>
    /// 获取当前应用的订阅日志
    /// </summary>
    protected SubscriptionLog GetSubscriptionLog( IntegrationEventLog eventLog ) {
        var appId = GetAppId( eventLog.Id );
        return GetSubscriptionLog( eventLog,appId );
    }

    /// <summary>
    /// 获取应用标识
    /// </summary>
    protected string GetAppId( string eventId ) {
        var appId = GetAppIdService.GetAppId();
        if ( appId.IsEmpty() )
            throw new Warning( $"应用标识不能为空,eventId:{eventId}" );
        return appId;
    }

    /// <summary>
    /// 获取当前应用的订阅日志
    /// </summary>
    protected SubscriptionLog GetSubscriptionLog( IntegrationEventLog eventLog,string appId ) {
        return eventLog.SubscriptionLogs.Find( t => t.AppId == appId );
    }

    #endregion

    #region IsSubscriptionSuccess

    /// <inheritdoc />
    public virtual bool IsSubscriptionSuccess( IntegrationEventLog eventLog ) {
        if ( Options.Pubsub.EnableEventLog == false )
            return true;
        var subscriptionLog = GetSubscriptionLog( eventLog );
        return subscriptionLog is { State: SubscriptionState.Success };
    }

    #endregion

    #region CreatePublishLogAsync

    /// <inheritdoc />
    public virtual async Task<IntegrationEventLog> CreatePublishLogAsync( PubsubArgument argument, CancellationToken cancellationToken = default ) {
        if ( Options.Pubsub.EnableEventLog == false )
            return NullIntegrationEventLog.Instance;
        var result = CreateEventLog( argument );
        if ( result == null )
            return NullIntegrationEventLog.Instance;
        await SaveAsync( result, cancellationToken );
        Log.LogDebug( "创建集成事件发布日志记录成功,EventLog={@EventLog}", result );
        return result;
    }

    /// <summary>
    /// 创建集成事件日志
    /// </summary>
    protected virtual IntegrationEventLog CreateEventLog( PubsubArgument argument ) {
        if ( argument.EventData is not CloudEvent<object> cloudEvent )
            return null;
        if ( cloudEvent.Data is not IIntegrationEvent integrationEvent )
            return null;
        var appId = GetAppId( integrationEvent.EventId );
        if ( appId.IsEmpty() )
            throw new Warning( $"应用标识不能为空,eventId:{cloudEvent.Id}" );
        var result = new IntegrationEventLog {
            Id = integrationEvent.EventId,
            AppId = appId,
            UserId = Session.UserId,
            PubsubName = argument.Pubsub,
            Topic = argument.Topic,
            Value = argument,
            State = EventState.Published,
            PublishTime = integrationEvent.EventTime,
            LastModificationTime = Time.Now
        };
        return result;
    }

    #endregion

    #region CreateSubscriptionLogAsync

    /// <inheritdoc />
    public virtual async Task<IntegrationEventLog> CreateSubscriptionLogAsync( string eventId, string routeUrl, CancellationToken cancellationToken = default ) {
        if ( Options.Pubsub.EnableEventLog == false )
            return NullIntegrationEventLog.Instance;
        if ( eventId.IsEmpty() ) {
            Log.LogWarning( "创建集成事件订阅日志记录失败,事件标识不能为空,routeUrl={@routeUrl}", routeUrl );
            return NullIntegrationEventLog.Instance;
        }
        var eventLog = await GetAsync( eventId, cancellationToken );
        return await CreateSubscriptionLogAsync( eventLog, routeUrl, cancellationToken );
    }

    /// <inheritdoc />
    public virtual async Task<IntegrationEventLog> CreateSubscriptionLogAsync( IntegrationEventLog eventLog, string routeUrl, CancellationToken cancellationToken = default ) {
        if ( Options.Pubsub.EnableEventLog == false )
            return NullIntegrationEventLog.Instance;
        eventLog.CheckNull( nameof( eventLog ) );
        if ( CanSubscription( eventLog ) == false )
            return eventLog;
        AddSubscriptionLog( eventLog, routeUrl );
        eventLog.State = EventState.Processing;
        eventLog.LastModificationTime = Time.Now;
        try {
            await SaveAsync( eventLog, cancellationToken );
            Log.LogDebug( "创建集成事件订阅日志记录成功,EventLog={@EventLog}", ToDebugEventLog( eventLog ) );
        }
        catch ( ConcurrencyException ) {
            Log.LogDebug( "创建集成事件订阅日志记录出现并发异常,即将重试,eventId={eventId},routeUrl={routeUrl}", eventLog.Id, routeUrl );
            return await CreateSubscriptionLogAsync( eventLog.Id, routeUrl, cancellationToken );
        }
        catch ( Exception exception ) {
            Log.LogError( exception, "创建集成事件订阅日志记录失败,EventLog={@EventLog}", ToDebugEventLog( eventLog ) );
        }
        return eventLog;
    }

    /// <summary>
    /// 转换为调试状态
    /// </summary>
    protected IntegrationEventLog<PubsubArgument<CloudEvent<object>>> ToDebugEventLog( IntegrationEventLog eventLog ) {
        var json = Util.Helpers.Json.ToJson( eventLog.Value );
        var result = new IntegrationEventLog<PubsubArgument<CloudEvent<object>>> {
            Id = eventLog.Id,
            UserId = eventLog.UserId,
            AppId = eventLog.AppId,
            LastModificationTime = eventLog.LastModificationTime,
            DataType = eventLog.DataType,
            ETag = eventLog.ETag,
            PublishTime = eventLog.PublishTime,
            State = eventLog.State,
            PubsubName = eventLog.PubsubName,
            Topic = eventLog.Topic,
            SubscriptionLogs = eventLog.SubscriptionLogs,
            Value = Util.Helpers.Json.ToObject<PubsubArgument<CloudEvent<object>>>( json )
        };
        if( result.Value is { EventData: not null } )
            result.Value.EventData.Data = Util.Helpers.Json.ToJson( result.Value.EventData.Data );
        return result;
    }

    /// <summary>
    /// 添加订阅日志
    /// </summary>
    protected virtual void AddSubscriptionLog( IntegrationEventLog eventLog, string routeUrl ) {
        var appId = GetAppId( eventLog.Id );
        var subscriptionLog = eventLog.SubscriptionLogs.Find( t => t.AppId == appId );
        if ( subscriptionLog == null ) {
            subscriptionLog = CreateSubscriptionLog( appId, routeUrl );
            eventLog.SubscriptionLogs.Add( subscriptionLog );
            return;
        }
        subscriptionLog.State = SubscriptionState.Processing;
        subscriptionLog.LastModificationTime = Time.Now;
        subscriptionLog.RetryCount = subscriptionLog.RetryCount.SafeValue() + 1;
        UpdateRetryTime( subscriptionLog );
    }

    /// <summary>
    /// 创建订阅日志
    /// </summary>
    protected virtual SubscriptionLog CreateSubscriptionLog( string appId, string routeUrl ) {
        return new SubscriptionLog {
            AppId = appId,
            RouteUrl = routeUrl,
            State = SubscriptionState.Processing,
            SubscriptionTime = Time.Now,
            LastModificationTime = Time.Now,
        };
    }

    /// <summary>
    /// 更新重试时间
    /// </summary>
    protected virtual void UpdateRetryTime( SubscriptionLog subscriptionLog ) {
        if ( subscriptionLog.RetryLogs.Count == 0 )
            return;
        var retryLog = subscriptionLog.RetryLogs.MaxBy( t => t.Number );
        retryLog.RetryTime = Time.Now;
    }

    #endregion

    #region SubscriptionSuccessAsync

    /// <inheritdoc />
    public virtual async Task<IntegrationEventLog> SubscriptionSuccessAsync( string eventId, CancellationToken cancellationToken = default ) {
        if ( Options.Pubsub.EnableEventLog == false )
            return NullIntegrationEventLog.Instance;
        if ( eventId.IsEmpty() ) {
            Log.LogWarning( "SubscriptionSuccessAsync更新集成事件订阅日志记录失败,事件标识不能为空." );
            return NullIntegrationEventLog.Instance;
        }
        var eventLog = await GetAsync( eventId, cancellationToken );
        return await SubscriptionSuccessAsync( eventLog, cancellationToken );
    }

    /// <summary>
    /// 集成事件订阅处理成功
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    /// <param name="cancellationToken">取消令牌</param>
    public virtual async Task<IntegrationEventLog> SubscriptionSuccessAsync( IntegrationEventLog eventLog, CancellationToken cancellationToken = default ) {
        if ( Options.Pubsub.EnableEventLog == false )
            return NullIntegrationEventLog.Instance;
        eventLog.CheckNull( nameof( eventLog ) );
        var appId = GetAppId( eventLog.Id );
        var subscriptionLog = GetSubscriptionLog( eventLog, appId );
        if ( subscriptionLog == null ) {
            Log.LogWarning( "更新集成事件订阅日志记录失败,未找到订阅日志记录,appId={appId},EventLog={@EventLog}", appId,ToDebugEventLog( eventLog ) );
            return NullIntegrationEventLog.Instance;
        }
        subscriptionLog.State = SubscriptionState.Success;
        subscriptionLog.LastModificationTime = Time.Now;
        eventLog.LastModificationTime = Time.Now;
        UpdateEventLogState( eventLog );
        try {
            await SaveAsync( eventLog, cancellationToken );
            Log.LogDebug( "集成事件订阅处理成功,appId={appId},EventLog={@EventLog}", appId,ToDebugEventLog( eventLog ) );
        }
        catch ( ConcurrencyException ) {
            Log.LogDebug( "更新集成事件订阅日志记录出现并发异常,即将重试,eventId={eventId},appId={appId}", eventLog.Id, appId );
            return await SubscriptionSuccessAsync( eventLog.Id, cancellationToken );
        }
        catch ( Exception exception ) {
            Log.LogError( exception, "更新集成事件订阅日志记录失败,appId={appId},EventLog={@EventLog}", appId,ToDebugEventLog( eventLog ) );
        }
        return eventLog;
    }

    /// <summary>
    /// 更新集成事件日志状态
    /// </summary>
    protected void UpdateEventLogState( IntegrationEventLog eventLog ) {
        if ( eventLog.SubscriptionLogs.All( t => t.State == SubscriptionState.Success ) ) {
            eventLog.State = EventState.Success;
            return;
        }
        if ( eventLog.SubscriptionLogs.Any( t => t.State == SubscriptionState.Processing ) ) {
            eventLog.State = EventState.Processing;
            return;
        }
        eventLog.State = EventState.Fail;
    }

    #endregion

    #region SubscriptionFailAsync

    /// <summary>
    /// 集成事件订阅处理失败
    /// </summary>
    /// <param name="eventId">事件标识</param>
    /// <param name="message">消息</param>
    /// <param name="cancellationToken">取消令牌</param>
    public virtual async Task<IntegrationEventLog> SubscriptionFailAsync( string eventId, string message, CancellationToken cancellationToken = default ) {
        if ( Options.Pubsub.EnableEventLog == false )
            return NullIntegrationEventLog.Instance;
        if ( eventId.IsEmpty() ) {
            Log.LogWarning( "SubscriptionFailAsync更新集成事件订阅日志记录失败,事件标识不能为空." );
            return NullIntegrationEventLog.Instance;
        }
        var eventLog = await GetAsync( eventId, cancellationToken );
        return await SubscriptionFailAsync( eventLog, message, cancellationToken );
    }

    /// <summary>
    /// 集成事件订阅处理失败
    /// </summary>
    /// <param name="eventLog">集成事件日志记录</param>
    /// <param name="message">消息</param>
    /// <param name="cancellationToken">取消令牌</param>
    public virtual async Task<IntegrationEventLog> SubscriptionFailAsync( IntegrationEventLog eventLog, string message, CancellationToken cancellationToken = default ) {
        if ( Options.Pubsub.EnableEventLog == false )
            return NullIntegrationEventLog.Instance;
        eventLog.CheckNull( nameof( eventLog ) );
        var appId = GetAppId( eventLog.Id );
        var subscriptionLog = GetSubscriptionLog( eventLog, appId );
        if ( subscriptionLog == null ) {
            Log.LogWarning( "更新集成事件订阅日志记录失败,未找到订阅日志记录,appId={appId},EventLog={@EventLog}", appId, ToDebugEventLog( eventLog ) );
            return NullIntegrationEventLog.Instance;
        }
        subscriptionLog.State = SubscriptionState.Fail;
        subscriptionLog.LastModificationTime = Time.Now;
        subscriptionLog.RetryLogs.Add( CreateSubscriptionRetryLog( subscriptionLog, message ) );
        eventLog.LastModificationTime = Time.Now;
        UpdateEventLogState( eventLog );
        try {
            await SaveAsync( eventLog, cancellationToken );
            Log.LogDebug( "集成事件订阅处理失败,appId={appId},EventLog={@EventLog}", appId, ToDebugEventLog( eventLog ) );
        }
        catch ( ConcurrencyException ) {
            Log.LogDebug( "更新集成事件订阅日志记录出现并发异常,即将重试,eventId={eventId},appId={appId}", eventLog.Id, appId );
            return await SubscriptionFailAsync( eventLog.Id, message, cancellationToken );
        }
        catch ( Exception exception ) {
            Log.LogError( exception, "更新集成事件订阅日志记录失败,appId={appId},EventLog={@EventLog}", appId, ToDebugEventLog( eventLog ) );
        }
        return eventLog;
    }

    /// <summary>
    /// 创建订阅重试记录
    /// </summary>
    protected SubscriptionRetryLog CreateSubscriptionRetryLog( SubscriptionLog subscriptionLog, string message ) {
        var retryLog = subscriptionLog.RetryLogs.MaxBy( t => t.Number );
        var maxNumber = retryLog?.Number ?? 0;
        return new SubscriptionRetryLog { Number = maxNumber + 1, Message = message };
    }

    #endregion
}