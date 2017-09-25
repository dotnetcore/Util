using AspectCore.Extensions.AspectScope;
using Microsoft.AspNetCore.Mvc;
using Util.Applications.Aspects;
using Util.Helpers;
using Util.Logs;
using Util.Logs.Abstractions;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller
    {
        public HomeController() {
           
        }

        [UnitOfWork(Scope = Scope.Aspect)]
        public virtual void Index() {
            
            var a =  Ioc.Create<IGet>( "a" ).Get();
            var a1 = Ioc.Create<IGet>( "a" ).Get();
            var b = Ioc.Create<IGet>( "b" ).Get();
            var b1 = Ioc.Create<IGet>( "b" ).Get();
        }
    }

    public interface IGet {
        string Get();
    }

    public class A : IGet {

        public A( ILogContext context ) {
            _context = context;
        }

        private ILogContext _context;
        public string Get() {
            return _context.TraceId;
        }
    }

    public class B : IGet {

        public B( ILogContext context ) {
            _context = context;
        }

        private ILogContext _context;
        public string Get() {
            return _context.TraceId;
        }
    }
}
