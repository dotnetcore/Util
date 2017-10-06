namespace Util.Events.Messages {
    /// <summary>
    /// 消息事件总线
    /// </summary>
    public interface IMessageEventBus {
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        void Publish<TEvent>( TEvent @event ) where TEvent : IMessageEvent;
    }
}
