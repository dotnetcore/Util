using Microsoft.AspNetCore.Mvc;
using Util.Biz.Payments.Core;
using Util.Biz.Payments.Factories;
using Util.Biz.Tests.Integration.Payments.Alipay;
using Util.Tools.QrCode;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller {

        public HomeController(  ) {
        }

        public IActionResult Index() {
            var factory = new PayFactory( new TestConfigProvider() );
            var service = factory.CreatePayService( PayWay.AlipayF2FPay );
            var result = service.Pay( new PayParam {
                Money = 10,
                OrderId = "a",
                Subject = "测试"
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
