namespace Util.Security.Identity.Options {
    /// <summary>
    /// 登录配置
    /// </summary>
    public class SignInOptions {
        /// <summary>
        /// 必须确认电子邮件才能登录
        /// </summary>
        public bool ConfirmedEmail { get; set; }
        /// <summary>
        /// 必须确认手机号才能登录
        /// </summary>
        public bool ConfirmedPhoneNumber { get; set; }
    }
}
