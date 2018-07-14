namespace Util.Biz.Payments.Alipay.Parameters.Requests {
    /// <summary>
    /// 电脑网站支付参数
    /// </summary>
    public class AlipayPagePayRequest : AlipayRequestBase {
        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
