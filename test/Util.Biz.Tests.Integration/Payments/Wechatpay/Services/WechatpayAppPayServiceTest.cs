using System;
using System.Threading.Tasks;
using Util.Biz.Payments.Core;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Services;
using Util.Biz.Tests.Integration.Payments.Wechatpay.Configs;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Biz.Tests.Integration.Payments.Wechatpay.Services {
    /// <summary>
    /// 微信App支付服务测试
    /// </summary>
    public class WechatpayAppPayServiceTest : IDisposable {
        /// <summary>
        /// 控制台输出
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 微信App支付服务
        /// </summary>
        private WechatpayAppPayService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public WechatpayAppPayServiceTest( ITestOutputHelper output ) {
            _output = output;
            _service = new WechatpayAppPayService( new TestConfigProvider() );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Id.Reset();
            Web.ResetIp();
        }

        /// <summary>
        /// 测试支付
        /// </summary>
        [Fact]
        public async Task TestPayAsync_1() {
            //设置
            Id.SetId( "nonce" );
            Web.SetIp( "ip" );
            _service = new WechatpayAppPayService( new WechatpayConfigProvider(new WechatpayConfig {
                AppId = "a",
                MerchantId = "m",
                PrivateKey = "p",
                NotifyUrl = "n"
            }) );

            //结果
            String expected = new String();
            expected.Append( "<xml>" );
            expected.Append( "<appid><![CDATA[a]]></appid>" );
            expected.Append( "<body><![CDATA[b]]></body>" );
            expected.Append( "<mch_id><![CDATA[m]]></mch_id>" );
            expected.Append( "<nonce_str><![CDATA[nonce]]></nonce_str>" );
            expected.Append( "<notify_url><![CDATA[n]]></notify_url>" );
            expected.Append( "<out_trade_no><![CDATA[o]]></out_trade_no>" );
            expected.Append( "<sign><![CDATA[1EA6032990E252DF1E0301E20B93950A]]></sign>" );
            expected.Append( "<sign_type><![CDATA[MD5]]></sign_type>" );
            expected.Append( "<spbill_create_ip><![CDATA[ip]]></spbill_create_ip>" );
            expected.Append( "<total_fee>1023</total_fee>" );
            expected.Append( "<trade_type><![CDATA[APP]]></trade_type>" );
            expected.Append( "</xml>" );

            //执行
            _service.IsSend = false;
            var result = await _service.PayAsync( new PayParam {
                Subject = "b",
                Money = 10.23M,
                OrderId = "o"
            } );

            //输出
            _output.WriteLine( $"Parameter:{result.Parameter}" );

            //验证
            Assert.Equal( expected.ToString(),result.Parameter );
        }

        /// <summary>
        /// 测试支付
        /// </summary>
        [Fact(Skip = "请先配置微信支付")]
        public async Task TestPayAsync_2() {
            //执行
            var result = await _service.PayAsync( new PayParam {
                Subject = "b",
                Money = 10.23M,
                OrderId = Id.Guid()
            } );

            //输出
            _output.WriteLine( $"Parameter:{result.Parameter}" );
            _output.WriteLine( $"Raw:{result.Raw}" );
            _output.WriteLine( $"Result:{result.Result}" );

            //验证
            Assert.True( result.Success );
        }
    }
}
