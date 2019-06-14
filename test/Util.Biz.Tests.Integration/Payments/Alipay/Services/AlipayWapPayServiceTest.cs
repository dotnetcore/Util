using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Services;
using Util.Biz.Payments.Core;
using Util.Biz.Tests.Integration.Payments.Alipay.Configs;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Biz.Tests.Integration.Payments.Alipay.Services {
    /// <summary>
    /// 支付宝手机网站支付服务测试
    /// </summary>
    public class AlipayWapPayServiceTest : System.IDisposable {
        /// <summary>
        /// 控制台输出
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 支付宝手机网站支付服务
        /// </summary>
        private readonly AlipayWapPayService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AlipayWapPayServiceTest( ITestOutputHelper output ) {
            _output = output;
            _service = new AlipayWapPayService( new TestConfigProvider() );
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
            Time.SetTime( TestConst.Time );
            String result = new String();
            result.Append( "<form action=\"https://openapi.alipaydev.com/gateway.do?charset=utf-8\" charset=\"utf-8\" id=\"formAlipay\" method=\"POST\" name=\"formAlipay\" style=\"display:none\">" );
            result.Append( "<input name=\"app_id\" value=\"2016090800463464\"></input>" );
            result.Append( "<input name=\"biz_content\" value=\"{'out_trade_no':'59f7caeeab89e009e4a4e1fb','subject':'test','total_amount':'10','timeout_express':'90m'}\"></input>" );
            result.Append( "<input name=\"charset\" value=\"utf-8\"></input>" );
            result.Append( "<input name=\"format\" value=\"json\"></input>" );
            result.Append( "<input name=\"method\" value=\"alipay.trade.wap.pay\"></input>" );
            result.Append( "<input name=\"sign\" value=\"V81oDQtqMdh7WNR4NuztnWhJPCpbIcbZ2/JbzO5KeNGWW+E8HqTq8S1FMYwcHQw4GHnfJLyWJfYEKWW1VMMYKnyM09i1Ei7TwqnlZI4nyhCysbInaGceAoX4rHGsSsvFizFV+h65TDLfTHR3vVB3prftW0lJko7bBuJJ3qHCObO+wXDflRwITdKI7Trqkt4di0rCX2j3Ez+DxmOQhN8z+Bob7J4APH9m9GBKjeuoAW0/24QjgNODpZOYx+ASD0xfvfF2hhHAQNcUIJ/N5g+8Wr8y6AE141NCu35bEEf6ApmQNKjbikFB8cwXVJQmky4qohP0GfVQlMzqgnAoqVFEJA==\"></input>" );
            result.Append( "<input name=\"sign_type\" value=\"RSA2\"></input>" );
            result.Append( "<input name=\"timestamp\" value=\"2000-10-10 10:10:10\"></input>" );
            result.Append( "<input name=\"version\" value=\"1.0\"></input>" );
            result.Append( "<input style=\"display:none;\" type=\"submit\" value=\"提交\"></input>" );
            result.Append( "</form>" );
            result.Append( "<script>document.forms['formAlipay'].submit();</script>" );
            var form = ( await _service.PayAsync( new PayParam {
                OrderId = "59f7caeeab89e009e4a4e1fb",
                Money = 10,
                Subject = "test"
            } ) ).Result;
            _output.WriteLine( form );
            Assert.Equal( result.ToString(), form );
        }
    }
}