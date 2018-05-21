using System.Threading.Tasks;
using Util.Events.Handlers;
using Util.Events.Messages;

namespace Util.Events.Default {
    /// <summary>
    /// 事件总线
    /// </summary>
    public class EventBus : IEventBus {
        /// <summary>
        /// 初始化事件总线
        /// </summary>
        /// <param name="manager">事件处理器服务</param>
        /// <param name="messageEventBus">消息事件总线</param>
        public EventBus( IEventHandlerManager manager, IMessageEventBus messageEventBus = null ) {
            Manager = manager;
            MessageEventBus = messageEventBus;
        }

        /// <summary>
        /// 事件处理器服务
        /// </summary>
        public IEventHandlerManager Manager { get; set; }

        /// <summary>
        /// 消息事件总线
        /// </summary>
        public IMessageEventBus MessageEventBus { get; set; }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        public async Task PublishAsync<TEvent>( TEvent @event ) where TEvent : IEvent {
            var handlers = Manager.GetHandlers<TEvent>();
            if ( handlers == null ) {
                await PublishMessageEvents( @event );
                return;
            }
            foreach ( var handler in handlers ) {
                if ( handler == null )
                    continue;
                await handler.HandleAsync( @event );
            }
            await PublishMessageEvents( @event );
        }

        /// <summary>
        /// 发布消息事件
        /// </summary>
        private async Task PublishMessageEvents<TEvent>( TEvent @event ) {
            if ( MessageEventBus == null )
                return;
            if( @event is IMessageEvent messageEvent )
                await MessageEventBus.PublishAsync( messageEvent );
        }
    }
}
