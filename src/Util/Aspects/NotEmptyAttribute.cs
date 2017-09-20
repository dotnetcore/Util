using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;

namespace Util.Aspects {
    /// <summary>
    /// 验证不能为空
    /// </summary>
    [AttributeUsage( AttributeTargets.Parameter )]
    public class NotEmptyAttribute : ParameterInterceptorAttribute {
        /// <summary>
        /// 执行
        /// </summary>
        public override Task Invoke( ParameterAspectContext context, ParameterAspectDelegate next ) {
            if( string.IsNullOrWhiteSpace( context.Parameter.Value.SafeString() ) )
                throw new ArgumentNullException( context.Parameter.Name );
            return next( context );
        }
    }
}
