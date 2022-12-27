using System.Linq;
using Util.Exceptions;

namespace Util.Validation {
    /// <summary>
    /// 验证失败，抛出异常
    /// </summary>
    public class ThrowHandler : IValidationHandler{
        /// <summary>
        /// 处理验证错误
        /// </summary>
        /// <param name="results">验证结果集合</param>
        public void Handle( ValidationResultCollection results ) {
            if ( results.IsValid )
                return;
            throw new Warning( results.First().ErrorMessage );
        }
    }
}
