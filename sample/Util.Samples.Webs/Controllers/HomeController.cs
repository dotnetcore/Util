using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using Microsoft.AspNetCore.Mvc;
using Util.Aspects;
using Util.Datas.Ef.PgSql;
using Util.Domains;
using Util.Exceptions;
using Util.Logs;
using Util.Logs.Abstractions;
using Util.Logs.Aspects;
using Util.Logs.Core;
using Util.Logs.Extensions;
using Util.Samples.Webs.Models;
using Util.Validations.Aspects;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller
    {
        public HomeController() {
            Log = Util.Logs.Log.GetLog( this );
        }

        public ILog Log { get; set; }

        public void Index() {
            Log.Trace("abc");
        }
    }
}
