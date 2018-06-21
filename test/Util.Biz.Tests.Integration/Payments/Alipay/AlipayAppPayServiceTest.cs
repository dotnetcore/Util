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
            Time.SetTime( "2018-5-22 11:11:11" );
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
            result.Append( "biz_content=%7b%22out_trade_no%22%3a%2259f7caeeab89e009e4a4e1fb%22%2c%22subject%22%3a%22test%22%2c%22total_amount%22%3a%2210%22%2c%22timeout_express%22%3a%2290m%22%7d&" );
            result.Append( "charset=utf-8&" );
            result.Append( "format=json&" );
            result.Append( "method=alipay.trade.app.pay&" );
            result.Append( "notify_url=b&" );
            result.Append( "return_url=a&" );
            result.Append( "sign=Qo2CG5r%2fz4h2vQySXP78ZsFMYZuogJ8RyzNPXwAu74TDcgZ9P27S37DAz2pgvTnE%2b%2bB6wESsUX8RYpyePTTO40fSDQzcTrfwoltImEFK7iVrY1OlmCRvoH6FVaZoXaypKH1ZOLMf0%2fSofzsI7OVrcdA58YcGvJbBLM8ppfzLDIKT10rwQa33D7WlSbHFb0iYJM7RPPhpY%2b5fkgFQo7CnknBPW9zOr7AoLTlAxJ%2fD5veYzjmaKMR5yaFAYvgBxMpJCeSlDMgiWMb7iNy5Ila7CvjG1A51eB5NAkhtodnajRsexMKyy5hG%2f3bU7efSJeDBQdehRkKIilZH5uNGivr5Ng%3d%3d&" );
            result.Append( "sign_type=RSA2&" );
            result.Append( "timestamp=2018-05-22+11%3a11%3a11&" );
            result.Append( "version=1.0" );
            return result.ToString();
        }

        /// <summary>
        /// 测试支付
        /// </summary>
        [Fact]
        public async Task TestPayAsync_2() {
            Time.SetTime( "2018-5-22 11:11:11" );
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