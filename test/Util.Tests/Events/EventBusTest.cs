using NSubstitute;
using Util.Events;
using Util.Events.Handlers;
using Util.Events.Memory;
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
        private readonly IEventHandler<EventDataSample> _handler;
        /// <summary>
        /// 事件处理器2
        /// </summary>
        private readonly IEventHandler<EventDataSample> _handler2;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public EventBusTest() {
            _handler = Substitute.For<IEventHandler<EventDataSample>>();
            _handler2 = Substitute.For<IEventHandler<EventDataSample>>();
        }

        /// <summary>
        /// 测试发布事件
        /// </summary>
        [Fact]
        public void TestPublish() {
            var manager = new EventHandlerManagerSample( _handler );
            var eventBus = new EventBus( manager );
            var @event = Event.Create( new EventDataSample {Name = "a"} );
            eventBus.Publish( @event );
            _handler.Received( 1 ).Handle( @event );
        }

        /// <summary>
        /// 测试发布事件
        /// </summary>
        [Fact]
        public void TestPublish_2() {
            var manager = new EventHandlerManagerSample( _handler , _handler2 );
            var eventBus = new EventBus( manager );
            var @event = Event.Create( new EventDataSample { Name = "a" } );
            eventBus.Publish( @event );
            _handler.Received( 1 ).Handle( @event );
            _handler2.Received( 1 ).Handle( @event );
        }
    }
}
