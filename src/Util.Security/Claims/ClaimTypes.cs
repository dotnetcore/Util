using IdentityModel;

namespace Util.Security.Claims {
    /// <summary>
    /// 声明类型
    /// </summary>
    public static class ClaimTypes {
        /// <summary>
        /// 电子邮件
        /// </summary>
        public static string UserId { get; set; } = JwtClaimTypes.Subject;

        /// <summary>
        /// 电子邮件
        /// </summary>
        public static string Email { get; set; } = JwtClaimTypes.Email;

        /// <summary>
        /// 手机号
        /// </summary>
        public static string Mobile { get; set; } = JwtClaimTypes.PhoneNumber;

        /// <summary>
        /// 姓名
        /// </summary>
        public static string FullName { get; set; } = JwtClaimTypes.FamilyName;

        /// <summary>
        /// 应用程序标识
        /// </summary>
        public static string ApplicationId { get; set; } = "application_id";

        /// <summary>
        /// 应用程序编码
        /// </summary>
        public static string ApplicationCode { get; set; } = "application_code";

        /// <summary>
        /// 应用程序名称
        /// </summary>
        public static string ApplicationName { get; set; } = "application_name";

        /// <summary>
        /// 租户标识
        /// </summary>
        public static string TenantId { get; set; } = "tenant_id";

        /// <summary>
        /// 租户编码
        /// </summary>
        public static string TenantCode { get; set; } = "tenant_code";

        /// <summary>
        /// 租户名称
        /// </summary>
        public static string TenantName { get; set; } = "tenant_name";

        /// <summary>
        /// 角色标识列表
        /// </summary>
        public static string RoleIds { get; set; } = JwtClaimTypes.Role;

        /// <summary>
        /// 角色名
        /// </summary>
        public static string RoleName { get; set; } = "role_name";
    }
}