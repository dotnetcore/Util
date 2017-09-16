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
        public HomeController( ILogManager manager ) {
            Log = manager.GetLog(this);
        }

        public ILog Log { get; set; }

        public void Index() {
            try {
                Throw();
            }
            catch ( Exception ex ) {

                Log.BusinessId( Guid.NewGuid().ToString() )
                    .Module( "订单" )
                    .Method( "PlaceOrder" )
                    .ParamsLine( "{0},{1}", 1, 2 )
                    .Params( "{0},{1}", 3, 4 )
                    .Caption( "有人下单了" )
                    .ContentLine( "购买商品数量: {0}", 100 )
                    .Content( "购买商品总额：{0}", 200 )
                    .SqlLine( "select * from system.users" )
                    .Sql( "select * from system.roles" )
                    .SqlParamsLine( "@a={0},@b={1}", 1, 2 )
                    .SqlParams( "@userId={0}", Guid.NewGuid().ToString() )
                    .Exception( ex, "100" )
                    .Trace();

                Log.BusinessId( Guid.NewGuid().ToString() )
                    .Module( "订单" )
                    .Method( "PlaceOrder" )
                    .ParamsLine( "{0},{1}", 1, 2 )
                    .Params( "{0},{1}", 3, 4 )
                    .Caption( "有人下单了" )
                    .ContentLine( "购买商品数量: {0}", 100 )
                    .Content( "购买商品总额：{0}", 200 )
                    .SqlLine( "select * from system.users" )
                    .Sql( "select * from system.roles" )
                    .SqlParamsLine( "@a={0},@b={1}", 1, 2 )
                    .SqlParams( "@userId={0}", Guid.NewGuid().ToString() )
                    .Exception( ex, "100" )
                    .Debug();

                Log.BusinessId( Guid.NewGuid().ToString() )
                    .Module( "订单" )
                    .Method( "PlaceOrder" )
                    .ParamsLine( "{0},{1}", 1, 2 )
                    .Params( "{0},{1}", 3, 4 )
                    .Caption( "有人下单了" )
                    .ContentLine( "购买商品数量: {0}", 100 )
                    .Content( "购买商品总额：{0}", 200 )
                    .SqlLine( "select * from system.users" )
                    .Sql( "select * from system.roles" )
                    .SqlParamsLine( "@a={0},@b={1}", 1, 2 )
                    .SqlParams( "@userId={0}", Guid.NewGuid().ToString() )
                    .Exception( ex, "100" )
                    .Info();

                Log.BusinessId( Guid.NewGuid().ToString() )
                    .Module( "订单" )
                    .Method( "PlaceOrder" )
                    .ParamsLine( "{0},{1}", 1, 2 )
                    .Params( "{0},{1}", 3, 4 )
                    .Caption( "有人下单了" )
                    .ContentLine( "购买商品数量: {0}", 100 )
                    .Content( "购买商品总额：{0}", 200 )
                    .SqlLine( "select * from system.users" )
                    .Sql( "select * from system.roles" )
                    .SqlParamsLine( "@a={0},@b={1}", 1, 2 )
                    .SqlParams( "@userId={0}", Guid.NewGuid().ToString() )
                    .Exception( ex, "100" )
                    .Warn();

                Log.BusinessId( Guid.NewGuid().ToString() )
                    .Module( "订单" )
                    .Method( "PlaceOrder" )
                    .ParamsLine( "{0},{1}", 1, 2 )
                    .Params( "{0},{1}", 3, 4 )
                    .Caption( "有人下单了" )
                    .ContentLine( "购买商品数量: {0}", 100 )
                    .Content( "购买商品总额：{0}", 200 )
                    .SqlLine( "select * from system.users" )
                    .Sql( "select * from system.roles" )
                    .SqlParamsLine( "@a={0},@b={1}", 1, 2 )
                    .SqlParams( "@userId={0}", Guid.NewGuid().ToString() )
                    .Exception( ex, "100" )
                    .Error();

                Log.BusinessId( Guid.NewGuid().ToString() )
                    .Module( "订单" )
                    .Method( "PlaceOrder" )
                    .ParamsLine( "{0},{1}", 1, 2 )
                    .Params( "{0},{1}", 3, 4 )
                    .Caption( "有人下单了" )
                    .ContentLine( "购买商品数量: {0}", 100 )
                    .Content( "购买商品总额：{0}", 200 )
                    .SqlLine( "select * from system.users" )
                    .Sql( "select * from system.roles" )
                    .SqlParamsLine( "@a={0},@b={1}", 1, 2 )
                    .SqlParams( "@userId={0}", Guid.NewGuid().ToString() )
                    .Exception( ex, "100" )
                    .Fatal();
            }
        }

        private void Throw() {
            throw new NotImplementedException( "我还没有实现" );
        }

        public IActionResult Error() {
            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
