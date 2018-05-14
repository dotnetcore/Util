using System.Security.Claims;

namespace Util {
    /// <summary>
    /// 系统扩展 - 安全
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 获取用户标识声明值
        /// </summary>
        /// <param name="identity">用户标识</param>
        /// <param name="type">声明类型</param>
        public static string GetValue( this ClaimsIdentity identity, string type ) {
            var claim = identity.FindFirst( type );
            if( claim == null )
                return string.Empty;
            return claim.Value;
        }
    }
}
