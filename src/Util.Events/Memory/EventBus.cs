using Util.Events.Handlers;
using Util.Logs.Aspects;

namespace Util.Events.Memory {
    /// <summary>
    /// 事件总线
    /// </summary>
    public class EventBus : IEventBus {
        /// <summary>
        /// 初始化事件总线
        /// </summary>
        /// <param name="manager">事件处理器服务</param>
        public EventBus( IEventHandlerManager manager ) {
            Manager = manager;
        }

        /// <summary>
        /// 事件处理器服务
        /// </summary>
        public IEventHandlerManager Manager { get; set; }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TData">事件数据类型</typeparam>
        /// <param name="event">事件</param>
        [TraceLog]
        public void Publish<TData>( Event<TData> @event ) {
            var handlers = Manager.GetHandlers<TData>();
            if( handlers == null )
                return;
            foreach( var handler in handlers )
                handler.Handle( @event );
        }
    }
}
