using System.Collections.Generic;
using Util.Events.Handlers;
using Util.Helpers;

namespace Util.Events.Memory {
    /// <summary>
    /// 事件处理器服务
    /// </summary>
    public class EventHandlerManager : IEventHandlerManager {
        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        /// <typeparam name="TData">事件数据类型</typeparam>
        public List<IEventHandler<TData>> GetHandlers<TData>() {
            return Ioc.CreateList<IEventHandler<TData>>();
        }
    }
}
