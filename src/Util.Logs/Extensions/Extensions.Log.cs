using Util.Logs.Abstractions;
using Util.Logs.Core;

namespace Util.Logs.Extensions {
    /// <summary>
    /// 日志扩展
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 设置业务编号
        /// </summary>
        /// <param name="log">日志操作</param>
        /// <param name="businessId">业务编号</param>
        public static ILog BusinessId( this ILog log, string businessId ) {
            return log.Content<Content>( content => content.BusinessId = businessId );
        }
    }
}
