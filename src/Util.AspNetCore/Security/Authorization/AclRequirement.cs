using Microsoft.AspNetCore.Authorization;

namespace Util.Security.Authorization {
    /// <summary>
    /// 授权要求
    /// </summary>
    public class AclRequirement : IAuthorizationRequirement {
        /// <summary>
        /// 是否忽略
        /// </summary>
        public bool Ignore { get; set; }
        /// <summary>
        /// 资源标识
        /// </summary>
        public string Uri { get; set; }
    }
}
