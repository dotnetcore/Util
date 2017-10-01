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
            _eventBus.Publish( Event.Create( new TestEventData { Name = "World" } ) );
            return View();
        }
    }

    public class TestEventData {
        public string Name { get; set; }
    }

    public class TestEventData2 {
        public string Name { get; set; }
    }

    public class TestHandler : IEventHandler<TestEventData> {

        private ILog _log;

        public TestHandler( ILog log ) {
            _log = log;
        }

        public void Handle( Event<TestEventData> @event ) {
            _log.Caption( $"Hello,{@event.Data.Name}" ).Fatal();
        }
    }

    public class TestHandler2 : IEventHandler<TestEventData2> {

        private ILog _log;

        public TestHandler2( ILog log ) {
            _log = log;
        }

        public void Handle( Event<TestEventData2> @event ) {
            _log.Caption( $"Hello,{@event.Data.Name}-2" ).Info();
        }
    }
}
