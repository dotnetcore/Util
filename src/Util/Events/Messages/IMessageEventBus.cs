using System.Threading.Tasks;

namespace Util.Events.Messages {
    /// <summary>
    /// 消息事件总线
    /// </summary>
    public interface IMessageEventBus {
        /// <summary>
        /// 发布消息事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">消息事件</param>
        Task PublishAsync<TEvent>( TEvent @event ) where TEvent : IMessageEvent;
    }
}
