namespace Util.Events {
    /// <summary>
    /// 事件总线
    /// </summary>
    public interface IEventBus {
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TData">事件数据类型</typeparam>
        /// <param name="event">事件</param>
        void Publish<TData>( Event<TData> @event );
    }
}
