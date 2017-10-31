namespace Util.Tools.Sms {
    /// <summary>
    /// 短信接口返回结果
    /// </summary>
    public class SmsResult {
        /// <summary>
        /// 初始化短信接口返回结果
        /// </summary>
        /// <param name="success">是否发送成功</param>
        /// <param name="raw">短信提供商返回的原始消息</param>
        /// <param name="errorCode">短信错误码</param>
        public SmsResult( bool success = true, string raw = "", SmsErrorCode errorCode = SmsErrorCode.Ok ) {
            Success = success;
            Raw = raw;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// 是否发送成功
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// 短信错误码
        /// </summary>
        public SmsErrorCode ErrorCode { get; }

        /// <summary>
        /// 短信提供商返回的原始消息
        /// </summary>
        public string Raw { get; }

        /// <summary>
        /// 成功消息
        /// </summary>
        public static SmsResult Ok { get; } = new SmsResult();
    }
}
