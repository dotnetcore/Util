using System;
using System.Threading.Tasks;

namespace Util.Events.Cap {
    /// <summary>
    /// Cap事件总线
    /// </summary>
    public class EventBus : IEventBus {
        /// <summary>
        /// 初始化Cap事件总线
        /// </summary>
        /// <param name="simpleEventBus">基于内存的简单事件总线</param>
        /// <param name="messageEventBus">Cap消息事件总线</param>
        public EventBus( ISimpleEventBus simpleEventBus, IMessageEventBus messageEventBus ) {
            SimpleEventBus = simpleEventBus ?? throw new ArgumentNullException( nameof( simpleEventBus ) );
            MessageEventBus = messageEventBus ?? throw new ArgumentNullException( nameof( messageEventBus ) );
        }

        /// <summary>
        /// 基于内存的简单事件总线
        /// </summary>
        public ISimpleEventBus SimpleEventBus { get; set; }
        /// <summary>
        /// Cap消息事件总线
        /// </summary>
        public IMessageEventBus MessageEventBus { get; set; }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        public async Task PublishAsync<TEvent>( TEvent @event ) where TEvent : IEvent {
            await SimpleEventBus.PublishAsync( @event );
            if( !( @event is IMessageEvent messageEvent ) )
                return;
            await MessageEventBus.PublishAsync( messageEvent );
        }
    }
}
