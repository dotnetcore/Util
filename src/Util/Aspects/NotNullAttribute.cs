using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Util.Aspects.Base;

namespace Util.Aspects {
    /// <summary>
    /// 验证不能为null
    /// </summary>
    [AttributeUsage( AttributeTargets.Parameter )]
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
