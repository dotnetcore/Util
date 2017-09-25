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

        public virtual void Index() {
        }
    }
}
