using Util.Helpers;
using Util.Microservices.Events;
using Util.Sessions;

namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 集成事件存储器
/// </summary>
public class IntegrationEventStore : IIntegrationEventStore {
    /// <summary>
    /// 初始化发布订阅回调操作
    /// </summary>
    /// <param name="stateManage">状态管理操作</param>
    /// <param name="session">用户会话</param>
    /// <param name="options">配置</param>
    public IntegrationEventStore( IStateManage stateManage, Util.Sessions.ISession session, IOptions<DaprOptions> options ) {
        StateManage = stateManage ?? throw new ArgumentNullException( nameof( stateManage ) );
        StateManage.StoreName( options?.Value.Pubsub?.EventLogStoreName ?? "statestore" );
        Session = session ?? NullSession.Instance;
    }

    /// <summary>
    /// 状态管理操作
    /// </summary>
    protected IStateManage StateManage;
    /// <summary>
    /// 用户会话1
    /// </summary>
    protected Util.Sessions.ISession Session;

    /// <summary>
    /// 重新发布集成事件
    /// </summary>
    /// <param name="eventId">事件标识</param>
    /// <param name="cancellationToken">取消令牌</param>
    public async Task RepublishAsync( string eventId, CancellationToken cancellationToken = default ) {

    }

    /// <summary>
    /// 创建准备发布状态的集成事件日志记录
    /// </summary>
    /// <param name="argument">发布订阅参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    public async Task CreatePrePublishLogAsync( PubsubArgument argument, CancellationToken cancellationToken = default ) {
        var log = CreatePrePublishEventLog( argument );
        await StateManage.SaveAsync( log, cancellationToken );
    }

    /// <summary>
    /// 创建预发布事件日志
    /// </summary>
    protected IntegrationEventLog CreatePrePublishEventLog( PubsubArgument argument ) {
        var result = new IntegrationEventLog {
            Id = argument.Event.Data.EventId,
            AppId = DaprHelper.GetAppId(),
            UserId = Session.UserId,
            PubsubName = argument.Event.Data.PubsubName,
            Topic = argument.Event.Data.Topic,
            Data = argument,
            State = EventState.PrePublish,
            PublishTime = argument.Event.Data.EventTime,
            LastModificationTime = Time.Now
        };
        return result;
    }

}