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
    }
}
