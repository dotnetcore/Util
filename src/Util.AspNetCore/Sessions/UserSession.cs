using Util.Helpers;
using Util.Security;

namespace Util.Sessions {
    /// <summary>
    /// 用户会话
    /// </summary>
    public class UserSession : ISession {
        /// <summary>
        /// 空用户会话
        /// </summary>
        public static readonly ISession Null = NullSession.Instance;

        /// <summary>
        /// 用户会话
        /// </summary>
        public static readonly ISession Instance = new UserSession();

        /// <summary>
        /// 是否认证
        /// </summary>
        public bool IsAuthenticated => Web.Identity.IsAuthenticated;

        /// <summary>
        /// 用户标识
        /// </summary>
        public string UserId {
            get {
                var result = Web.Identity.GetValue( ClaimTypes.UserId );
                return result.IsEmpty() ? Web.Identity.GetValue( System.Security.Claims.ClaimTypes.NameIdentifier ) : result;
            }
        }
    }
}