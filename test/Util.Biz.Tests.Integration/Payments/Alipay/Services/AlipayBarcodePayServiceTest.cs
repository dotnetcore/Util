using System;
using System.Threading.Tasks;
using Util.Biz.Payments;
using Util.Biz.Payments.Alipay.Parameters.Requests;
using Util.Biz.Payments.Alipay.Results;
using Util.Biz.Payments.Alipay.Services;
using Util.Biz.Payments.Core;
using Util.Biz.Payments.Properties;
using Util.Biz.Tests.Integration.Payments.Alipay.Configs;
using Util.Biz.Tests.Integration.XUnitHelpers;
using Util.Exceptions;
using Util.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Biz.Tests.Integration.Payments.Alipay.Services {
    /// <summary>
    /// 支付宝条码支付服务测试
    /// </summary>
    public class AlipayBarcodePayServiceTest : IDisposable {
        /// <summary>
        /// 控制台输出
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 支付宝条码支付服务
        /// </summary>
        private AlipayBarcodePayService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AlipayBarcodePayServiceTest( ITestOutputHelper output ) {
            _output = output;
            _service = new AlipayBarcodePayService( new TestConfigProvider() );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Time.Reset();
        }

        /// <summary>
        /// 验证订单标题为空时，将订单号赋值给订单标题
        /// </summary>
        [Fact]
        public async Task TestPay_Validate_Subject() {
            var param = new PayParam {
                Money = 1,
                OrderId = "a",
                AuthCode = "1"
            };
            _service.IsSend = false;
            await _service.PayAsync( param );
            Assert.Equal( "a", param.Subject );
        }

        /// <summary>
        /// 验证订单号为空
        /// </summary>
        [Fact]
        public async Task TestPay_Validate_OrderId() {
            await AssertHelper.ThrowsAsync<Warning>( async () => {
                await _service.PayAsync( new PayParam {
                    Money = 1,
                    AuthCode = "1",
                    Subject = "a"
                } );
            }, PayResource.OrderIdIsEmpty );
        }

        /// <summary>
        /// 验证无效金额
        /// </summary>
        [Fact]
        public async Task TestPay_Validate_Money() {
            await AssertHelper.ThrowsAsync<Warning>( async () => {
                await _service.PayAsync( new PayParam {
                    Money = 0,
                    OrderId = "a",
                    Subject = "a",
                    AuthCode = "1"
                } );
            }, PayResource.InvalidMoney );
        }

        /// <summary>
        /// 验证用户付款授权码为空
        /// </summary>
        [Fact]
        public async Task TestPay_Validate_AuthCode() {
            await AssertHelper.ThrowsAsync<Warning>( async () => {
                await _service.PayAsync( new PayParam {
                    Money = 10,
                    OrderId = "a",
                    Subject = "test"
                } );
            }, PayResource.AuthCodeIsEmpty );
        }

        /// <summary>
        /// 测试请求参数
        /// </summary>
        [Fact]
        public async Task TestRequestParam() {
            //结果
            Util.Helpers.String result = new Util.Helpers.String();
            result.Append( "app_id=2016090800463464&" );
            result.Append( "biz_content={\"out_trade_no\":\"59f7caeeab89e009e4a4e1fb\",\"subject\":\"test\",\"total_amount\":\"10\",\"timeout_express\":\"90m\",\"scene\":\"bar_code\",\"auth_code\":\"281023564031402341\"}&" );
            result.Append( "charset=utf-8&" );
            result.Append( "format=json&" );
            result.Append( "method=alipay.trade.pay&" );
            result.Append( "notify_url=b&" );
            result.Append( "return_url=a&" );
            result.Append( "sign=PBfEvMpDohq0jScUszg1y+MpxZwscH6YS3tUKaoc+1mYBFyCD8lmBCNPfBnlxndR2gvqpz8c650DoOn/qgnO7yE+8xYsAbwRoH4USpCkyU+tcPhVx/old0tuhzv/PbmhB7w7dqpFk/8JaclGP+zabotYCz5fTzMrfTl+/yEg6gcH7yw7PwcdU8Bykkb+eddtWVa33QpTtUNFblO5YWsJ1XfNodxrwWXVRzFLr8tL47pTOAn69gcnnfFRLttQxp6Kq9zCWUjKzAtHDCyEG4mSkFMh98Ma7KLhlKIbXU/4SKoslK02kTz1XJP8g831yEVNeRL6g2ZaAr9w92dh1KodVg==&" );
            result.Append( "sign_type=RSA2&" );
            result.Append( "timestamp=2000-10-10 10:10:10&" );
            result.Append( "version=1.0" );

            //操作
            var payResult = await PayAsync();

            //输出
            _output.WriteLine( payResult.Parameter );

            //验证
            Assert.Equal( result.ToString(), payResult.Parameter );
        }

        /// <summary>
        /// 支付
        /// </summary>
        private async Task<PayResult> PayAsync() {
            Time.SetTime( TestConst.Time );
            _service = new AlipayBarcodePayService( new TestConfigProvider() );
            var param = new PayParam {
                Money = 10,
                OrderId = "59f7caeeab89e009e4a4e1fb",
                Subject = "test",
                AuthCode = "281023564031402341",
                ReturnUrl = "a",
                NotifyUrl = "b"
            };
            _service.IsSend = false;
            return await _service.PayAsync( param );
        }

        /// <summary>
        /// 测试支付
        /// </summary>
        [Fact( Skip = "输入测试付款码" )]
        public async Task TestPayAsync_1() {
            var result = await _service.PayAsync( new PayParam {
                Money = 10,
                OrderId = Id.Guid(),
                AuthCode = "281702554710470240"
            } );
            _output.WriteLine( $"Message:{result.Message}" );
            _output.WriteLine( $"Raw:{result.Raw}" );
            Assert.True( result.Success );
        }

        /// <summary>
        /// 测试支付
        /// </summary>
        [Fact( Skip = "输入测试付款码" )]
        public async Task TestPayAsync_2() {
            var result = await _service.PayAsync( new AlipayBarcodePayRequest {
                Money = 10,
                OrderId = Id.Guid(),
                AuthCode = "281946634954494658"
            } );
            _output.WriteLine( result.Message );
            Assert.True( result.Success );
        }

        /// <summary>
        /// 测试Json结果
        /// </summary>
        [Fact]
        public void TestJsonResult() {
            const string json = "{\"alipay_trade_pay_response\":{\"code\":\"10000\",\"msg\":\"Success\",\"buyer_logon_id\":\"jeu*** @sandbox.com\",\"buyer_pay_amount\":\"10.00\",\"buyer_user_id\":\"2088102174804335\",\"fund_bill_list\":[{\"amount\":\"10.00\",\"fund_channel\":\"ALIPAYACCOUNT\"}],\"gmt_payment\":\"2017-10-31 13:23:12\",\"invoice_amount\":\"10.00\",\"open_id\":\"20881058260191225496241750118233\",\"out_trade_no\":\"06bfa9807832438dac6a2b785ad7addc\",\"point_amount\":\"0.00\",\"receipt_amount\":\"10.00\",\"total_amount\":\"10.00\",\"trade_no\":\"2017103121001004330200344580\"},\"sign\":\"CkMKbLdFmlhIz0Ymob7IjnGdjBDfAt5/aAZ7l0jMvwFJyBRf0TaRJiHfXTCI7srL68RQ5DnR6N89XSr1+MiclVbpbNa3joi4XDd1sdEkTKMcEmp28tvL9q3UAbMtwKgiS93CWjmj/D5xK7K+ZxwVPwF3JlkeCd2Qg5GAtHmNjAAt3tlEKVn+SmRQ0yKyk2PpvVSSBBYbFo+VircmOxHo/m/ji3sK68y0ikhQYhHRuNQXXTp3KellpIESaIUGHi8KdQa7lV2acnDnSDChWy/4PxIrEmm8Ki8PMKsqS8WiIwKiUTldeWGZ0D749oP4iq6n18iDtjmSDeEgOTkhErVKLg==\"}";
            var result = new AlipayResult( json );
            Assert.Equal( "10000", result.GetCode() );
            Assert.Equal( "2017103121001004330200344580", result.GetTradeNo() );
            Assert.True( result.HasKey( "sign" ) );
        }
    }
}
