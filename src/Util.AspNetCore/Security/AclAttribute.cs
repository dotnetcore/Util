using Microsoft.AspNetCore.Authorization;
using Util.Security.Authorization;

namespace Util.Security {
    /// <summary>
    /// 访问控制
    /// </summary>
    public class AclAttribute : AuthorizeAttribute {
        /// <summary>
        /// 是否忽略
        /// </summary>
        private bool _ignore;
        /// <summary>
        /// 资源标识
        /// </summary>
        private string _resourceUri;

        /// <summary>
        /// 初始化访问控制
        /// </summary>
        public AclAttribute() {
            Policy = AclPolicyHelper.GetPolicy( null, false );
        }

        /// <summary>
        /// 初始化访问控制
        /// </summary>
        /// <param name="resourceUri">资源标识</param>
        public AclAttribute( string resourceUri ) {
            ResourceUri = resourceUri;
        }

        /// <summary>
        /// 是否忽略授权检查,设置为true则不验证权限,但仍然需要登录,需要匿名访问请使用AllowAnonymous特性
        /// </summary>
        public bool Ignore {
            get {
                var requirement = AclPolicyHelper.GetRequirement(Policy);
                return requirement.Ignore;
            }
            set {
                _ignore = value;
                Policy = AclPolicyHelper.GetPolicy( _resourceUri , _ignore );
            }
        }

        /// <summary>
        /// 资源标识
        /// </summary>
        public string ResourceUri {
            get {
                var requirement = AclPolicyHelper.GetRequirement( Policy );
                return requirement.Uri;
            }
            set {
                _resourceUri = value;
                Policy = AclPolicyHelper.GetPolicy( _resourceUri, _ignore );
            }
        }
    }
}
