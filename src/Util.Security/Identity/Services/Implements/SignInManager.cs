using Microsoft.AspNetCore.Identity;
using Util.Security.Identity.Models;
using Util.Security.Identity.Services.Abstractions;

namespace Util.Security.Identity.Services.Implements {
    /// <summary>
    /// 登录服务
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TKey">用户标识类型</typeparam>
    public class SignInManager<TUser, TKey> : ISignInManager where TUser : User<TUser, TKey> {
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
    }
}
