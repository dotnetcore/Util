namespace Util.Security.Identity.Results {
    /// <summary>
    /// 登录结果
    /// </summary>
    public enum SignInResult {
        /// <summary>
        /// 登录成功
        /// </summary>
        Succeeded,
        /// <summary>
        /// 需要两阶段认证
        /// </summary>
        TwoFactor
    }
}
