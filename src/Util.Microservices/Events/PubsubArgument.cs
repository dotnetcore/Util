namespace Util.Microservices.Events;

/// <summary>
/// 发布订阅参数
/// </summary>
/// <param name="Pubsub">发布订阅配置名称</param>
/// <param name="Topic">事件主题</param>
/// <param name="EventData">事件数据</param>
/// <param name="Metadata">元数据</param>
public record PubsubArgument( string Pubsub, string Topic, object EventData, Dictionary<string, string> Metadata = null ) 
    : PubsubArgument<object>( Pubsub, Topic, EventData, Metadata ) {
}

/// <summary>
/// 发布订阅参数
/// </summary>
/// <param name="Pubsub">发布订阅配置名称</param>
/// <param name="Topic">事件主题</param>
/// <param name="EventData">事件数据</param>
/// <param name="Metadata">元数据</param>
public record PubsubArgument<TEventData>( string Pubsub, string Topic, TEventData EventData, Dictionary<string, string> Metadata = null ) {
    /// <summary>
    /// 获取事件数据
    /// </summary>
    public T GetEventData<T>() {
        return (T)(object)EventData;
    }
}