namespace Util.Events; 

/// <summary>
/// 基于消息的集成事件总线
/// </summary>
public interface IIntegrationEventBus : ITransientDependency {
    /// <summary>
    /// 设置发布订阅配置名称
    /// </summary>
    /// <param name="pubsubName">发布订阅配置名称</param>
    IIntegrationEventBus PubsubName( string pubsubName );
    /// <summary>
    /// 设置事件主题,默认为事件类型名称
    /// </summary>
    /// <param name="topic">事件主题</param>
    IIntegrationEventBus Topic( string topic );
    /// <summary>
    /// 设置请求头
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    IIntegrationEventBus Header( string key, string value );
    /// <summary>
    /// 设置请求头
    /// </summary>
    /// <param name="headers">请求头键值对集合</param>
    IIntegrationEventBus Header( IDictionary<string, string> headers );
    /// <summary>
    /// 从当前HttpContext导入请求头
    /// </summary>
    /// <param name="key">请求头键名</param>
    IIntegrationEventBus ImportHeader( string key );
    /// <summary>
    /// 从当前HttpContext导入请求头
    /// </summary>
    /// <param name="keys">请求头键名集合</param>
    IIntegrationEventBus ImportHeader( IEnumerable<string> keys );
    /// <summary>
    /// 移除请求头
    /// </summary>
    /// <param name="key">请求头键名</param>
    IIntegrationEventBus RemoveHeader( string key );
    /// <summary>
    /// 设置元数据
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="value">值</param>
    IIntegrationEventBus Metadata( string key, string value );
    /// <summary>
    /// 设置元数据
    /// </summary>
    /// <param name="metadata">元数据键值对集合</param>
    IIntegrationEventBus Metadata( IDictionary<string, string> metadata );
    /// <summary>
    /// 移除元数据
    /// </summary>
    /// <param name="key">键</param>
    IIntegrationEventBus RemoveMetadata( string key );
    /// <summary>
    /// 设置云事件属性: type
    /// </summary>
    /// <param name="value">值</param>
    IIntegrationEventBus Type( string value );
    /// <summary>
    /// 发布前事件
    /// </summary>
    /// <param name="action">发布前操作,返回false取消发布</param>
    IIntegrationEventBus OnBefore( Func<IIntegrationEvent, Dictionary<string, string>, Dictionary<string, string>, bool> action );
    /// <summary>
    /// 发布后事件
    /// </summary>
    /// <param name="action">发布后操作</param>
    IIntegrationEventBus OnAfter( Func<IIntegrationEvent, Dictionary<string, string>, Dictionary<string, string>, Task> action );
    /// <summary>
    /// 发布事件
    /// </summary>
    /// <typeparam name="TEvent">事件类型</typeparam>
    /// <param name="event">事件</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task PublishAsync<TEvent>( TEvent @event, CancellationToken cancellationToken = default ) where TEvent : IIntegrationEvent;
    /// <summary>
    /// 重新发布集成事件
    /// </summary>
    /// <param name="eventId">事件标识</param>
    /// <param name="cancellationToken">取消令牌</param>
    Task RepublishAsync( string eventId, CancellationToken cancellationToken = default );
}