using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using Microsoft.AspNetCore.Mvc;
using Util.Aspects;
using Util.Exceptions;
using Util.Logs;
using Util.Logs.Abstractions;
using Util.Logs.Aspects;
using Util.Logs.Extensions;
using Util.Samples.Webs.Models;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller
    {
        public HomeController( ICustomService service ) {
            _service = service;

        }

        private readonly ICustomService _service;

        public IActionResult Index() {
            _service.Call(" ","b",2);
            _service.Call2();
            return View();
        }
    }

    [ErrorLog(Order = -100)]
    [DebugLog]
    [TraceLog]
    public interface ICustomService {
        string Call([NotEmpty] string name,string value,int length );

        void Call2();
    }

    public class CustomService : ICustomService {
        
        public string Call( string name, string value, int length ) {
            return "11";
        }

        public void Call2() {
        }
    }

   
}
