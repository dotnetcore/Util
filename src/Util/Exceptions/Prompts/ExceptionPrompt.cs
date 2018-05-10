using System;
using System.Collections.Generic;
using Util.Properties;

namespace Util.Exceptions.Prompts {
    /// <summary>
    /// 异常提示
    /// </summary>
    public class ExceptionPrompt {
        /// <summary>
        /// 初始化
        /// </summary>
        private ExceptionPrompt() {
        }

        /// <summary>
        /// 异常提示组件集合
        /// </summary>
        private static readonly List<IExceptionPrompt> Prompts = new List<IExceptionPrompt>();

        /// <summary>
        /// 获取异常提示实例
        /// </summary>
        public static readonly ExceptionPrompt Instance = new ExceptionPrompt();

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
        public string GetPrompt( Exception exception ) {
            exception = GetException( exception );
            var prompt = GetExceptionPrompt( exception );
            if( string.IsNullOrWhiteSpace( prompt ) == false )
                return prompt;
            if( exception is Warning warning )
                return warning.Message;
            return R.SystemError;
        }

        /// <summary>
        /// 获取异常
        /// </summary>
        private Exception GetException( Exception exception ) {
            if ( exception == null )
                return null;
            if ( exception is Autofac.Core.DependencyResolutionException ex )
                return GetException( ex.InnerException );
            return exception;
        }

        /// <summary>
        /// 获取异常提示
        /// </summary>
        private string GetExceptionPrompt( Exception exception ) {
            foreach( var prompt in Prompts ) {
                var result = prompt.GetPrompt( exception );
                if( result.IsEmpty() == false )
                    return result;
            }
            return string.Empty;
        }
    }
}
