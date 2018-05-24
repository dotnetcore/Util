using System.ComponentModel;

namespace Util.Biz.Payments.Alipay.Enums {
    /// <summary>
    /// 支付宝交易状态
    /// </summary>
    public enum TradeStatus {
        /// <summary>
        /// 交易创建，等待买家付款
        /// </summary>
        [Description( "交易创建，等待买家付款" )]
        WaitPay,
        /// <summary>
        /// 支付成功
        /// </summary>
        [Description( "支付成功" )]
        Success,
        /// <summary>
        /// 未付款交易超时关闭，或支付完成后全额退款
        /// </summary>
        [Description( "未付款交易超时关闭，或支付完成后全额退款" )]
        Close,
        /// <summary>
        /// 交易结束，不可退款
        /// </summary>
        [Description( "交易结束，不可退款" )]
        Finished
    }
}