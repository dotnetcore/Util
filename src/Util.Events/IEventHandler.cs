using System.Threading.Tasks;

namespace Util.Events {
    /// <summary>
    /// 本地事件处理器
    /// </summary>
    public interface IEventHandler {
        /// <summary>
        /// 序号
        /// </summary>
        int Order { get; }
        /// <summary>
        /// 是否启用
        /// </summary>
        bool Enabled { get; }
    }

    /// <summary>
    /// 本地事件处理器
    /// </summary>
    /// <typeparam name="TEvent">事件类型</typeparam>
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : IEvent {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        Task HandleAsync( TEvent @event ) ;
    }
}
