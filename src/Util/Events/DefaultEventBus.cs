using Util.Events.Handlers;

namespace Util.Events {
    /// <summary>
    /// 默认事件总线
    /// </summary>
    public class DefaultEventBus : IEventBus {
        /// <summary>
        /// 初始化事件总线
        /// </summary>
        /// <param name="manager">事件处理器服务</param>
        public DefaultEventBus( IEventHandlerManager manager ) {
            Manager = manager;
        }

        /// <summary>
        /// 事件处理器服务
        /// </summary>
        public IEventHandlerManager Manager { get; set; }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        public void Publish<TEvent>( TEvent @event ) where TEvent : IEvent {
            var handlers = Manager.GetHandlers<TEvent>();
            foreach ( var handler in handlers )
                handler.Handle( @event );
        }
    }
}
