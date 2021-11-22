using System.Threading.Tasks;

namespace Util.Events.Tests.Samples {
    /// <summary>
    /// 本地事件处理器样例
    /// </summary>
    public class EventHandlerSample : EventHandlerBase<EventSample> {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        public override Task HandleAsync( EventSample @event ) {
            @event.Result = $"1:{@event.Value}";
            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// 本地事件处理器样例2
    /// </summary>
    public class EventHandlerSample2 : EventHandlerBase<EventSample2> {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        public override Task HandleAsync( EventSample2 @event ) {
            @event.Result += "2";
            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// 本地事件处理器样例3
    /// </summary>
    public class EventHandlerSample3 : EventHandlerBase<EventSample2> {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        public override Task HandleAsync( EventSample2 @event ) {
            @event.Result += "3";
            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// 本地事件处理器样例4
    /// </summary>
    public class EventHandlerSample4 : EventHandlerBase<EventSample3> {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        public override Task HandleAsync( EventSample3 @event ) {
            @event.Result += "4";
            return Task.CompletedTask;
        }

        /// <summary>
        /// 序号
        /// </summary>
        public override int Order => 2;
    }

    /// <summary>
    /// 本地事件处理器样例5
    /// </summary>
    public class EventHandlerSample5: EventHandlerBase<EventSample3> {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        public override Task HandleAsync( EventSample3 @event ) {
            @event.Result += "5";
            return Task.CompletedTask;
        }

        /// <summary>
        /// 序号
        /// </summary>
        public override int Order => 1;
    }

    /// <summary>
    /// 本地事件处理器样例6 - 禁用该事件处理器
    /// </summary>
    public class EventHandlerSample6 : EventHandlerBase<EventSample3> {
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="event">事件</param>
        public override Task HandleAsync( EventSample3 @event ) {
            @event.Result += "6";
            return Task.CompletedTask;
        }

        /// <summary>
        /// 序号
        /// </summary>
        public override int Order => 3;

        /// <summary>
        /// 是否启用
        /// </summary>
        public override bool Enabled => false;
    }
}
