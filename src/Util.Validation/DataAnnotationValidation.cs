using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Util.Validation {
    /// <summary>
    /// 数据注解验证操作
    /// </summary>
    public static class DataAnnotationValidation {
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="target">验证目标</param>
        public static ValidationResultCollection Validate( object target ) {
            if( target == null )
                throw new ArgumentNullException( nameof( target ) );
            var result = new ValidationResultCollection();
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext( target, null, null );
            var isValid = Validator.TryValidateObject( target, context, validationResults, true );
            if ( !isValid )
                result.AddList( validationResults );
            return result;
        }
    }
}
