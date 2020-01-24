using System.ComponentModel;

namespace Util.Biz.Payments.Alipay.Enums {
    /// <summary>
    /// 支付宝交易撤消触发的操作
    /// </summary>
    public enum CancelAction {
        /// <summary>
        /// 交易未支付，触发关闭交易，无退款
        /// </summary>
        [Description( "交易未支付，触发关闭交易，无退款" )]
        Close,
        /// <summary>
        /// 交易已支付，触发交易退款
        /// </summary>
        [Description( "交易已支付，触发交易退款" )]
        Refund,
        /// <summary>
        /// 未查询到交易，或接口调用失败
        /// </summary>
        [Description( "未查询到交易，或接口调用失败" )]
        Other
    }
}