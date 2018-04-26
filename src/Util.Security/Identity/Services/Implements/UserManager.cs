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
using Util.Security.Identity.Services.Configs;

namespace Util.Security.Identity.Services.Implements {
    /// <summary>
    /// 用户服务
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TKey">用户标识类型</typeparam>
    public class UserManager<TUser, TKey> : DomainServiceBase, IUserManager<TUser, TKey> where TUser : User<TUser, TKey>, new() {

        #region 构造方法

        /// <summary>
        /// 初始化用户服务
        /// </summary>
        /// <param name="userManager">Identity用户服务</param>
        /// <param name="options">权限配置</param>
        /// <param name="userRepository">用户仓储</param>
        public UserManager( IdentityUserManager<TUser, TKey> userManager, IOptions<PermissionOptions> options,
            IUserRepository<TUser, TKey> userRepository ) {
            Manager = userManager;
            Options = options;
            UserRepository = userRepository;
        }

        #endregion

        #region 属性

        /// <summary>
        /// Identity用户服务
        /// </summary>
        private IdentityUserManager<TUser, TKey> Manager { get; }
        /// <summary>
        /// 权限配置
        /// </summary>
        private IOptions<PermissionOptions> Options { get; }
        /// <summary>
        /// 用户仓储
        /// </summary>
        private IUserRepository<TUser, TKey> UserRepository { get; }

        #endregion

        #region 创建用户

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">密码</param>
        public async Task CreateAsync( TUser user, string password ) {
            if( user == null )
                throw new ArgumentNullException( nameof( user ) );
            user.Init();
            var result = await Manager.CreateAsync( user, password );
            result.ThrowIfError();
            user.SetPassword( Options?.Value.Store.StoreOriginalPassword, password );
        }

        #endregion

        #region 生成令牌

        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="purpose">用途</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        public async Task<string> GenerateTokenAsync( string phone, string purpose, string application = "", string provider = "" ) {
            var user = await GetUserOrDefault( phone );
            return await GenerateTokenAsync( user, purpose, application, provider );
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        private async Task<TUser> GetUserOrDefault( string phone ) {
            var user = await this.FindByPhoneAsync( phone );
            if( user == null ) {
                user = new TUser() {
                    PhoneNumber = phone,
                    SecurityStamp = CreateSecurityStamp()
                };
            }
            return user;
        }

        /// <summary>
        /// 创建安全戳
        /// </summary>
        protected virtual string CreateSecurityStamp() {
            return "56df9984-bc05-460a-a4ce-9dec3922a5e9";
        }

        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="purpose">用途</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        public async Task<string> GenerateTokenAsync( TUser user, string purpose, string application = "", string provider = "" ) {
            user.CheckNull( nameof( user ) );
            purpose = GetPurpose( purpose, application );
            if( provider.IsEmpty() )
                provider = TokenOptions.DefaultPhoneProvider;
            return await Manager.GenerateUserTokenAsync( user, provider, purpose );
        }

        /// <summary>
        /// 获取用途
        /// </summary>
        private string GetPurpose( string purpose, string application ) {
            return $"{purpose}_{application}";
        }

        #endregion

        #region 验证令牌

        /// <summary>
        /// 验证令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="purpose">用途</param>
        /// <param name="token">令牌</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        public async Task<bool> VerifyTokenAsync( string phone, string purpose, string token, string application = "", string provider = "" ) {
            var user = await GetUserOrDefault( phone );
            return await VerifyTokenAsync( user, purpose, token, application, provider );
        }

        /// <summary>
        /// 验证令牌
        /// </summary>
        /// <param name="user">手机号</param>
        /// <param name="purpose">用途</param>
        /// <param name="token">令牌</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        public async Task<bool> VerifyTokenAsync( TUser user, string purpose, string token, string application = "", string provider = "" ) {
            user.CheckNull( nameof( user ) );
            purpose = GetPurpose( purpose, application );
            if( provider.IsEmpty() )
                provider = TokenOptions.DefaultPhoneProvider;
            return await Manager.VerifyUserTokenAsync( user, provider, purpose, token );
        }

        #endregion

        #region 生成和验证手机号注册令牌

        /// <summary>
        /// 生成手机号注册令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="application">应用程序</param>
        public async Task<string> GenerateRegisterTokenAsync( string phone, string application = "" ) {
            return await GenerateTokenAsync( phone, TokenPurpose.PhoneRegister, application );
        }

        /// <summary>
        /// 验证手机号注册令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="token">令牌</param>
        /// <param name="application">应用程序</param>
        public async Task<bool> VerifyRegisterTokenAsync( string phone, string token, string application = "" ) {
            return await VerifyTokenAsync( phone, TokenPurpose.PhoneRegister, token, application );
        }

        #endregion

        #region 激活电子邮件

        /// <summary>
        /// 生成电子邮件确认令牌
        /// </summary>
        /// <param name="user">用户</param>
        public Task<string> GenerateEmailConfirmationTokenAsync( TUser user ) {
            return Manager.GenerateEmailConfirmationTokenAsync( user );
        }

        /// <summary>
        /// 激活电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="token">令牌</param>
        public async Task ConfirmEmailAsync( TUser user, string token ) {
            var result = await Manager.ConfirmEmailAsync( user, token );
            result.ThrowIfError();
        }

        #endregion

        #region 电子邮件找回密码

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

        #endregion

        #region 手机号找回密码

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

        #endregion

        #region 修改密码

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

        #endregion

        #region 查找用户

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

        #endregion
    }
}
