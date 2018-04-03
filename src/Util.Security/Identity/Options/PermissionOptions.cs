namespace Util.Security.Identity.Options {
    /// <summary>
    /// 权限配置
    /// </summary>
    public class PermissionOptions {
        /// <summary>
        /// 密码配置
        /// </summary>
        public PasswordOptions Password { get; set; } = new PasswordOptions();
        /// <summary>
        /// 用户配置
        /// </summary>
        public UserOptions User { get; set; } = new UserOptions();
        /// <summary>
        /// 存储配置
        /// </summary>
        public StoreOptions Store { get; set; } = new StoreOptions();
        /// <summary>
        /// 登录配置
        /// </summary>
        public SignInOptions SignIn { get; set; } = new SignInOptions();
        /// <summary>
        /// 登录锁定配置
        /// </summary>
        public LockoutOptions Lockout { get; set; } = new LockoutOptions();
    }
}
