using DotNetCore.CAP;

namespace Util.Events.Cap {
    /// <summary>
    /// Cap事件总线
    /// </summary>
    public class EventBus : IEventBus {
        /// <summary>
        /// Cap事件发布器
        /// </summary>
        private readonly ICapPublisher _publisher;

        /// <summary>
        /// 初始化Cap事件总线
        /// </summary>
        /// <param name="publisher">Cap事件发布器</param>
        public EventBus( ICapPublisher publisher ) {
            _publisher = publisher;
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        public void Publish<TEvent>( TEvent @event ) where TEvent : IEvent {
            if ( !( @event is ICapEvent capEvent ) )
                return;
            _publisher.Publish( capEvent.Name, capEvent.Content, capEvent.Callback );
        }
    }
}
