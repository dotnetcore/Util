namespace Util.Biz.Payments.Core {
    /// <summary>
    /// 支付结果
    /// </summary>
    public class PayResult {
        /// <summary>
        /// 初始化支付结果
        /// </summary>
        /// <param name="success">是否成功</param>
        /// <param name="result">结果</param>
        public PayResult( bool success, string result ) {
            Success = success;
            Result = result;
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// 结果,说明：
        /// 1. 支付宝手机网站支付，该结果为表单Html 
        /// 2. 支付宝当面付，该结果为二维码图片地址
        /// </summary>
        public string Result { get; }
    }
}
