namespace Util.Validation {
    /// <summary>
    /// 验证失败，不做任何处理
    /// </summary>
    public class NothingHandler : IValidationHandler {
        /// <summary>
        /// 处理验证错误
        /// </summary>
        /// <param name="results">验证结果集合</param>
        public void Handle( ValidationResultCollection results ) {
        }
    }
}
