using System;
using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Parameters.Requests;
using Util.Biz.Payments.Alipay.Services;
using Util.Biz.Payments.Core;
using Util.Biz.Tests.Integration.Payments.Alipay.Configs;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Biz.Tests.Integration.Payments.Alipay.Services {
    /// <summary>
    /// 支付宝二维码支付服务测试
    /// </summary>
    public class AlipayQrCodePayServiceTest : IDisposable {
        /// <summary>
        /// 控制台输出
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 支付宝二维码支付服务
        /// </summary>
        private AlipayQrCodePayService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AlipayQrCodePayServiceTest( ITestOutputHelper output ) {
            _output = output;
            _service = new AlipayQrCodePayService( new TestConfigProvider() );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Time.Reset();
        }

        /// <summary>
        /// 测试支付
        /// </summary>
        [Fact]
        public async Task TestPayAsync_1() {
            var result = await _service.PayAsync( new PayParam {
                Money = 10,
                OrderId = Id.Guid()
            } );
            _output.WriteLine( $"Message:{result.Message}" );
            _output.WriteLine( $"Raw:{result.Raw}" );
            Assert.True( result.Success );
            Assert.Contains( "qr.alipay.com", result.Result );
        }

        /// <summary>
        /// 测试支付
        /// </summary>
        [Fact]
        public async Task TestPayAsync_2() {
            var result = await _service.PayAsync( new AlipayPrecreateRequest {
                Money = 10,
                OrderId = Id.Guid()
            } );
            _output.WriteLine( result );
            Assert.Contains( "qr.alipay.com", result );
        }
    }
}