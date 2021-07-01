using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;

namespace Util.Aop {
    /// <summary>
    /// 验证参数不能为null
    /// </summary>
    public class NotNullAttribute : ParameterInterceptorBase {
        /// <summary>
        /// 执行
        /// </summary>
        public override Task Invoke( ParameterAspectContext context, ParameterAspectDelegate next ) {
            if( context.Parameter.Value == null )
                throw new ArgumentNullException( context.Parameter.Name );
            return next( context );
        }
    }
}
