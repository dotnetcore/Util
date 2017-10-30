using Util.Biz.Payments.Core;
using Util.Biz.Payments.Factories;
using Util.Biz.Tests.Integration.Payments.Alipay.Configs;
using Xunit;
using Xunit.Abstractions;

namespace Util.Biz.Tests.Integration.Payments.Alipay {
    /// <summary>
    /// 支付宝条码支付服务测试
    /// </summary>
    public class AlipayBarcodePayServiceTest {
        /// <summary>
        /// 控制台输出
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 支付服务
        /// </summary>
        private readonly IPayService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AlipayBarcodePayServiceTest( ITestOutputHelper output ) {
            _output = output;
            var factory = new PayFactory( new TestConfigProvider() );
            _service = factory.CreatePayService( PayWay.AlipayBarcodePay );
        }
    }
}
