using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Util.Exceptions;
using Util.Security.Identity.Models;
using Util.Security.Identity.Services.Abstractions;

namespace Util.Security.Identity.Services.Implements {
    /// <summary>
    /// 登录服务
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TKey">用户标识类型</typeparam>
    public class SignInManager<TUser, TKey> : ISignInManager<TUser, TKey> where TUser : User<TUser, TKey> {
        /// <summary>
        /// 初始化登录服务
        /// </summary>
        /// <param name="signInManager">Identity登录服务</param>
        public SignInManager( SignInManager<TUser> signInManager ) {
            Manager = signInManager;
        }

        /// <summary>
        /// Identity登录服务
        /// </summary>
        protected SignInManager<TUser> Manager { get; }

        /// <summary>
        /// 密码登录
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">密码</param>
        /// <param name="isPersistent">cookie是否持久保留,设置为false,当关闭浏览器则cookie失效</param>
        /// <param name="lockoutOnFailure">达到登录失败次数是否锁定</param>
        public async Task PasswordSignInAsync( TUser user, string password, bool isPersistent = false, bool lockoutOnFailure = true ) {
            var result = await Manager.PasswordSignInAsync( user, password, isPersistent, lockoutOnFailure );
            if( result.Succeeded )
                return;
            if( result.IsLockedOut )
                throw new Warning( SecurityResource.LoginFailLock );
            if( result.IsNotAllowed )
                throw new Warning( SecurityResource.UserIsDisabled );
        }
    }
}
