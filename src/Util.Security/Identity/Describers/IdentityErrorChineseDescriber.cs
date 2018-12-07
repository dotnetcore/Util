using Microsoft.AspNetCore.Identity;
using Util.Security.Properties;

namespace Util.Security.Identity.Describers {
    /// <summary>
    /// Identity中文错误描述
    /// </summary>
    public class IdentityErrorChineseDescriber : IdentityErrorDescriber {
        /// <summary>
        /// 密码太短
        /// </summary>
        public override IdentityError PasswordTooShort( int length ) {
            return new IdentityError {
                Code = nameof( PasswordTooShort ),
                Description = string.Format( SecurityResource.PasswordTooShort,length )
            };
        }

        /// <summary>
        /// 密码应包含非字母和数字的特殊字符
        /// </summary>
        public override IdentityError PasswordRequiresNonAlphanumeric() {
            return new IdentityError {
                Code = nameof( PasswordRequiresNonAlphanumeric ),
                Description = SecurityResource.PasswordRequiresNonAlphanumeric
            };
        }

        /// <summary>
        /// 密码应包含大写字母
        /// </summary>
        public override IdentityError PasswordRequiresUpper() {
            return new IdentityError {
                Code = nameof( PasswordRequiresUpper ),
                Description = SecurityResource.PasswordRequiresUpper
            };
        }

        /// <summary>
        /// 密码应包含数字
        /// </summary>
        public override IdentityError PasswordRequiresDigit() {
            return new IdentityError {
                Code = nameof( PasswordRequiresDigit ),
                Description = SecurityResource.PasswordRequiresDigit
            };
        }

        /// <summary>
        /// 密码应包含不重复的字符数
        /// </summary>
        public override IdentityError PasswordRequiresUniqueChars( int uniqueChars ) {
            return new IdentityError {
                Code = nameof( PasswordRequiresUniqueChars ),
                Description = string.Format( SecurityResource.PasswordRequiresUniqueChars, uniqueChars )
            };
        }

        /// <summary>
        /// 无效用户名
        /// </summary>
        public override IdentityError InvalidUserName( string userName ) {
            return new IdentityError {
                Code = nameof( InvalidUserName ),
                Description = string.Format( SecurityResource.InvalidUserName, userName )
            };
        }

        /// <summary>
        /// 用户名重复
        /// </summary>
        public override IdentityError DuplicateUserName( string userName ) {
            return new IdentityError {
                Code = nameof( DuplicateUserName ),
                Description = string.Format( SecurityResource.DuplicateUserName, userName )
            };
        }

        /// <summary>
        /// 电子邮件重复
        /// </summary>
        public override IdentityError DuplicateEmail( string email ) {
            return new IdentityError {
                Code = nameof( DuplicateEmail ),
                Description = string.Format( SecurityResource.DuplicateEmail, email )
            };
        }

        /// <summary>
        /// 无效令牌
        /// </summary>
        public override IdentityError InvalidToken() {
            return new IdentityError {
                Code = nameof( InvalidToken ),
                Description = SecurityResource.InvalidToken
            };
        }

        /// <summary>
        /// 密码错误
        /// </summary>
        public override IdentityError PasswordMismatch() {
            return new IdentityError {
                Code = nameof( PasswordMismatch ),
                Description = SecurityResource.PasswordMismatch
            };
        }

        /// <summary>
        /// 角色名无效
        /// </summary>
        public override IdentityError InvalidRoleName( string role ) {
            return new IdentityError {
                Code = nameof( InvalidRoleName ),
                Description = string.Format( SecurityResource.InvalidRoleName, role )
            };
        }

        /// <summary>
        /// 角色名重复
        /// </summary>
        public override IdentityError DuplicateRoleName( string role ) {
            return new IdentityError {
                Code = nameof( DuplicateRoleName ),
                Description = string.Format( SecurityResource.DuplicateRoleName, role )
            };
        }
    }
}
