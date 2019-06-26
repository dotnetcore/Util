using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Services;
using Util.Biz.Payments.Core;
using Util.Biz.Tests.Integration.Payments.Alipay.Configs;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Biz.Tests.Integration.Payments.Alipay.Services {
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
            //结果
            String result = new String();
            result.Append( "<form action=\"https://openapi.alipaydev.com/gateway.do?charset=utf-8\" charset=\"utf-8\" id=\"formAlipay\" method=\"POST\" name=\"formAlipay\" style=\"display:none\">" );
            result.Append( "<input name=\"app_id\" value=\"2016090800463464\"></input>" );
            result.Append( "<input name=\"biz_content\" value=\"{'out_trade_no':'59f7caeeab89e009e4a4e1fb','subject':'test','total_amount':'10','timeout_express':'90m'}\"></input>" );
            result.Append( "<input name=\"charset\" value=\"utf-8\"></input>" );
            result.Append( "<input name=\"format\" value=\"json\"></input>" );
            result.Append( "<input name=\"method\" value=\"alipay.trade.page.pay\"></input>" );
            result.Append( "<input name=\"sign\" value=\"RbC7y6IO1J5lCiZ0GLoAW2SohJ7NW5RFaAK5c+pXvYWowj6TbpFrYNsTqVDbAuAKufG8HCL9wLNsCcysb0esSLNmsEOdTXv71B9TTOoBvOOo0RY5US4QdqXy2zh1JjYIPIVlay8m8yehAXwCOLS+NorQKUYonBlbwpSj1wzOuk23OZJJ8GZk0EmD0i3wBZ2lhs9slta2acVMygeMElvha8w1vlDqGReZLZrS6FR0jSf7+WZJQMHlK36GMTld7BfOtLX2dwUUy+KOKfUDgAcyVVCXZ5z15h7siocBd3JhMV5j/LxmUaKfrKT9z/MmLH5xbqKSAAQSlG0hmvsPLuoxkw==\"></input>" );
            result.Append( "<input name=\"sign_type\" value=\"RSA2\"></input>" );
            result.Append( "<input name=\"timestamp\" value=\"2000-10-10 10:10:10\"></input>" );
            result.Append( "<input name=\"version\" value=\"1.0\"></input>" );
            result.Append( "<input style=\"display:none;\" type=\"submit\" value=\"提交\"></input>" );
            result.Append( "</form>" );
            result.Append( "<script>document.forms['formAlipay'].submit();</script>" );

            //操作
            var form = await Pay();

            //输出
            _output.WriteLine( form );

            //验证
            Assert.Equal( result.ToString(),form );
        }

        /// <summary>
        /// 支付
        /// </summary>
        private async Task<string> Pay() {
            Time.SetTime( TestConst.Time );
            return ( await _service.PayAsync( new PayParam {
                OrderId = "59f7caeeab89e009e4a4e1fb",
                Money = 10,
                Subject = "test"
            } ) ).Result;
        }
    }
}