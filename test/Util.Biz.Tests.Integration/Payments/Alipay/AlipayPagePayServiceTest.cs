using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Services;
using Util.Biz.Payments.Core;
using Util.Biz.Tests.Integration.Payments.Alipay.Configs;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Biz.Tests.Integration.Payments.Alipay {
    /// <summary>
    /// 支付宝电脑网站支付服务测试
    /// </summary>
    public class AlipayPagePayServiceTest : System.IDisposable {
        /// <summary>
        /// 控制台输出
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 支付宝电脑网站支付服务
        /// </summary>
        private readonly AlipayPagePayService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AlipayPagePayServiceTest( ITestOutputHelper output ) {
            _output = output;
            _service = new AlipayPagePayService( new TestConfigProvider() );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Time.Reset();
        }

        /// <summary>
        /// 测试获取支付表单
        /// </summary>
        [Fact]
        public async Task TestPayAsync() {
            Time.SetTime( "2018-5-22 11:11:11" );
            String result = new String();
            result.Append( "<form action=\"https://openapi.alipaydev.com/gateway.do?charset=utf-8\" charset=\"utf-8\" id=\"formAlipay\" method=\"POST\" name=\"formAlipay\">" );
            result.Append( "<input name=\"app_id\" value=\"2016090800463464\"></input>" );
            result.Append( "<input name=\"biz_content\" value=\"{'out_trade_no':'59f7caeeab89e009e4a4e1fb','subject':'test','total_amount':'10','timeout_express':'90m'}\"></input>" );
            result.Append( "<input name=\"charset\" value=\"utf-8\"></input>" );
            result.Append( "<input name=\"format\" value=\"json\"></input>" );
            result.Append( "<input name=\"method\" value=\"alipay.trade.page.pay\"></input>" );
            result.Append( "<input name=\"sign\" value=\"bIAv4ZNiDL4spW0cG6E3TdRM/hpUEtbz2YjOSYStFSMY8M5U8ocxdN2IXjXR/lSjk0q32kIcXj/CO0u1bTan7eqgDvC0W3YoiSSEMPzOPH6zSVgpJ2jtU0ULGLes0OClQFjWmgXbjI+jaH/2vT4FaBbP3asueE9kgVR+TgmZM2c0Zat6/ULSwiGXDe4MNxghG5f8xjc+uEoBn6b+AQBp6uAk6pmXtD7zYGKJBS5xNuotSt3L12/ImMKGhMOHOpG31ulPl6cq2s5Qb3dCbZUd3Svvl41dYAQJZ8BqCQseAW7JVArGd2L/BAzEThapF8reYQTT7rvW1Umx7ZOMRGlF4Q==\"></input>" );
            result.Append( "<input name=\"sign_type\" value=\"RSA2\"></input>" );
            result.Append( "<input name=\"timestamp\" value=\"2018-05-22 11:11:11\"></input>" );
            result.Append( "<input name=\"version\" value=\"1.0\"></input>" );
            result.Append( "<input style=\"display:none;\" type=\"submit\" value=\"提交\"></input>" );
            result.Append( "</form>" );
            result.Append( "<script>document.forms['formAlipay'].submit();</script>" );
            var form = (await _service.PayAsync( new PayParam {
                OrderId = "59f7caeeab89e009e4a4e1fb",
                Money = 10,
                Subject = "test"
            } )).Result;
            _output.WriteLine( form );
            Assert.Equal( result.ToString(),form );
        }
    }
}