namespace Util.Biz.Payments.Alipay.Parameters.Requests {
    /// <summary>
    /// 条码支付参数
    /// </summary>
    public class AlipayBarcodePayRequest : AlipayRequestBase {
        /// <summary>
        /// 用户付款授权码
        /// </summary>
        public string AuthCode { get; set; }
    }
}