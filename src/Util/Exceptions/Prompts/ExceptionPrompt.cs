using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Util.Helpers;
using Util.Properties;

namespace Util.Exceptions.Prompts {
    /// <summary>
    /// 异常提示
    /// </summary>
    public static class ExceptionPrompt {
        /// <summary>
        /// 异常提示组件集合
        /// </summary>
        private static readonly List<IExceptionPrompt> Prompts = new List<IExceptionPrompt>();

        /// <summary>
        /// 是否显示系统异常消息
        /// </summary>
        public static bool IsShowSystemException { get; set; }

        /// <summary>
        /// 添加异常提示
        /// </summary>
        /// <param name="prompt">异常提示</param>
        public static void AddPrompt( IExceptionPrompt prompt ) {
            if( prompt == null )
                throw new ArgumentNullException( nameof( prompt ) );
            if( Prompts.Contains( prompt ) )
                return;
            Prompts.Add( prompt );
        }

        /// <summary>
        /// 获取异常提示
        /// </summary>
        /// <param name="exception">异常</param>
        public static string GetPrompt( Exception exception ) {
            if ( exception == null )
                return null;
            exception = exception.GetRawException();
            var prompt = GetExceptionPrompt( exception );
            if( string.IsNullOrWhiteSpace( prompt ) == false )
                return prompt;
            if( exception is Warning warning )
                return warning.Message;
            if( Web.Environment.IsDevelopment() || IsShowSystemException )
                return exception.Message;
            return R.SystemError;
        }

        /// <summary>
        /// 获取异常提示
        /// </summary>
        private static string GetExceptionPrompt( Exception exception ) {
            foreach( var prompt in Prompts ) {
                var result = prompt.GetPrompt( exception );
                if( string.IsNullOrWhiteSpace( result ) == false )
                    return result;
            }
            return string.Empty;
        }
    }
}
