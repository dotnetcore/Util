using System;
using Util.Exceptions;
using Util.Properties;

namespace Util.Applications {
    /// <summary>
    /// 异常扩展
    /// </summary>
    public static class ExceptionExtensions {
        /// <summary>
        /// 获取原始异常
        /// </summary>
        /// <param name="exception">异常</param>
        public static Exception GetRawException( this Exception exception ) {
            if( exception == null )
                return null;
            if( exception is AspectCore.DynamicProxy.AspectInvocationException aspectInvocationException ) {
                if( aspectInvocationException.InnerException == null )
                    return aspectInvocationException;
                return GetRawException( aspectInvocationException.InnerException );
            }
            return exception;
        }

        /// <summary>
        /// 获取异常提示
        /// </summary>
        /// <param name="exception">异常</param>
        /// <param name="isProduction">是否生产环境</param>
        public static string GetPrompt( this Exception exception, bool isProduction = false ) {
            if( exception == null )
                return null;
            exception = exception.GetRawException();
            if( exception == null )
                return null;
            if( exception is Warning warning )
                return warning.GetMessage( isProduction );
            return isProduction ? R.SystemError : exception.Message;
        }

        /// <summary>
        /// 获取Http状态码
        /// </summary>
        /// <param name="exception">异常</param>
        public static int? GetHttpStatusCode( this Exception exception ) {
            if ( exception == null )
                return null;
            exception = exception.GetRawException();
            if ( exception == null )
                return null;
            if ( exception is Warning warning )
                return warning.HttpStatusCode;
            return null;
        }

        /// <summary>
        /// 获取错误码
        /// </summary>
        /// <param name="exception">异常</param>
        public static string GetErrorCode( this Exception exception ) {
            if ( exception == null )
                return null;
            exception = exception.GetRawException();
            if ( exception == null )
                return null;
            if ( exception is Warning warning )
                return warning.Code;
            return null;
        }
    }
}
