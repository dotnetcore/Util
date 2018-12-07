using System.ComponentModel;

namespace Util.Biz.Payments.Wechatpay.Enums {
    /// <summary>
    /// 微信支付签名类型
    /// </summary>
    public enum WechatpaySignType {
        /// <summary>
        /// Md5
        /// </summary>
        [Description( "MD5" )]
        Md5,
        /// <summary>
        /// HMAC-SHA256
        /// </summary>
        [Description( "HMAC-SHA256" )]
        HmacSha256
    }
}
