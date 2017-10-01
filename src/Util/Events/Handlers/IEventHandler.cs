namespace Util.Events.Handlers {
    /// <summary>
    /// 事件处理器
    /// </summary>
    public interface IEventHandler {
    }

    /// <summary>
    /// 事件处理器
    /// </summary>
    /// <typeparam name="TData">事件数据类型</typeparam>
    public interface IEventHandler<TData> : IEventHandler {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        void Handle( Event<TData> @event );
    }
}
