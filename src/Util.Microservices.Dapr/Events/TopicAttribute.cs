using Topic = Dapr.TopicAttribute;

namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 事件主题
/// </summary>
[AttributeUsage( AttributeTargets.All, AllowMultiple = true )]
public class TopicAttribute : Topic {
    /// <summary>
    /// 初始化事件主题
    /// </summary>
    /// <param name="name">事件主题</param>
    public TopicAttribute( string name ) : base( "pubsub", name ) {
    }

    /// <summary>
    /// 初始化事件主题
    /// </summary>
    /// <param name="pubsubName">发布订阅组件名称</param>
    /// <param name="name">事件主题</param>
    public TopicAttribute( string pubsubName, string name ) : base( pubsubName, name ) {
    }

    /// <summary>
    /// 初始化事件主题
    /// </summary>
    /// <param name="pubsubName">发布订阅组件名称</param>
    /// <param name="name">事件主题</param>
    /// <param name="match">匹配规则,范例: "event.type ==\"v1\""</param>
    /// <param name="priority">匹配优先级</param>
    public TopicAttribute( string pubsubName, string name, string match, int priority ) : base( pubsubName, name, match, priority ) {
    }
}