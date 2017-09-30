using Microsoft.AspNetCore.Mvc;
using Util.Datas.Queries;
using Util.Dependency;
using Util.Events;
using Util.Events.Handlers;
using Util.Logs;
using Util.Logs.Extensions;
using Util.Reflections;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller {
        private IEventBus _eventBus;
        public HomeController( IEventBus eventBus ) {
            _eventBus = eventBus;
        }

        public IActionResult Index() {
            _eventBus.Publish( new TestEvent2{Name = "World"} );
            return View();
        }
    }

    public class TestEvent : IEvent {
        public string Name { get; set; }
    }

    public class TestEvent2 : IEvent {
        public string Name { get; set; }
    }

    public class TestHandler : IEventHandler<TestEvent> {

        private ILog _log;

        public TestHandler( ILog log ) {
            _log = log;
        }

        public void Handle( TestEvent @event ) {
            _log.Caption( $"Hello,{@event.Name}" ).Info();
        }
    }

    public class TestHandler2 : IEventHandler<TestEvent2> {

        private ILog _log;

        public TestHandler2( ILog log ) {
            _log = log;
        }

        public void Handle( TestEvent2 @event ) {
            _log.Caption( $"Hello,{@event.Name}-2" ).Info();
        }
    }
}
