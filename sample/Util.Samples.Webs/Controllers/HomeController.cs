using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Util.Exceptions;
using Util.Logs;
using Util.Logs.Abstractions;
using Util.Logs.Extensions;
using Util.Samples.Webs.Models;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller
    {
        public HomeController( ILogManager logManager ) {
            Log = logManager.GetLog();
        }

        public ILog Log { get; set; }

        public void Index() {
            try {
                Throw();
            }
            catch ( Exception e ) {
                for ( int i = 0; i < 100; i++ ) {
                    Log.Exception( e ).Error();
                }
            }
            
        }

        private void Throw() {
            throw new Exception( "嘿嘿" );
        }
    }
}
