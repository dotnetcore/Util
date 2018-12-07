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
            Time.SetTime( TestConst.Time );
            var result = await _service.PayAsync( new PayParam {
                Money = 10,
                OrderId = "59f7caeeab89e009e4a4e1fb",
                Subject = "test",
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
            result.Append( "sign=mOSS0X%2bSCJwF8lTRyFjkb0539vPBdZljlvA2oOIAX7THS5RdLYGVPRA5y3vs%2froCalG8%2fJpGWgCbzYGMIRySWnwdLnNBY%2fXXS1x%2fM0hfRheOECxe%2bCppjhCHHbSp6Deavval7nsMSQ27HJSLtD5MbjXk6U49Pja4TyIWheXN6nF4Rv8T0fsuCAtxvcV%2fWxQMjAochsLO9YSj610aA%2f72qnHCqOOnV4zLT6xCR3LxcK6j4oJ%2f0SKITd5hvBuH29mLpoLUSl2QQ8XcabRCxxoZG5dbsAmvqxq3VFEk%2fU9Yc%2fCE%2bDpyBsDLF0d9Hi3I17EsLC5BIPxLLNKeJtcJL5DYoA%3d%3d&" );
            result.Append( "sign_type=RSA2&" );
            result.Append( "timestamp=2000-10-10+10%3a10%3a10&" );
            result.Append( "version=1.0" );
            return result.ToString();
        }

        /// <summary>
        /// 测试支付
        /// </summary>
        [Fact]
        public async Task TestPayAsync_2() {
            _output.WriteLine( $"result:{await PayAsync()}" );
            Assert.Equal( GetResult(), await PayAsync() );
        }

        /// <summary>
        /// 支付
        /// </summary>
        private async Task<string> PayAsync() {
            Time.SetTime( TestConst.Time );
            return await _service.PayAsync( new AlipayAppPayRequest() {
                Money = 10,
                OrderId = "59f7caeeab89e009e4a4e1fb",
                Subject = "test",
                NotifyUrl = "b"
            } );
        }
    }
}