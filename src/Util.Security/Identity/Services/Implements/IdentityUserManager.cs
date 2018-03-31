using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Util.Security.Identity.Models;

namespace Util.Security.Identity.Services.Implements {
    /// <summary>
    /// Identity用户服务
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TKey">用户标识类型</typeparam>
    public class IdentityUserManager<TUser, TKey> : AspNetUserManager<TUser> where TUser : User<TUser,TKey> {
        /// <summary>
        /// 初始化Identity用户服务
        /// </summary>
        /// <param name="store">用户存储</param>
        /// <param name="optionsAccessor">配置</param>
        /// <param name="passwordHasher">密码加密器</param>
        /// <param name="userValidators">用户验证器</param>
        /// <param name="passwordValidators">密码验证器</param>
        /// <param name="keyNormalizer">键标准化器</param>
        /// <param name="errors">错误描述</param>
        /// <param name="services">服务提供程序</param>
        /// <param name="logger">日志</param>
        public IdentityUserManager( IUserStore<TUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TUser> passwordHasher,
            IEnumerable<IUserValidator<TUser>> userValidators, IEnumerable<IPasswordValidator<TUser>> passwordValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TUser>> logger )
            : base( store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger ) {
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="tokenProvidor">令牌提供程序</param>
        /// <param name="token">令牌</param>
        /// <param name="newPassword">新密码</param>
        public async Task<IdentityResult> ResetPasswordAsync( TUser user, string tokenProvidor, string token, string newPassword ) {
            ThrowIfDisposed();
            if( user == null )
                throw new ArgumentNullException( nameof( user ) );
            if( !await VerifyUserTokenAsync( user, tokenProvidor, ResetPasswordTokenPurpose, token ) )
                return IdentityResult.Failed( ErrorDescriber.InvalidToken() );
            var result = await UpdatePasswordHash( user, newPassword, true );
            if( !result.Succeeded )
                return result;
            return await UpdateUserAsync( user );
        }
    }
}
