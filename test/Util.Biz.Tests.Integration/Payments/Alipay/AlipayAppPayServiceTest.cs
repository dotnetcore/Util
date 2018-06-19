using System;
using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Parameters.Requests;
using Util.Biz.Payments.Alipay.Services;
using Util.Biz.Payments.Core;
using Util.Biz.Tests.Integration.Payments.Alipay.Configs;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Biz.Tests.Integration.Payments.Alipay {
    /// <summary>
    /// 支付宝App支付服务测试
    /// </summary>
    public class AlipayAppPayServiceTest : IDisposable {
        /// <summary>
        /// 控制台输出
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 支付宝App支付服务
        /// </summary>
        private readonly AlipayAppPayService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AlipayAppPayServiceTest( ITestOutputHelper output ) {
            _output = output;
            _service = new AlipayAppPayService( new TestConfigProvider() );
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
            Time.SetTime( "2017-10-31 08:59:26" );
            var result = await _service.PayAsync( new PayParam {
                Money = 10,
                OrderId = "59f7caeeab89e009e4a4e1fb",
                Subject = "test",
                ReturnUrl = "a",
                NotifyUrl = "b"
            } );
            _output.WriteLine( $"result:{result.Result}" );
            Assert.Equal( GetResult(), result.Result );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            Util.Helpers.String result = new Util.Helpers.String();
            result.Append( "app_id=2016090800463464&" );
            result.Append( "biz_content={\"out_trade_no\":\"59f7caeeab89e009e4a4e1fb\",\"subject\":\"test\",\"total_amount\":\"10\",\"timeout_express\":\"90m\"}&" );
            result.Append( "charset=utf-8&" );
            result.Append( "format=json&" );
            result.Append( "method=alipay.trade.app.pay&" );
            result.Append( "notify_url=b&" );
            result.Append( "return_url=a&" );
            result.Append( "sign=ppnaNEdqch5JmMTWHgcThsXAMQ7qOFuMirAZhOBCjtvn8h3gcAd2HaGlV/5fL60X3ExWgmifeqbP2uOteIOG2+OZju3whhCkugk2IZZXQ82pf1ZMR1FnF660PyUPyvZdbQJ85wsNkWWnkWCIJlCXWblNlYrxSB5zitlVTWoUYwe98VI76/zGUTa/ZAaD2fXGNh8Ov4aZd2GRhzeTpfKrMWrp7GeGbQi5hzouhkqyi3kZQrNldc0O2HCWpKJq4gxL/aF+6KbUkvdHZzsvWlc35fLRv4P7TnQqxkVrV96+1U4b+0WtMrevSardJKG0hdo7A4IHJJdxxP9qdo2xxKcm7Q==&" );
            result.Append( "sign_type=RSA2&" );
            result.Append( "timestamp=2017-10-31 08:59:26&" );
            result.Append( "version=1.0" );
            return result.ToString();
        }

        /// <summary>
        /// 测试支付
        /// </summary>
        [Fact]
        public async Task TestPayAsync_2() {
            Time.SetTime( "2017-10-31 08:59:26" );
            var result = await _service.PayAsync( new AlipayAppPayRequest() {
                Money = 10,
                OrderId = "59f7caeeab89e009e4a4e1fb",
                Subject = "test",
                ReturnUrl = "a",
                NotifyUrl = "b"
            } );
            _output.WriteLine( $"result:{result}" );
            Assert.Equal( GetResult(), result );
        }
    }
}