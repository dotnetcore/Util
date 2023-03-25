using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Util.Applications;

namespace Util.Security.Authorization {
    /// <summary>
    /// 访问控制过滤器
    /// </summary>
    public class AclFilter : AuthorizeFilter {
        /// <summary>
        /// 初始化访问控制过滤器
        /// </summary>
        public AclFilter()
            : base( new AclPolicyProvider(),new[] { new AclAttribute() } ) {
        }

        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="context">授权过滤器上下文</param>
        public override async Task OnAuthorizationAsync( AuthorizationFilterContext context ) {
            context.CheckNull( nameof( context ) );
            if ( context.IsEffectivePolicy( this ) == false ) {
                return;
            }
            var effectivePolicy = await GetEffectivePolicyAsync( context );
            if ( effectivePolicy == null )
                return;
            var policyEvaluator = context.HttpContext.RequestServices.GetRequiredService<IPolicyEvaluator>();
            var authenticateResult = await policyEvaluator.AuthenticateAsync( effectivePolicy, context.HttpContext );
            if ( HasAllowAnonymous( context ) ) {
                return;
            }
            var authorizationResult = await policyEvaluator.AuthorizeAsync( effectivePolicy, authenticateResult, context.HttpContext, context );
            SetContextResult( context, authorizationResult );
        }

        /// <summary>
        /// 获取有效授权策略
        /// </summary>
        protected async Task<AuthorizationPolicy> GetEffectivePolicyAsync( AuthorizationFilterContext context ) {
            var builder = new AuthorizationPolicyBuilder( await ComputePolicyAsync() );
            for ( var i = 0; i < context.Filters.Count; i++ ) {
                if ( ReferenceEquals( this, context.Filters[i] ) )
                    continue;
                if ( context.Filters[i] is AclFilter authorizeFilter ) {
                    builder.Combine( await authorizeFilter.ComputePolicyAsync() );
                }
            }
            var endpoint = context.HttpContext.GetEndpoint();
            if ( endpoint != null ) {
                var policyProvider = PolicyProvider ?? context.HttpContext.RequestServices.GetRequiredService<IAuthorizationPolicyProvider>();
                var endpointAuthorizeData = endpoint.Metadata.GetOrderedMetadata<IAuthorizeData>() ?? Array.Empty<IAuthorizeData>();
                var endpointPolicy = await AuthorizationPolicy.CombineAsync( policyProvider, endpointAuthorizeData );
                if ( endpointPolicy != null && endpointPolicy.Requirements.Any( t => t is AclRequirement ) ) {
                    builder.Requirements.Remove( builder.Requirements.FirstOrDefault( t => t is AclRequirement ) );
                    builder.Combine( endpointPolicy );
                }
            }
            return builder.Build();
        }

        /// <summary>
        /// 合并授权策略
        /// </summary>
        protected async ValueTask<AuthorizationPolicy> ComputePolicyAsync() {
            return await AuthorizationPolicy.CombineAsync( PolicyProvider, AuthorizeData );
        }

        /// <summary>
        /// 是否允许匿名访问
        /// </summary>
        protected bool HasAllowAnonymous( AuthorizationFilterContext context ) {
            var filters = context.Filters;
            for ( var i = 0; i < filters.Count; i++ ) {
                if ( filters[i] is IAllowAnonymousFilter ) {
                    return true;
                }
            }
            var endpoint = context.HttpContext.GetEndpoint();
            if ( endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null ) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 设置授权过滤器上下文结果
        /// </summary>
        /// <param name="context">授权过滤器上下文</param>
        /// <param name="authorizationResult">授权结果</param>
        protected virtual void SetContextResult( AuthorizationFilterContext context,PolicyAuthorizationResult authorizationResult ) {
            if ( authorizationResult.Succeeded )
                return;
            context.Result = new JsonResult( new { Code = StateCode.Unauthorized } ) { StatusCode = 200 };
        }
    }
}
