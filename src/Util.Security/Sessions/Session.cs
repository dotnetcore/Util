using Util.Helpers;
using IdentityModel;
using Util.Sessions;

namespace Util.Security.Sessions {
    /// <summary>
    /// 用户会话
    /// </summary>
    public class Session : ISession {
        /// <summary>
        /// 空用户会话
        /// </summary>
        public static readonly ISession Null = NullSession.Instance;

        /// <summary>
        /// 用户会话
        /// </summary>
        public static readonly ISession Instance = new Session();

        /// <summary>
        /// 是否认证
        /// </summary>
        public bool IsAuthenticated => Web.Identity.IsAuthenticated;

        /// <summary>
        /// 用户标识
        /// </summary>
        public string UserId {
            get {
                var result = Web.Identity.GetValue( JwtClaimTypes.Subject );
                return string.IsNullOrWhiteSpace( result ) ? Web.Identity.GetValue( System.Security.Claims.ClaimTypes.NameIdentifier ) : result;
            }
        }
    }
}