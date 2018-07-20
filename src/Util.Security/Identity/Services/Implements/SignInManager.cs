using System.Threading.Tasks;
using Util.Exceptions;
using Util.Security.Identity.Models;
using Util.Security.Identity.Results;
using Util.Security.Identity.Services.Abstractions;
using Util.Security.Properties;

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
        /// <param name="userManager">用户服务</param>
        public SignInManager( IdentitySignInManager<TUser, TKey> signInManager, IUserManager<TUser, TKey> userManager ) {
            IdentitySignInManager = signInManager;
            UserManager = userManager;
        }

        /// <summary>
        /// Identity登录服务
        /// </summary>
        protected IdentitySignInManager<TUser, TKey> IdentitySignInManager { get; }
        /// <summary>
        /// 用户服务
        /// </summary>
        protected IUserManager<TUser, TKey> UserManager { get; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">帐号，可以是用户名，手机号或电子邮件</param>
        /// <param name="password">密码</param>
        /// <param name="isPersistent">cookie是否持久保留,设置为false,当关闭浏览器则cookie失效</param>
        /// <param name="lockoutOnFailure">达到登录失败次数是否锁定</param>
        /// <param name="applicationCode">应用程序编码</param>
        public async Task<SignInResult> SignInAsync( string account, string password, bool isPersistent = false, bool lockoutOnFailure = true, string applicationCode = "" ) {
            var user = await GetUser( account );
            if( user == null )
                throw new Warning( SecurityResource.InvalidAccountOrPassword );
            var result = await PasswordSignIn( user, password, isPersistent, lockoutOnFailure, applicationCode );
            if( result.State == SignInState.Failed )
                throw new Warning( SecurityResource.InvalidAccountOrPassword );
            return result;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        private async Task<TUser> GetUser( string account ) {
            var user = await UserManager.FindByPhoneAsync( account );
            if( user == null )
                user = await UserManager.FindByNameAsync( account );
            if( user == null )
                user = await UserManager.FindByEmailAsync( account );
            return user;
        }

        /// <summary>
        /// 密码登录
        /// </summary>
        private async Task<SignInResult> PasswordSignIn( TUser user, string password, bool isPersistent = false, bool lockoutOnFailure = true, string applicationCode = "" ) {
            await AddClaimsToUser( user, applicationCode );
            var signInResult = await IdentitySignInManager.PasswordSignInAsync( user, password, isPersistent, lockoutOnFailure );
            if( signInResult.IsNotAllowed )
                throw new Warning( SecurityResource.UserIsDisabled );
            if( signInResult.IsLockedOut )
                throw new Warning( SecurityResource.LoginFailLock );
            if( signInResult.Succeeded )
                return new SignInResult( SignInState.Succeeded,user.Id.SafeString() );
            if( signInResult.RequiresTwoFactor )
                return new SignInResult( SignInState.TwoFactor, user.Id.SafeString() );
            return new SignInResult( SignInState.Failed, string.Empty );
        }

        /// <summary>
        /// 添加声明到用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="applicationCode">应用程序编码</param>
        protected virtual Task AddClaimsToUser( TUser user, string applicationCode ) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 用户名密码登录
        /// </summary>
        /// <param name="userName">用户</param>
        /// <param name="password">密码</param>
        /// <param name="isPersistent">cookie是否持久保留,设置为false,当关闭浏览器则cookie失效</param>
        /// <param name="lockoutOnFailure">达到登录失败次数是否锁定</param>
        /// <param name="applicationCode">应用程序编码</param>
        public async Task<SignInResult> SignInByUserNameAsync( string userName, string password, bool isPersistent = false, bool lockoutOnFailure = true, string applicationCode = "" ) {
            var user = await UserManager.FindByNameAsync( userName );
            if( user == null )
                throw new Warning( SecurityResource.InvalidUserNameOrPassword );
            var result = await PasswordSignIn( user, password, isPersistent, lockoutOnFailure, applicationCode );
            if( result.State == SignInState.Failed )
                throw new Warning( SecurityResource.InvalidUserNameOrPassword );
            return result;
        }

        /// <summary>
        /// 电子邮件密码登录
        /// </summary>
        /// <param name="email">电子邮件</param>
        /// <param name="password">密码</param>
        /// <param name="isPersistent">cookie是否持久保留,设置为false,当关闭浏览器则cookie失效</param>
        /// <param name="lockoutOnFailure">达到登录失败次数是否锁定</param>
        /// <param name="applicationCode">应用程序编码</param>
        public async Task<SignInResult> SignInByEmailAsync( string email, string password, bool isPersistent = false, bool lockoutOnFailure = true, string applicationCode = "" ) {
            var user = await UserManager.FindByEmailAsync( email );
            if( user == null )
                throw new Warning( SecurityResource.InvalidEmailOrPassword );
            var result = await PasswordSignIn( user, password, isPersistent, lockoutOnFailure, applicationCode );
            if( result.State == SignInState.Failed )
                throw new Warning( SecurityResource.InvalidEmailOrPassword );
            return result;
        }

        /// <summary>
        /// 手机号密码登录
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        /// <param name="password">密码</param>
        /// <param name="isPersistent">cookie是否持久保留,设置为false,当关闭浏览器则cookie失效</param>
        /// <param name="lockoutOnFailure">达到登录失败次数是否锁定</param>
        /// <param name="applicationCode">应用程序编码</param>
        public async Task<SignInResult> SignInByPhoneAsync( string phoneNumber, string password, bool isPersistent = false, bool lockoutOnFailure = true, string applicationCode = "" ) {
            var user = await UserManager.FindByPhoneAsync( phoneNumber );
            if( user == null )
                throw new Warning( SecurityResource.InvalidPhoneOrPassword );
            var result = await PasswordSignIn( user, password, isPersistent, lockoutOnFailure, applicationCode );
            if( result.State == SignInState.Failed )
                throw new Warning( SecurityResource.InvalidPhoneOrPassword );
            return result;
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public async Task SignOutAsync() {
            await IdentitySignInManager.SignOutAsync();
        }
    }
}
