using System.ComponentModel;

namespace Util.Biz.Payments.Core {
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PayWay {
        /// <summary>
        /// 支付宝当面付
        /// </summary>
        [Description( "支付宝当面付" )]
        AlipayF2FPay,
        /// <summary>
        /// 支付宝App支付
        /// </summary>
        [Description( "支付宝App支付" )]
        AlipayAppPay,
        /// <summary>
        /// 支付宝手机网站支付
        /// </summary>
        [Description( "支付宝手机网站支付" )]
        AlipayWapPay,
        /// <summary>
        /// 支付宝电脑网站支付
        /// </summary>
        [Description( "支付宝电脑网站支付" )]
        AlipayPagePay,
    }
}
