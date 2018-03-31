using System.Threading.Tasks;
using Util.Domains.Services;
using Util.Security.Identity.Models;

namespace Util.Security.Identity.Services.Abstractions {
    /// <summary>
    /// 用户服务
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TKey">用户标识类型</typeparam>
    public interface IUserManager<in TUser, TKey> : IDomainService where TUser: User<TUser,TKey> {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">密码</param>
        Task CreateAsync( TUser user, string password );
        /// <summary>
        /// 生成电子邮件确认令牌
        /// </summary>
        /// <param name="user">用户</param>
        Task<string> GenerateEmailConfirmationTokenAsync( TUser user );
        /// <summary>
        /// 确认电子邮件
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
    }
}
