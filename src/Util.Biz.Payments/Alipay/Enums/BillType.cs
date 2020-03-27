using System.ComponentModel;

namespace Util.Biz.Payments.Alipay.Enums {
    /// <summary>
    /// 支付宝账单类型
    /// </summary>
    public enum BillType {
        /// <summary>
        /// 商户基于支付宝交易收单的业务账单
        /// </summary>
        [Description( "trade" )]
        Trade,
        /// <summary>
        /// 基于商户支付宝余额收入及支出等资金变动的帐务账单
        /// </summary>
        [Description( "signcustomer" )]
        SignCustomer
    }
}
