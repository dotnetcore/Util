namespace Util.Security.Identity.Results {
    /// <summary>
    /// 登录结果
    /// </summary>
    public class SignInResult {
        /// <summary>
        /// 初始化
        /// </summary>
        public SignInResult() {
            State = SignInState.Failed;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="state">登录状态</param>
        /// <param name="userId">用户标识</param>
        public SignInResult( SignInState state, string userId ) {
            State = state;
            UserId = userId;
        }

        /// <summary>
        /// 登录状态
        /// </summary>
        public SignInState State { get; set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        public string UserId { get; set; }
    }
}
