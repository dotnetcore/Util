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
        AlipayBarcodePay
    }
}
