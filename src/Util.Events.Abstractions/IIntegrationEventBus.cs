namespace Util.Events; 

/// <summary>
/// 基于消息的集成事件总线
/// </summary>
public interface IIntegrationEventBus {
    /// <summary>
    /// 发布事件
    /// </summary>
    /// <typeparam name="TEvent">事件类型</typeparam>
    /// <param name="event">事件</param>
    /// <param name="sendNow">是否立即发送事件,默认为true,如果希望发送操作延迟到工作单元提交成功后,则设置为false</param>
    /// <param name="topic">主题名称,默认使用类型名称作为主题</param>
    /// <param name="pubsubName">发布订阅配置名称,默认值: pubsub</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task PublishAsync<TEvent>( TEvent @event, bool sendNow = true, string topic = "", string pubsubName= "pubsub", CancellationToken cancellationToken = default ) where TEvent : IIntegrationEvent;
}