namespace Util.Security.Principals {
    /// <summary>
    /// 声明类型
    /// </summary>
    public static class ClaimTypes {
        /// <summary>
        /// 用户标识
        /// </summary>
        public static string UserId { get; set; } = System.Security.Claims.ClaimTypes.NameIdentifier;

        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserName { get; set; } = System.Security.Claims.ClaimTypes.Name;

        /// <summary>
        /// 姓名
        /// </summary>
        public static string FullName { get; set; } = "http://www.utilframework.com/identity/claims/fullname";

        /// <summary>
        /// 电子邮件
        /// </summary>
        public static string Email { get; set; } = System.Security.Claims.ClaimTypes.Email;

        /// <summary>
        /// 手机号
        /// </summary>
        public static string Mobile { get; set; } = System.Security.Claims.ClaimTypes.MobilePhone;

        /// <summary>
        /// 应用程序标识
        /// </summary>
        public static string ApplicationId { get; set; } = "http://www.utilframework.com/identity/claims/applicationid";

        /// <summary>
        /// 应用程序编码
        /// </summary>
        public static string ApplicationCode { get; set; } = "http://www.utilframework.com/identity/claims/applicationcode";

        /// <summary>
        /// 应用程序名称
        /// </summary>
        public static string ApplicationName { get; set; } = "http://www.utilframework.com/identity/claims/applicationname";

        /// <summary>
        /// 租户标识
        /// </summary>
        public static string TenantId { get; set; } = "http://www.utilframework.com/identity/claims/tenantid";

        /// <summary>
        /// 租户编码
        /// </summary>
        public static string TenantCode { get; set; } = "http://www.utilframework.com/identity/claims/tenantcode";

        /// <summary>
        /// 租户名称
        /// </summary>
        public static string TenantName { get; set; } = "http://www.utilframework.com/identity/claims/tenantname";

        /// <summary>
        /// 角色标识列表
        /// </summary>
        public static string RoleIds { get; set; } = "http://www.utilframework.com/identity/claims/roleids";

        /// <summary>
        /// 角色名
        /// </summary>
        public static string RoleName { get; set; } = "http://www.utilframework.com/identity/claims/rolename";
    }
}