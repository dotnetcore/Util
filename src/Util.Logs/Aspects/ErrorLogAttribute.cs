using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using Util.Aspects.Base;
using Util.Logs.Extensions;

namespace Util.Logs.Aspects {
    /// <summary>
    /// 错误日志
    /// </summary>
    public class ErrorLogAttribute : InterceptorBase {
        /// <summary>
        /// 执行
        /// </summary>
        public override async Task Invoke( AspectContext context, AspectDelegate next ) {
            var methodName = GetMethodName( context );
            var log = Log.GetLog( methodName );
            try {
                await next( context );
            }
            catch ( Exception ex ) {
                log.Class( context.ServiceMethod.DeclaringType.FullName ).Method( methodName ).Exception( ex );
                foreach ( var parameter in context.GetParameters() )
                    parameter.AppendTo( log );
                log.Error();
                throw;
            }
        }

        /// <summary>
        /// 获取方法名
        /// </summary>
        private string GetMethodName( AspectContext context ) {
            return $"{context.ServiceMethod.DeclaringType.FullName}.{context.ServiceMethod.Name}";
        }
    }
}
