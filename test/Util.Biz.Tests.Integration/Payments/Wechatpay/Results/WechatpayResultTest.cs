using Util.Biz.Payments.Wechatpay.Configs;
using Util.Biz.Payments.Wechatpay.Enums;
using Util.Biz.Payments.Wechatpay.Results;
using Xunit;

namespace Util.Biz.Tests.Integration.Payments.Wechatpay.Results {
    /// <summary>
    /// 微信支付结果测试
    /// </summary>
    public class WechatpayResultTest {
        /// <summary>
        /// 测试
        /// </summary>
        [Fact]
        public void Test_1() {
            //设置返回响应
            var response = @"<xml>
                                <return_code><![CDATA[SUCCESS]]></return_code>
                                <return_msg><![CDATA[OK]]></return_msg>
                                <appid><![CDATA[wx9b90e1788b39fec6]]></appid>
                                <mch_id><![CDATA[1985518532]]></mch_id>
                                <nonce_str><![CDATA[wrKodsjUFk34qYno]]></nonce_str>
                                <sign><![CDATA[5F721ADF22DD2C60B4E171228F8DA36E]]></sign>
                                <result_code><![CDATA[SUCCESS]]></result_code>
                                <prepay_id><![CDATA[wx141217433636466fe2c3b2a10139084028]]></prepay_id>
                                <trade_type><![CDATA[APP]]></trade_type>
                            </xml>";

            //操作
            var config = new WechatpayConfig {
                SignType = WechatpaySignType.Md5,
                PrivateKey = "VVHZOaJEj44WbX0f3Lj7DHkfwEqvlURA",
            };
            var result = new WechatpayResult( config, response );

            //验证
            Assert.Equal( "SUCCESS", result.GetReturnCode() );
            Assert.Equal( "OK", result.GetReturnMessage() );
            Assert.Equal( "wx9b90e1788b39fec6", result.GetAppId() );
            Assert.Equal( "1985518532", result.GetMerchantId() );
            Assert.Equal( "wrKodsjUFk34qYno", result.GetNonce() );
            Assert.Equal( "5F721ADF22DD2C60B4E171228F8DA36E", result.GetSign() );
            Assert.Equal( "SUCCESS", result.GetResultCode() );
            Assert.Equal( "wx141217433636466fe2c3b2a10139084028", result.GetPrepayId() );
            Assert.Equal( "APP", result.GetTradeType() );
            Assert.True( result.Success );
        }
    }
}
