using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using Util.Logs.Extensions;

namespace Util.Logs.Aspects {
    /// <summary>
    /// 错误日志
    /// </summary>
    public class ErrorLogAttribute : InterceptorAttribute {
        /// <summary>
        /// 执行
        /// </summary>
        public override async Task Invoke( AspectContext context, AspectDelegate next ) {
            var methodName = GetMethodName( context );
            var manager = (ILogManager)context.ServiceProvider.GetService( typeof( ILogManager ) );
            var log = manager.GetLog( methodName );
            try {
                await next( context );
            }
            catch ( Exception ex ) {
                log.Method( methodName ).Exception( ex );
                foreach( var parameter in context.GetParameters() )
                    log.Params( parameter.ParameterInfo.ParameterType.FullName, parameter.Name, parameter.Value.SafeString() );
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
