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
        /// 支付宝电脑网站支付
        /// </summary>
        [Description( "支付宝电脑网站支付" )]
        AlipayPagePay,
        /// <summary>
        /// 支付宝手机网站支付
        /// </summary>
        [Description( "支付宝手机网站支付" )]
        AlipayWapPay
    }
}
