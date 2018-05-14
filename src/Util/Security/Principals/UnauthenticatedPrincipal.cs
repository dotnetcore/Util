using System.Security.Claims;
using System.Security.Principal;

namespace Util.Security.Principals {
    /// <summary>
    /// 未认证安全主体
    /// </summary>
    public class UnauthenticatedPrincipal : ClaimsPrincipal {
        /// <summary>
        /// 初始化未认证安全主体
        /// </summary>
        private UnauthenticatedPrincipal(){
        }

        /// <summary>
        /// 未认证安全主体
        /// </summary>
        public static readonly UnauthenticatedPrincipal Instance = new UnauthenticatedPrincipal();

        /// <summary>
        /// 身份标识
        /// </summary>
        public override IIdentity Identity => UnauthenticatedIdentity.Instance;
    }
}
