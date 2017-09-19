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
            Log = logManager.GetLog(this);
        }

        public ILog Log { get; set; }

        public void Index() {
            Log.BusinessId( Guid.NewGuid().ToString() )
                .Module( "订单" )
                .ParamsLine( "{0},{1}", 1, 2 )
                .Params( "{0},{1}", 3, 4 )
                .Caption( "有新的订单来了" )
                .ContentLine( "购买商品数量: {0}", 100 )
                .Content( "购买商品总额：{0}", 200 )
                .SqlLine( "select * from system.users" )
                .Sql( "select * from system.roles" )
                .SqlParamsLine( "@a={0},@b={1}", 1, 2 )
                .SqlParams( "@userId={0}", Guid.NewGuid().ToString() )
                .Info();

            try {
                Throw();
            }
            catch ( Exception e ) {
                Log.BusinessId( Guid.NewGuid().ToString() )
                    .Module( "订单" )
                    .Exception( e )
                    .Error();
            }
                
            
        }

        private void Throw() {
            try {
                Throw2();
            }
            catch( Exception e ) {
                throw new NotImplementedException( "Throw",e );
            }
        }

        private void Throw2() {
            try {
                Throw3();
            }
            catch ( Exception e ) {
                throw new NotImplementedException( "Throw2",e );
            }
            
        }

        private void Throw3() {
            throw new NotImplementedException( "Throw3" );
        }
    }
}
