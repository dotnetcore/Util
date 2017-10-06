using System;
using DotNetCore.CAP;
using Util.Events.Messages;

namespace Util.Events.Cap {
    /// <summary>
    /// Cap消息事件总线
    /// </summary>
    public class MessageEventBus : IMessageEventBus {
        /// <summary>
        /// Cap事件发布器
        /// </summary>
        private readonly ICapPublisher _publisher;

        /// <summary>
        /// 初始化Cap消息事件总线
        /// </summary>
        /// <param name="publisher">Cap事件发布器</param>
        public MessageEventBus( ICapPublisher publisher ) {
            _publisher = publisher ?? throw new ArgumentNullException( nameof( publisher ) );
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        public void Publish<TEvent>( TEvent @event ) where TEvent : IMessageEvent {
            _publisher.Publish( @event.Target, @event.Data, @event.Callback );
        }
    }
}
