namespace Util.Biz.Payments.Wechatpay.Results {
    /// <summary>
    /// 微信对账单信息
    /// </summary>
    public class WechatpayBillInfo {
        /// <summary>
        /// 交易时间
        /// </summary>
        public string TransactionTime { get; set; }
        /// <summary>
        /// 公众账号ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string MerchantId { get; set; }
        /// <summary>
        /// 子商户号/特约商户号
        /// </summary>
        public string SubMerchantId { get; set; }
        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceNumber { get; set; }
        /// <summary>
        /// 微信订单号
        /// </summary>
        public string TradeId { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 用户标识
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; set; }
        /// <summary>
        /// 交易状态
        /// </summary>
        public string TradeStatus { get; set; }
        /// <summary>
        /// 付款银行
        /// </summary>
        public string Bank { get; set; }
        /// <summary>
        /// 货币种类
        /// </summary>
        public string CurrencyType { get; set; }
        /// <summary>
        /// 总金额/应结订单金额（元）
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 代金券或立减优惠金额（元）
        /// </summary>
        public decimal CouponAmount { get; set; }
        /// <summary>
        /// 退款申请时间
        /// </summary>
        public string RefundApplyTime { get; set; }
        /// <summary>
        /// 退款成功时间
        /// </summary>
        public string RefundTime { get; set; }
        /// <summary>
        /// 微信退款单号
        /// </summary>
        public string WechatpayRefundId { get; set; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string MerchantRefundId { get; set; }
        /// <summary>
        /// 退款金额（元）
        /// </summary>
        public decimal RefundAmount { get; set; }
        /// <summary>
        /// 代金券或立减优惠退款金额/充值券退款金额（元）
        /// </summary>
        public decimal CouponRefundAmount { get; set; }
        /// <summary>
        /// 退款类型
        /// </summary>
        public string RefundType { get; set; }
        /// <summary>
        /// 退款状态
        /// </summary>
        public string RefundStatus { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string TradeName { get; set; }
        /// <summary>
        /// 商户数据包
        /// </summary>
        public string MerchantAttach { get; set; }
        /// <summary>
        /// 手续费（元）
        /// </summary>
        public decimal Commission { get; set; }
        /// <summary>
        /// 费率
        /// </summary>
        public string Rate { get; set; }
        /// <summary>
        /// 订单金额（元）
        /// </summary>
        public decimal OrderAmount { get; set; }
        /// <summary>
        /// 申请退款金额（元）
        /// </summary>
        public decimal ApplyRefundAmount { get; set; }
        /// <summary>
        /// 费率备注
        /// </summary>
        public string RateRemark { get; set; }
    }
}
