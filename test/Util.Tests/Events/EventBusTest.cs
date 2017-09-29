using NSubstitute;
using Util.Events;
using Util.Events.Handlers;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Events {
    /// <summary>
    /// 事件总线测试
    /// </summary>
    public class EventBusTest {
        /// <summary>
        /// 事件处理器
        /// </summary>
        private readonly IEventHandler<EventSample> _handler;
        /// <summary>
        /// 事件总线
        /// </summary>
        private readonly DefaultEventBus _eventBus;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public EventBusTest() {
            _handler = Substitute.For<IEventHandler<EventSample>>();
            var manager = new EventHandlerManagerSample( _handler );
            _eventBus = new DefaultEventBus( manager );
        }

        /// <summary>
        /// 测试发布事件
        /// </summary>
        [Fact]
        public void TestPublish() {
            var eventSample = new EventSample { Name = "a" };
            _eventBus.Publish( eventSample );
            _handler.Received( 1 ).Handle( eventSample );
        }
    }
}
