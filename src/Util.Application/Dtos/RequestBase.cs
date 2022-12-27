using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Util.Exceptions;
using Util.Helpers;
using Util.Validation;

namespace Util.Applications.Dtos {
    /// <summary>
    /// 请求参数
    /// </summary>
    public abstract class RequestBase : IRequest {
        /// <summary>
        /// 验证
        /// </summary>
        public virtual ValidationResultCollection Validate() {
            var validator = Ioc.Create<IObjectModelValidator>();
            if ( validator == null ) {
                var result = DataAnnotationValidation.Validate( this );
                if ( result.IsValid )
                    return ValidationResultCollection.Success;
                throw new Warning( result.First().ErrorMessage );
            }
            var actionContext = new ActionContext();
            validator.Validate( actionContext, null, string.Empty, this );
            if ( actionContext.ModelState.IsValid )
                return ValidationResultCollection.Success;
            throw new Warning( actionContext.ModelState.Values.First().Errors.First().ErrorMessage );
        }
    }
}
