using System;
using System.Threading.Tasks;
using Xunit;

namespace Util.Tests.XUnitHelpers {
    /// <summary>
    /// 断言操作
    /// </summary>
    public class AssertHelper {
        /// <summary>
        /// 抛出异常，并从异常消息中搜索特定关键字
        /// </summary>
        /// <typeparam name="TException">异常类型</typeparam>
        /// <param name="action">操作</param>
        /// <param name="keyword">关键字</param>
        public static TException Throws<TException>( Action action,string keyword = "" ) where TException : Exception {
            var exception = GetException<TException>( action );
            if( !string.IsNullOrWhiteSpace( keyword ) )
                Assert.Contains( keyword, exception.Message );
            return exception;
        }

        /// <summary>
        /// 获取异常
        /// </summary>
        private static TException GetException<TException>( Action action ) where TException : Exception {
            return Assert.Throws<TException>(action);
        }

        /// <summary>
        /// 抛出异常，并从异常消息中搜索特定关键字
        /// </summary>
        /// <typeparam name="TException">异常类型</typeparam>
        /// <param name="action">操作</param>
        /// <param name="keyword">关键字</param>
        public static async Task<TException> ThrowsAsync<TException>( Func<Task> action, string keyword = "" ) where TException : Exception {
            var exception = await GetExceptionAsync<TException>( action );
            if( !string.IsNullOrWhiteSpace( keyword ) )
                Assert.Contains( keyword, exception.Message );
            return exception;
        }

        /// <summary>
        /// 获取异常
        /// </summary>
        private static async Task<TException> GetExceptionAsync<TException>( Func<Task> action ) where TException : Exception {
            return await Assert.ThrowsAsync<TException>(action);
        }
    }
}
