using System;
using System.Threading.Tasks;
using Util.Events.Handlers;

namespace Util.Events.Default {
    /// <summary>
    /// 基于内存的简单事件总线
    /// </summary>
    public class EventBus : ISimpleEventBus {
        /// <summary>
        /// 初始化事件总线
        /// </summary>
        /// <param name="manager">事件处理器服务</param>
        public EventBus( IEventHandlerManager manager ) {
            Manager = manager ?? throw new ArgumentNullException(nameof(manager));
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
        public async Task PublishAsync<TEvent>( TEvent @event ) where TEvent : IEvent {
            var handlers = Manager.GetHandlers<TEvent>();
            if ( handlers == null )
                return;
            foreach ( var handler in handlers ) {
                if ( handler == null )
                    continue;
                await handler.HandleAsync( @event );
            }
        }
    }
}
