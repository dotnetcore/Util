using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using Microsoft.AspNetCore.Mvc;
using Util.Aspects;
using Util.Domains;
using Util.Exceptions;
using Util.Logs;
using Util.Logs.Abstractions;
using Util.Logs.Aspects;
using Util.Logs.Extensions;
using Util.Samples.Webs.Models;
using Util.Validations.Aspects;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller
    {
        public HomeController( ICustomService service ) {
            _service = service;

        }

        private readonly ICustomService _service;

        public IActionResult Index() {
            _service.Call(new List<A>{new A()}, "b",2);
            _service.Call2();
            return View();
        }
    }

    [ErrorLog(Order = -100)]
    [DebugLog]
    [TraceLog]
    public interface ICustomService {
        string Call( [Valid] List<A> a,  string value,int length );

        void Call2();
    }

    public class CustomService : ICustomService {
        
        public string Call( List<A> a, string value, int length ) {
            return "11";
        }

        public void Call2() {
        }
    }

    public class A : AggregateRoot<A> {
        public A() : base( Guid.Empty ) {
        }

        [Required(ErrorMessage ="名称不能是空滴")]
        public string Name { get; set; }

        protected override void AddDescriptions() {
            AddDescription( "哈哈" );

        }
    }
}
