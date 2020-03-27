namespace Util.Biz.Payments.Alipay.Results {
    /// <summary>
    /// 支付宝对账单信息
    /// </summary>
    public class AlipayBillInfo {
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string TradeId { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public string BusinessType { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string TradeName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreationTime { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public string CompletionTime { get; set; }
        /// <summary>
        /// 门店编号
        /// </summary>
        public string ShopNumber { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 终端号
        /// </summary>
        public string Terminal { get; set; }
        /// <summary>
        /// 对方账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 订单金额（元）
        /// </summary>
        public decimal OrderAmount { get; set; }
        /// <summary>
        /// 商家实收（元）
        /// </summary>
        public decimal MerchantReceipt { get; set; }
        /// <summary>
        /// 支付宝红包（元）
        /// </summary>
        public decimal AlipayRedEnvelopes { get; set; }
        /// <summary>
        /// 集分宝（元）
        /// </summary>
        public decimal JifenBao { get; set; }
        /// <summary>
        /// 支付宝优惠（元）
        /// </summary>
        public decimal AlipayDiscount { get; set; }
        /// <summary>
        /// 商家优惠（元）
        /// </summary>
        public decimal MerchantDiscount { get; set; }
        /// <summary>
        /// 券核销金额（元）
        /// </summary>
        public decimal CouponAmount { get; set; }
        /// <summary>
        /// 券名称
        /// </summary>
        public string CouponName { get; set; }
        /// <summary>
        /// 商家红包消费金额（元）
        /// </summary>
        public decimal MerchantRedEnvelopes { get; set; }
        /// <summary>
        /// 卡消费金额（元）
        /// </summary>
        public decimal CardAmount { get; set; }
        /// <summary>
        /// 退款批次号/请求号
        /// </summary>
        public string RefundNumber { get; set; }
        /// <summary>
        /// 服务费（元）
        /// </summary>
        public decimal ServiceCharge { get; set; }
        /// <summary>
        /// 分润（元）
        /// </summary>
        public decimal ShareProfit { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
