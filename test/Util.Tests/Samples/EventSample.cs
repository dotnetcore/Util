using System.Collections.Generic;
using System.Linq;
using Util.Events;
using Util.Events.Handlers;

namespace Util.Tests.Samples {
    /// <summary>
    /// 事件样例
    /// </summary>
    public class EventSample : Event{
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
        /// <typeparam name="TEvent">事件类型</typeparam>
        public List<IEventHandler<TEvent>> GetHandlers<TEvent>() where TEvent : IEvent {
            return _handlers.Select( t => t as IEventHandler<TEvent> ).ToList();
        }

        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        public List<ISyncEventHandler<TEvent>> GetSyncHandlers<TEvent>() where TEvent : IEvent {
            return _handlers.Select( t => t as ISyncEventHandler<TEvent> ).ToList();
        }
    }
}
