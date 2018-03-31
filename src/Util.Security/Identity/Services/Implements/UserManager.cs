using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Util.Domains.Services;
using Util.Security.Identity.Extensions;
using Util.Security.Identity.Models;
using Util.Security.Identity.Options;
using Util.Security.Identity.Repositories;
using Util.Security.Identity.Services.Abstractions;

namespace Util.Security.Identity.Services.Implements {
    /// <summary>
    /// 用户服务
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TKey">用户标识类型</typeparam>
    public class UserManager<TUser, TKey> : DomainServiceBase, IUserManager<TUser, TKey> where TUser : User<TUser,TKey> {
        /// <summary>
        /// 初始化用户服务
        /// </summary>
        /// <param name="userManager">Identity用户服务</param>
        /// <param name="options">权限配置</param>
        /// <param name="userRepository">用户仓储</param>
        public UserManager( IdentityUserManager<TUser, TKey> userManager, IOptions<PermissionOptions> options,
                IUserRepository<TUser,TKey> userRepository ) {
            Manager = userManager;
            Options = options;
            UserRepository = userRepository;
        }

        /// <summary>
        /// Identity用户服务
        /// </summary>
        protected IdentityUserManager<TUser, TKey> Manager { get; }
        /// <summary>
        /// 权限配置
        /// </summary>
        protected IOptions<PermissionOptions> Options { get; set; }
        /// <summary>
        /// 用户仓储
        /// </summary>
        protected IUserRepository<TUser, TKey> UserRepository { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">密码</param>
        public async Task CreateAsync( TUser user, string password ) {
            if( user == null )
                throw new ArgumentNullException( nameof( user ) );
            user.Init();
            user.Validate();
            var result = await Manager.CreateAsync( user, password );
            result.ThrowIfError();
            user.SetPassword( Options?.Value.Store.StoreOriginalPassword, password );
        }

        /// <summary>
        /// 生成电子邮件确认令牌
        /// </summary>
        /// <param name="user">用户</param>
        public Task<string> GenerateEmailConfirmationTokenAsync( TUser user ) {
            return Manager.GenerateEmailConfirmationTokenAsync( user );
        }

        /// <summary>
        /// 确认电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="token">令牌</param>
        public async Task ConfirmEmailAsync( TUser user, string token ) {
            var result = await Manager.ConfirmEmailAsync( user, token );
            result.ThrowIfError();
        }

        /// <summary>
        /// 生成电子邮件重置密码令牌
        /// </summary>
        /// <param name="user">用户</param>
        public Task<string> GenerateEmailPasswordResetTokenAsync( TUser user ) {
            return Manager.GenerateUserTokenAsync( user, TokenOptions.DefaultProvider, UserManager<TUser>.ResetPasswordTokenPurpose );
        }

        /// <summary>
        /// 通过电子邮件重置密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="token">令牌</param>
        /// <param name="newPassword">新密码</param>
        public async Task ResetPasswordByEmailAsync( TUser user, string token, string newPassword ) {
            var result = await Manager.ResetPasswordAsync( user, TokenOptions.DefaultProvider, token, newPassword );
            result.ThrowIfError();
        }

        /// <summary>
        /// 生成手机号重置密码令牌
        /// </summary>
        /// <param name="user">用户</param>
        public Task<string> GeneratePhonePasswordResetTokenAsync( TUser user ) {
            return Manager.GenerateUserTokenAsync( user, TokenOptions.DefaultPhoneProvider, UserManager<TUser>.ResetPasswordTokenPurpose );
        }

        /// <summary>
        /// 通过手机号重置密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="token">令牌</param>
        /// <param name="newPassword">新密码</param>
        public async Task ResetPasswordByPhoneAsync( TUser user, string token, string newPassword ) {
            var result = await Manager.ResetPasswordAsync( user, TokenOptions.DefaultPhoneProvider, token, newPassword );
            result.ThrowIfError();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="currentPassword">当前密码</param>
        /// <param name="newPassword">新密码</param>
        public async Task ChangePasswordAsync( TUser user, string currentPassword, string newPassword ) {
            var result = await Manager.ChangePasswordAsync( user, currentPassword, newPassword );
            result.ThrowIfError();
        }

        /// <summary>
        /// 通过用户名查找
        /// </summary>
        /// <param name="userName">用户名</param>
        public Task<TUser> FindByNameAsync( string userName ) {
            return Manager.FindByNameAsync( userName );
        }

        /// <summary>
        /// 通过电子邮件查找
        /// </summary>
        /// <param name="email">电子邮件</param>
        public Task<TUser> FindByEmailAsync( string email ) {
            return Manager.FindByEmailAsync( email );
        }

        /// <summary>
        /// 通过手机号查找
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        public Task<TUser> FindByPhoneAsync( string phoneNumber ) {
            return UserRepository.SingleAsync( t => t.PhoneNumber == phoneNumber );
        }
    }
}
