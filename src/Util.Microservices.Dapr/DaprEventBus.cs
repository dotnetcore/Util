using Util.Data;
using Util.Events;

namespace Util.Microservices.Dapr;

/// <summary>
/// 基于Dapr的集成事件总线
/// </summary>
public class DaprEventBus : IIntegrationEventBus {
    /// <summary>
    /// Dapr客户端
    /// </summary>
    private readonly DaprClient _client;
    /// <summary>
    /// 日志操作
    /// </summary>
    private readonly ILogger _logger;
    /// <summary>
    /// 工作单元操作管理器
    /// </summary>
    private readonly IUnitOfWorkActionManager _actionManager;

    /// <summary>
    /// 发布订阅配置名称,默认值: pubsub
    /// </summary>
    public static string PubsubName { get; set; } = "pubsub";

    /// <summary>
    /// 初始化Dapr集成事件总线
    /// </summary>
    /// <param name="client">Dapr客户端</param>
    /// <param name="logger">日志操作</param>
    /// <param name="actionManager">工作单元操作管理器</param>
    public DaprEventBus( DaprClient client, ILogger<DaprEventBus> logger, IUnitOfWorkActionManager actionManager ) {
        _client = client ?? throw new ArgumentNullException( nameof( client ) );
        _logger = logger ?? throw new ArgumentNullException( nameof( logger ) );
        _actionManager = actionManager ?? throw new ArgumentNullException( nameof( actionManager ) );
    }

    /// <summary>
    /// 发布事件
    /// </summary>
    /// <typeparam name="TEvent">事件类型</typeparam>
    /// <param name="event">事件</param>
    /// <param name="sendNow">是否立即发送事件,默认为true,如果希望发送操作延迟到工作单元提交成功后,则设置为false</param>
    /// <param name="topic">主题名称,默认使用类型名称作为主题</param>
    /// <param name="pubsubName">发布订阅配置名称,默认值: pubsub</param>
    /// <param name="cancellationToken">取消令牌</param>
    public async Task PublishAsync<TEvent>( TEvent @event, bool sendNow = true, string topic = "", string pubsubName = "", CancellationToken cancellationToken = default )
        where TEvent : IIntegrationEvent {
        @event.CheckNull( nameof( @event ) );
        if ( sendNow ) {
            await PublishEventAsync( @event, topic, pubsubName, cancellationToken );
            return;
        }
        _actionManager.Register( async () => {
            await PublishEventAsync( @event, topic, pubsubName, cancellationToken );
        } );
    }

    /// <summary>
    /// 发布事件
    /// </summary>
    private async Task PublishEventAsync<TEvent>( TEvent @event, string topic, string pubsubName, CancellationToken cancellationToken ) {
        pubsubName = pubsubName.IsEmpty() ? PubsubName : pubsubName;
        topic = topic.IsEmpty() ? @event.GetType().Name : topic;
        _logger.LogInformation( "Publishing event {@Event} to {PubsubName}.{Topic}", @event, pubsubName, topic );
        await _client.PublishEventAsync( pubsubName, topic, (object)@event, cancellationToken );
    }
}