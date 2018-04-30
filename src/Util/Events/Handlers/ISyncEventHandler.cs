namespace Util.Events.Handlers {
    /// <summary>
    /// 同步事件处理器
    /// </summary>
    public interface ISyncEventHandler : IEventHandler {
    }

    /// <summary>
    /// 同步事件处理器
    /// </summary>
    /// <typeparam name="TEvent">事件类型</typeparam>
    public interface ISyncEventHandler<in TEvent> : ISyncEventHandler where TEvent : IEvent {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        void Handle( TEvent @event ) ;
    }
}
