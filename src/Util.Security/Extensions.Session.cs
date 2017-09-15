using Util.Domains.Sessions;

namespace Util.Security {
    /// <summary>
    /// 用户上下文扩展
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 获取当前应用程序
        /// </summary>
        /// <param name="session">用户上下文</param>
        public static string GetApplication( this ISession session ) {
            return "测试应用程序";
        }

        /// <summary>
        /// 获取当前租户
        /// </summary>
        /// <param name="session">用户上下文</param>
        public static string GetTenant( this ISession session ) {
            return "测试租户";
        }
    }
}
