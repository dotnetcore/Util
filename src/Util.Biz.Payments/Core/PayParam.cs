namespace Util.Biz.Payments.Core {
    /// <summary>
    /// 支付参数
    /// </summary>
    public class PayParam : PayParamBase {
        /// <summary>
        /// 支付订单付款超时时间，单位：分钟，默认为90分钟
        /// </summary>
        public int Timeout { get; set; } = 90;
        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 用户付款授权码
        /// </summary>
        public string AuthCode { get; set; }
    }
}