using DotNetCore.CAP.Abstractions;

namespace Util.Events {
    /// <summary>
    /// 事件处理器
    /// </summary>
    public class EventHandlerAttribute : TopicAttribute {
        /// <summary>
        /// 初始化事件处理器
        /// </summary>
        /// <param name="name">消息名称</param>
        public EventHandlerAttribute( string name ) : base( name ) {
        }
    }
}
