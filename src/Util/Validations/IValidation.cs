namespace Util.Validations {
    /// <summary>
    /// 验证操作
    /// </summary>
    public interface IValidation {
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="target">验证目标</param>
        ValidationResultCollection Validate( object target );
    }
}
