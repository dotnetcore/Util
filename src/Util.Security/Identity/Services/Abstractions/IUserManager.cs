using System.Threading.Tasks;
using Util.Domains.Services;
using Util.Security.Identity.Models;

namespace Util.Security.Identity.Services.Abstractions {
    /// <summary>
    /// 用户服务
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TKey">用户标识类型</typeparam>
    public interface IUserManager<TUser, TKey> : IDomainService where TUser : User<TUser, TKey> {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">密码</param>
        Task CreateAsync( TUser user, string password );
        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="purpose">用途</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        Task<string> GenerateTokenAsync( string phone, string purpose, string application = "", string provider = "" );
        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="purpose">用途</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        Task<string> GenerateTokenAsync( TUser user, string purpose, string application = "", string provider = "" );
        /// <summary>
        /// 验证令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="purpose">用途</param>
        /// <param name="token">令牌</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        Task<bool> VerifyTokenAsync( string phone, string purpose, string token, string application = "", string provider = "" );
        /// <summary>
        /// 验证令牌
        /// </summary>
        /// <param name="user">手机号</param>
        /// <param name="purpose">用途</param>
        /// <param name="token">令牌</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        Task<bool> VerifyTokenAsync( TUser user, string purpose, string token, string application = "", string provider = "" );
        /// <summary>
        /// 生成手机号注册令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="application">应用程序</param>
        Task<string> GenerateRegisterTokenAsync( string phone, string application = "" );
        /// <summary>
        /// 验证手机号注册令牌
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="token">令牌</param>
        /// <param name="application">应用程序</param>
        Task<bool> VerifyRegisterTokenAsync( string phone, string token, string application = "" );
        /// <summary>
        /// 生成电子邮件确认令牌
        /// </summary>
        /// <param name="user">用户</param>
        Task<string> GenerateEmailConfirmationTokenAsync( TUser user );
        /// <summary>
        /// 激活电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="token">令牌</param>
        Task ConfirmEmailAsync( TUser user, string token );
        /// <summary>
        /// 生成电子邮件重置密码令牌
        /// </summary>
        /// <param name="user">用户</param>
        Task<string> GenerateEmailPasswordResetTokenAsync( TUser user );
        /// <summary>
        /// 通过电子邮件重置密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="token">令牌</param>
        /// <param name="newPassword">新密码</param>
        Task ResetPasswordByEmailAsync( TUser user, string token, string newPassword );
        /// <summary>
        /// 生成手机号重置密码令牌
        /// </summary>
        /// <param name="user">用户</param>
        Task<string> GeneratePhonePasswordResetTokenAsync( TUser user );
        /// <summary>
        /// 通过手机号重置密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="token">令牌</param>
        /// <param name="newPassword">新密码</param>
        Task ResetPasswordByPhoneAsync( TUser user, string token, string newPassword );
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="currentPassword">当前密码</param>
        /// <param name="newPassword">新密码</param>
        Task ChangePasswordAsync( TUser user, string currentPassword, string newPassword );
        /// <summary>
        /// 通过用户名查找
        /// </summary>
        /// <param name="userName">用户名</param>
        Task<TUser> FindByNameAsync( string userName );
        /// <summary>
        /// 通过电子邮件查找
        /// </summary>
        /// <param name="email">电子邮件</param>
        Task<TUser> FindByEmailAsync( string email );
        /// <summary>
        /// 通过手机号查找
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        Task<TUser> FindByPhoneAsync( string phoneNumber );
    }
}
