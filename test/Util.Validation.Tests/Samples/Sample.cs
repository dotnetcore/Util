using System;
using System.ComponentModel.DataAnnotations;

namespace Util.Validation.Tests.Samples {
    /// <summary>
    /// 验证样例
    /// </summary>
    public class Sample : IValidation{
        /// <summary>
        /// 验证必填项
        /// </summary>
        [Required( ErrorMessage = "Required" )]
        public string RequiredValue { get; set; }
        /// <summary>
        /// 验证字符串长度
        /// </summary>
        [StringLength(3, ErrorMessage = "StringLength" )]
        public string StringLengthValue { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        public ValidationResultCollection Validate() {
            var result = DataAnnotationValidation.Validate( this );
            if( result.IsValid )
                return ValidationResultCollection.Success;
            throw new ArgumentException();
        }
    }
}
