using System.ComponentModel.DataAnnotations;

namespace Util.Validation {
    /// <summary>
    /// 验证规则
    /// </summary>
    public interface IValidationRule {
        /// <summary>
        /// 验证
        /// </summary>
        ValidationResult Validate();
    }
}
