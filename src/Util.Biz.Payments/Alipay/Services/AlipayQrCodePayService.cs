using System.Threading.Tasks;
using Util.Biz.Payments.Alipay.Abstractions;
using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Alipay.Parameters;
using Util.Biz.Payments.Alipay.Parameters.Requests;
using Util.Biz.Payments.Alipay.Results;
using Util.Biz.Payments.Alipay.Services.Base;
using Util.Biz.Payments.Core;

namespace Util.Biz.Payments.Alipay.Services {
    /// <summary>
    /// 支付宝二维码支付服务
    /// </summary>
    public class AlipayQrCodePayService : AlipayServiceBase, IAlipayQrCodePayService {
        /// <summary>
        /// 初始化支付宝二维码支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        public AlipayQrCodePayService( IAlipayConfigProvider provider ) : base( provider ) {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">条码支付参数</param>
        public async Task<string> PayAsync( AlipayPrecreateRequest request ) {
            var result = await PayAsync( request.ToParam() );
            return result.Result;
        }

        /// <summary>
        /// 获取请求方法
        /// </summary>
        protected override string GetMethod() {
            return "alipay.trade.precreate";
        }

        /// <summary>
        /// 获取支付方式
        /// </summary>
        protected override PayWay GetPayWay() {
            return PayWay.AlipayQrCodePay;
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        protected override PayResult CreateResult( AlipayParameterBuilder builder, AlipayResult result ) {
            return new PayResult( result.Success, result.GetTradeNo(), result.Raw ) {
                Parameter = builder.ToString(),
                Message = result.GetMessage(),
                Result = result.GetValue( AlipayConst.QrCode )
            };
        }
    }
}