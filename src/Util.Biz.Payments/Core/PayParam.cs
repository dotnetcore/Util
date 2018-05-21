namespace Util.Biz.Payments.Core {
    /// <summary>
    /// 支付参数
    /// </summary>
    public class PayParam : PayParamBase {
        /// <summary>
        /// 用户付款授权码
        /// </summary>
        public string AuthCode { get; set; }
    }
}