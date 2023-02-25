using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Util.Security.Authorization {
    /// <summary>
    /// 授权策略提供器
    /// </summary>
    public class AclPolicyProvider : IAuthorizationPolicyProvider {
        /// <summary>
        /// 获取授权策略
        /// </summary>
        /// <param name="policyName">授权策略名称</param>
        public Task<AuthorizationPolicy> GetPolicyAsync( string policyName ) {
            var builder = new AuthorizationPolicyBuilder();
            var requirement = AclPolicyHelper.GetRequirement( policyName );
            builder.AddRequirements( requirement );
            return Task.FromResult( builder.Build() );
        }

        /// <summary>
        /// 获取默认授权策略
        /// </summary>
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() {
            return Task.FromResult( new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build() );
        }

        /// <summary>
        /// 获取回退授权策略
        /// </summary>
        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() {
            return Task.FromResult<AuthorizationPolicy>( null );
        }
    }
}
