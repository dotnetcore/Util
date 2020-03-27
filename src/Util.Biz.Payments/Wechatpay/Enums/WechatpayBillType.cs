using System.ComponentModel;

namespace Util.Biz.Payments.Wechatpay.Enums {
    /// <summary>
    /// 微信支付账单类型
    /// </summary>
    public enum WechatpayBillType {
        /// <summary>
        /// 所有订单,不含充值退款订单
        /// </summary>
        [Description( "ALL" )]
        All,
        /// <summary>
        /// 成功支付订单,不含充值退款订单
        /// </summary>
        [Description( "SUCCESS" )]
        Success,
        /// <summary>
        /// 退款订单,不含充值退款订单
        /// </summary>
        [Description( "REFUND" )]
        Refund,
        /// <summary>
        /// 充值退款订单
        /// </summary>
        [Description( "RECHARGE_REFUND" )]
        RechargeRefund
    }
}
