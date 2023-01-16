namespace Util.Validation.Validators {
    /// <summary>
    /// 验证模式
    /// </summary>
    public static class ValidatePattern {
        /// <summary>
        /// 手机号验证正则表达式
        /// </summary>
        public static string MobilePhonePattern = "^1[0-9]{10}$";
        /// <summary>
        /// 身份证验证正则表达式
        /// </summary>
        public static string IdCardPattern = @"(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)";
    }
}
