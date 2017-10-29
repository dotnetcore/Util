using Util.Biz.Payments.Core;
using Util.Biz.Payments.Factories;
using Xunit;
using Xunit.Abstractions;

namespace Util.Biz.Tests.Integration.Payments.Alipay {
    /// <summary>
    /// 支付宝当面付测试
    /// </summary>
    public class AlipayF2FPayTest {
        /// <summary>
        /// 控制台输出
        /// </summary>
        private ITestOutputHelper _output;
        /// <summary>
        /// 支付服务
        /// </summary>
        private readonly IPayService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AlipayF2FPayTest( ITestOutputHelper output ) {
            _output = output;
            var factory = new PayFactory( new TestConfigProvider() );
            _service = factory.CreatePayService( PayWay.AlipayF2FPay );
        }

        [Fact]
        public void Test() {
            var result = _service.Pay(new PayParam {
                Money = 10,
                OrderId = "a",
                Subject = "测试"
            });
            _output.WriteLine( result.Result );
            Assert.True( result.Success );
        }
    }
}
