using System.Collections.Generic;

namespace Util.Events.Handlers {
    /// <summary>
    /// 事件处理器服务
    /// </summary>
    public interface IEventHandlerManager {
        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        List<IEventHandler<TEvent>> GetHandlers<TEvent>() where TEvent : IEvent;
    }
}
