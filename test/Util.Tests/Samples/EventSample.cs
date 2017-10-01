using System.Collections.Generic;
using System.Linq;
using Util.Events;
using Util.Events.Handlers;

namespace Util.Tests.Samples {
    /// <summary>
    /// 事件数据样例
    /// </summary>
    public class EventDataSample {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// 事件处理器服务样例
    /// </summary>
    public class EventHandlerManagerSample : IEventHandlerManager {
        /// <summary>
        /// 事件处理器列表
        /// </summary>
        private readonly IEventHandler[] _handlers;

        /// <summary>
        /// 初始化事件处理器服务样例
        /// </summary>
        /// <param name="handlers">事件处理器列表</param>
        public EventHandlerManagerSample( params IEventHandler[] handlers ) {
            _handlers = handlers;
        }

        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        /// <typeparam name="TData">事件数据类型</typeparam>
        public List<IEventHandler<TData>> GetHandlers<TData>() {
            return _handlers.Select( t => t as IEventHandler<TData> ).ToList();
        }
    }
}
