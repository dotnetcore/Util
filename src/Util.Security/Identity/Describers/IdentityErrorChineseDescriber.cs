using Microsoft.AspNetCore.Identity;

namespace Util.Security.Identity.Describers {
    /// <summary>
    /// Identity中文错误描述
    /// </summary>
    public class IdentityErrorChineseDescriber : IdentityErrorDescriber {
        /// <summary>
        /// 密码太短
        /// </summary>
        /// <param name="length">密码长度</param>
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
    }
}
