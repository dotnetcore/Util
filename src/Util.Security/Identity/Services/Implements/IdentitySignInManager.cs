using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Util.Security.Identity.Models;

namespace Util.Security.Identity.Services.Implements {
    /// <summary>
    /// Identity登录服务
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TKey">用户标识类型</typeparam>
    public class IdentitySignInManager<TUser, TKey> : SignInManager<TUser> where TUser : User<TUser, TKey> {
        /// <summary>
        /// 初始化Identity登录服务
        /// </summary>
        /// <param name="userManager">Identity用户服务</param>
        /// <param name="contextAccessor">HttpContext访问器</param>
        /// <param name="claimsFactory">用户声明工厂</param>
        /// <param name="optionsAccessor">Identity配置</param>
        /// <param name="logger">日志</param>
        /// <param name="schemes">认证架构提供程序</param>
        public IdentitySignInManager( UserManager<TUser> userManager, IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<TUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<TUser>> logger, IAuthenticationSchemeProvider schemes )
                : base( userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes ) {
        }

        /// <summary>
        /// 是否允许登录
        /// </summary>
        /// <param name="user">用户</param>
        public override async Task<bool> CanSignInAsync( TUser user ) {
            if( user.Enabled == false )
                return false;
            return await base.CanSignInAsync( user );
        }

        /// <summary>
        /// 创建用户安全主体
        /// </summary>
        /// <param name="user">用户</param>
        public override async Task<ClaimsPrincipal> CreateUserPrincipalAsync( TUser user ) {
            var principal = await base.CreateUserPrincipalAsync( user );
            var identity = principal.Identity as ClaimsIdentity;
            user.AddUserClaims();
            identity?.AddClaims( user.GetClaims() );
            return principal;
        }
    }
}
