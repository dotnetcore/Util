using System;
using System.Threading.Tasks;
using DotNetCore.CAP;

namespace Util.Events.Cap {
    /// <summary>
    /// Cap事件总线
    /// </summary>
    public class EventBus : IEventBus {
        /// <summary>
        /// 初始化Cap事件总线
        /// </summary>
        /// <param name="publisher">事件发布器</param>
        public EventBus( ICapPublisher publisher ) {
            Publisher = publisher ?? throw new ArgumentNullException( nameof( publisher ) );
        }

        /// <summary>
        /// 事件发布器
        /// </summary>
        public ICapPublisher Publisher { get; set; }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        public async Task PublishAsync<TEvent>( TEvent @event ) where TEvent : IEvent {
            if ( !( @event is IMessageEvent messageEvent ) )
                return;
            await Publisher.PublishAsync( messageEvent.Target, messageEvent.Data, messageEvent.Callback );
        }
    }
}
