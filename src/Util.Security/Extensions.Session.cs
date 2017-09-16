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
            return "权限系统";
        }

        /// <summary>
        /// 获取当前租户
        /// </summary>
        /// <param name="session">用户上下文</param>
        public static string GetTenant( this ISession session ) {
            return "";
        }

        /// <summary>
        /// 获取当前操作人姓名
        /// </summary>
        /// <param name="session">用户上下文</param>
        public static string GetFullName( this ISession session ) {
            return "胡一刀";
        }

        /// <summary>
        /// 获取当前操作人角色名
        /// </summary>
        /// <param name="session">用户上下文</param>
        public static string GetRoleName( this ISession session ) {
            return "老大，老二";
        }
    }
}
