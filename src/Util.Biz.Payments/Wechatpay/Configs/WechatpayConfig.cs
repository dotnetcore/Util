using System.ComponentModel.DataAnnotations;
using System.Linq;
using Util.Biz.Payments.Wechatpay.Enums;
using Util.Exceptions;
using Util.Helpers;
using Util.Validations;

namespace Util.Biz.Payments.Wechatpay.Configs {
    /// <summary>
    /// 微信支付配置
    /// </summary>
    public class WechatpayConfig {
        /// <summary>
        /// 支付网关地址,默认为正式地址： https://api.mch.weixin.qq.com
        /// </summary>
        [Required( ErrorMessage = "支付网关地址[GatewayUrl]不能为空" )]
        public string GatewayUrl { get; set; } = "https://api.mch.weixin.qq.com";

        /// <summary>
        /// 应用标识
        /// </summary>
        [Required( ErrorMessage = "应用标识[AppId]不能为空" )]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [Required( ErrorMessage = "商户号[MerchantId]不能为空" )]
        public string MerchantId { get; set; }

        /// <summary>
        /// 应用私钥
        /// </summary>
        [Required( ErrorMessage = "应用私钥[PrivateKey]不能为空" )]
        public string PrivateKey { get; set; }

        /// <summary>
        /// 签名类型，默认Md5
        /// </summary>
        public WechatpaySignType SignType { get; set; } = WechatpaySignType.Md5;

        /// <summary>
        /// 回调通知地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 证书绝对路径
        /// </summary>
        public string Certificate { get; set; }

        /// <summary>
        /// 证书密码
        /// </summary>
        public string CertificatePassword { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        public void Validate() {
            var result = DataAnnotationValidation.Validate( this );
            if( result.IsValid == false )
                throw new Warning( result.First().ErrorMessage );
        }

        /// <summary>
        /// 获取统一下单地址
        /// </summary>
        public string GetOrderUrl() {
            return Url.Combine( GatewayUrl, "pay/unifiedorder" );
        }

        /// <summary>
        /// 获取关闭订单地址
        /// </summary>
        public string GetCloseOrderUrl() {
            return Url.Combine( GatewayUrl, "pay/closeorder" );
        }

        /// <summary>
        /// 获取退款地址
        /// </summary>
        public string GetRefundUrl() {
            return Url.Combine( GatewayUrl, "secapi/pay/refund" );
        }

        /// <summary>
        /// 获取下载对账单地址
        /// </summary>
        public string GetDownloadBillUrl() {
            return Url.Combine( GatewayUrl, "pay/downloadbill" );
        }
    }
}
