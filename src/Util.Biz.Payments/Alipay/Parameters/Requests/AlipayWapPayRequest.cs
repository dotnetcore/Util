namespace Util.Biz.Payments.Alipay.Parameters.Requests {
    /// <summary>
    /// 手机网站支付参数
    /// </summary>
    public class AlipayWapPayRequest : AlipayRequestBase {
        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
