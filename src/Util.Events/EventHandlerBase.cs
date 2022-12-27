using System.Threading.Tasks;

namespace Util.Events {
    /// <summary>
    /// 本地事件处理器基类
    /// </summary>
    /// <typeparam name="TEvent">事件类型</typeparam>
    public abstract class EventHandlerBase<TEvent> : IEventHandler<TEvent> where TEvent : IEvent {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        public abstract Task HandleAsync( TEvent @event );

        /// <summary>
        /// 序号
        /// </summary>
        public virtual int Order => 0;

        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool Enabled => true;
    }
}
