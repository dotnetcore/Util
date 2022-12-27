using System.ComponentModel.DataAnnotations;
using Util.Validation;

namespace Util.Domain.Tests.Samples {
    /// <summary>
    /// 验证规则样例 - 名称长度大于3将验证失败
    /// </summary>
    public class ValidationRuleSample : IValidationRule {
        /// <summary>
        /// 初始化名称长度验证规则
        /// </summary>
        /// <param name="sample">聚合根测试样例</param>
        public ValidationRuleSample( AggregateRootSample sample ) {
            _sample = sample;
        }

        /// <summary>
        /// 聚合根测试样例
        /// </summary>
        private readonly AggregateRootSample _sample;

        /// <summary>
        /// 验证
        /// </summary>
        public ValidationResult Validate() {
            if( _sample.Name.Length > 3 )
                return new ValidationResult( "名称长度不能大于3" );
            return ValidationResult.Success;
        }
    }
}
