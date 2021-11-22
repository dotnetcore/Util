using System;
using System.Threading.Tasks;
using Xunit;

namespace Util.Domain.Tests.XUnitHelpers {
    /// <summary>
    /// 断言辅助操作
    /// </summary>
    public class AssertHelper {
        /// <summary>
        /// 抛出异常，并从异常消息中搜索特定关键字
        /// </summary>
        /// <typeparam name="TException">异常类型</typeparam>
        /// <param name="action">操作</param>
        /// <param name="keyword">关键字</param>
        public static TException Throws<TException>( Action action,string keyword = "" ) where TException : Exception {
            var exception = Assert.Throws<TException>( action );
            if( !string.IsNullOrWhiteSpace( keyword ) )
                Assert.Contains( keyword, exception.Message );
            return exception;
        }

        /// <summary>
        /// 抛出异常，并从异常消息中搜索特定关键字
        /// </summary>
        /// <typeparam name="TException">异常类型</typeparam>
        /// <param name="action">操作</param>
        /// <param name="keyword">关键字</param>
        public static async Task<TException> ThrowsAsync<TException>( Func<Task> action, string keyword = "" ) where TException : Exception {
            var exception = await Assert.ThrowsAsync<TException>( action );
            if( !string.IsNullOrWhiteSpace( keyword ) )
                Assert.Contains( keyword, exception.Message );
            return exception;
        }
    }
}
