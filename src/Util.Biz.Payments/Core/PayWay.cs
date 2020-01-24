using System.ComponentModel;

namespace Util.Biz.Payments.Core {
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PayWay {
        /// <summary>
        /// 支付宝条码支付
        /// </summary>
        [Description( "支付宝条码支付" )]
        AlipayBarcodePay,
        /// <summary>
        /// 支付宝二维码支付
        /// </summary>
        [Description( "支付宝二维码支付" )]
        AlipayQrCodePay,
        /// <summary>
        /// 支付宝电脑网站支付
        /// </summary>
        [Description( "支付宝电脑网站支付" )]
        AlipayPagePay,
        /// <summary>
        /// 支付宝手机网站支付
        /// </summary>
        [Description( "支付宝手机网站支付" )]
        AlipayWapPay,
        /// <summary>
        /// 支付宝App支付
        /// </summary>
        [Description( "支付宝App支付" )]
        AlipayAppPay,
        /// <summary>
        /// 微信App支付
        /// </summary>
        [Description( "微信App支付" )]
        WechatpayAppPay,
        /// <summary>
        /// 微信小程序支付
        /// </summary>
        [Description( "微信小程序支付" )]
        WechatpayMiniProgramPay,
        /// <summary>
        /// 微信JsApi支付
        /// </summary>
        [Description( "微信JsApi支付" )]
        WechatpayJsApiPay,
        /// <summary>
        /// 微信扫码支付
        /// </summary>
        [Description( "微信扫码支付" )]
        WechatpayNativePay
    }
}
