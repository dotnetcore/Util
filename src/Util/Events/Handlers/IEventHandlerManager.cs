using System.Collections.Generic;

namespace Util.Events.Handlers {
    /// <summary>
    /// 事件处理器服务
    /// </summary>
    public interface IEventHandlerManager {
        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        /// <typeparam name="TData">事件数据类型</typeparam>
        List<IEventHandler<TData>> GetHandlers<TData>();
    }
}
