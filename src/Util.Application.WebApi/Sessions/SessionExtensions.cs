using System;
using Util.Helpers;
using Util.Security;
using Util.Sessions;
using Convert = Util.Helpers.Convert;

namespace Util.Applications.Sessions {
    /// <summary>
    /// 用户会话扩展
    /// </summary>
    public static class SessionExtensions {
        /// <summary>
        /// 获取当前操作人标识
        /// </summary>
        /// <param name="session">用户会话</param>
        public static Guid GetUserId( this ISession session ) {
            return session.UserId.ToGuid();
        }

        /// <summary>
        /// 获取当前操作人标识
        /// </summary>
        /// <param name="session">用户会话</param>
        public static T GetUserId<T>( this ISession session ) {
            return Convert.To<T>( session.UserId );
        }

        /// <summary>
        /// 获取当前操作人姓名
        /// </summary>
        /// <param name="session">用户会话</param>
        public static string GetName( this ISession session ) {
            return Web.Identity.GetValue( ClaimTypes.Name );
        }

        /// <summary>
        /// 获取当前操作人电子邮件
        /// </summary>
        /// <param name="session">用户会话</param>
        public static string GetEmail( this ISession session ) {
            return Web.Identity.GetValue( ClaimTypes.Email );
        }

        /// <summary>
        /// 获取当前操作人手机号
        /// </summary>
        /// <param name="session">用户会话</param>
        public static string GetPhoneNumber( this ISession session ) {
            return Web.Identity.GetValue( ClaimTypes.PhoneNumber );
        }

        /// <summary>
        /// 获取当前应用程序标识
        /// </summary>
        /// <param name="session">用户会话</param>
        public static Guid GetApplicationId( this ISession session ) {
            return Web.Identity.GetValue( ClaimTypes.ApplicationId ).ToGuid();
        }

        /// <summary>
        /// 获取当前应用程序标识
        /// </summary>
        /// <param name="session">用户会话</param>
        public static T GetApplicationId<T>( this ISession session ) {
            return Convert.To<T>( Web.Identity.GetValue( ClaimTypes.ApplicationId ) );
        }

        /// <summary>
        /// 获取当前应用程序编码
        /// </summary>
        /// <param name="session">用户会话</param>
        public static string GetApplicationCode( this ISession session ) {
            return Web.Identity.GetValue( ClaimTypes.ApplicationCode );
        }

        /// <summary>
        /// 获取当前应用程序名称
        /// </summary>
        /// <param name="session">用户会话</param>
        public static string GetApplicationName( this ISession session ) {
            return Web.Identity.GetValue( ClaimTypes.ApplicationName );
        }

        /// <summary>
        /// 获取当前租户标识
        /// </summary>
        /// <param name="session">用户会话</param>
        public static Guid GetTenantId( this ISession session ) {
            return Web.Identity.GetValue( ClaimTypes.TenantId ).ToGuid();
        }

        /// <summary>
        /// 获取当前租户标识
        /// </summary>
        /// <param name="session">用户会话</param>
        public static T GetTenantId<T>( this ISession session ) {
            return Convert.To<T>( Web.Identity.GetValue( ClaimTypes.TenantId ) );
        }

        /// <summary>
        /// 获取当前租户编码
        /// </summary>
        /// <param name="session">用户会话</param>
        public static string GetTenantCode( this ISession session ) {
            return Web.Identity.GetValue( ClaimTypes.TenantCode );
        }

        /// <summary>
        /// 获取当前租户名称
        /// </summary>
        /// <param name="session">用户会话</param>
        public static string GetTenantName( this ISession session ) {
            return Web.Identity.GetValue( ClaimTypes.TenantName );
        }
    }
}
