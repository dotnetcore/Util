using Microsoft.AspNetCore.Mvc;
using Util.Biz.Payments.Core;
using Util.Biz.Payments.Factories;
using Util.Biz.Tests.Integration.Payments.Alipay;
using Util.Biz.Tests.Integration.Payments.Alipay.Configs;
using Util.Helpers;
using Util.Tools.QrCode;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller {

        public HomeController(  ) {
        }

        public IActionResult Index( string id ) {
            var factory = new PayFactory( new TestConfigProvider() );
            var service = factory.CreatePayService( PayWay.AlipayBarcodePay );
            var result = service.Pay( new PayParam {
                Money = 10,
                OrderId = Id.ObjectId(),
                Subject = "test",
                AuthCode = id
            } );
            return Content( result.Result , "text/html;charset=gb2312" );
        }

        public IActionResult Error() {
            return View();
        }

        public IActionResult A() {
            return View();
        }
    }
}
