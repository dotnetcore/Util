using Util.Helpers;
using Util.Security.Principals;
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
        /// 是否认证
        /// </summary>
        public bool IsAuthenticated => Web.Identity.IsAuthenticated;

        /// <summary>
        /// 用户标识
        /// </summary>
        public string UserId => Web.Identity.GetValue( ClaimTypes.UserId );
    }
}