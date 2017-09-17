using Util.Validations;

namespace Util.Domains {
    /// <summary>
    /// 领域对象
    /// </summary>
    public interface IDomainObject {
        /// <summary>
        /// 验证
        /// </summary>
        ValidationResultCollection Validate();
    }
}
