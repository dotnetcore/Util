namespace Util.Validation {
    /// <summary>
    /// 验证处理器
    /// </summary>
    public interface IValidationHandler {
        /// <summary>
        /// 处理验证错误
        /// </summary>
        /// <param name="results">验证结果集合</param>
        void Handle( ValidationResultCollection results );
    }
}
