using AspectCore.Extensions.AspectScope;
using Microsoft.AspNetCore.Mvc;
using Util.Applications.Aspects;
using Util.Logs;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller
    {
        public HomeController() {
           
        }

        [UnitOfWork(Scope = Scope.Aspect)]
        public virtual void Index() {
      
        }
    }
}
