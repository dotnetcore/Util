using System.Threading.Tasks;

namespace Util.Events {
    /// <summary>
    /// 事件总线
    /// </summary>
    public interface IEventBus {
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        Task PublishAsync<TEvent>( TEvent @event ) where TEvent : IEvent;
    }
}
