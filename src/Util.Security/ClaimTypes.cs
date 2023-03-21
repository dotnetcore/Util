namespace Util.Security {
    /// <summary>
    /// 声明类型
    /// </summary>
    public static class ClaimTypes {
        /// <summary>
        /// sub,用户标识
        /// </summary>
        public static string UserId { get; set; } = "sub";
        /// <summary>
        /// name,姓名
        /// </summary>
        public static string Name { get; set; } = "name";
        /// <summary>
        /// email,电子邮件
        /// </summary>
        public static string Email { get; set; } = "email";
        /// <summary>
        /// phone_number,手机号
        /// </summary>
        public static string PhoneNumber { get; set; } = "phone_number";
        /// <summary>
        /// application_id,应用程序标识
        /// </summary>
        public static string ApplicationId { get; set; } = "application_id";
        /// <summary>
        /// application_code,应用程序编码
        /// </summary>
        public static string ApplicationCode { get; set; } = "application_code";
        /// <summary>
        /// application_name,应用程序名称
        /// </summary>
        public static string ApplicationName { get; set; } = "application_name";
        /// <summary>
        /// tenant_id,租户标识
        /// </summary>
        public static string TenantId { get; set; } = "tenant_id";
        /// <summary>
        /// tenant_code,租户编码
        /// </summary>
        public static string TenantCode { get; set; } = "tenant_code";
        /// <summary>
        /// tenant_name,租户名称
        /// </summary>
        public static string TenantName { get; set; } = "tenant_name";
        /// <summary>
        /// role,角色
        /// </summary>
        public static string Role { get; set; } = "role";
    }
}