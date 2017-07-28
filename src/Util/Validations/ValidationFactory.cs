namespace Util.Validations {
    /// <summary>
    /// 验证工厂
    /// </summary>
    public static class ValidationFactory {
        /// <summary>
        /// 创建验证操作
        /// </summary>
        public static IValidation Create() {
            return new Validation();
        }
    }
}
