using Microsoft.AspNetCore.Identity;
using Util.Security.Identity.Options;

namespace Util.Security.Identity.Extensions {
    /// <summary>
    /// Identity配置扩展
    /// </summary>
    public static class IdentityOptionsExtensions {
        /// <summary>
        /// 加载权限配置
        /// </summary>
        /// <param name="options">Identity配置</param>
        /// <param name="permissionOptions">权限配置</param>
        public static void Load( this IdentityOptions options, PermissionOptions permissionOptions ) {
            if( options == null || permissionOptions == null )
                return;
            LoadPassword( options, permissionOptions );
            LoadUser( options, permissionOptions );
        }

        /// <summary>
        /// 加载密码配置
        /// </summary>
        private static void LoadPassword( IdentityOptions options, PermissionOptions permissionOptions ) {
            options.Password.RequiredLength = permissionOptions.Password.MinLength;
            options.Password.RequireNonAlphanumeric = permissionOptions.Password.NonAlphanumeric;
            options.Password.RequireUppercase = permissionOptions.Password.Uppercase;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = permissionOptions.Password.Digit;
            options.Password.RequiredUniqueChars = permissionOptions.Password.UniqueChars;
        }

        /// <summary>
        /// 加载用户配置
        /// </summary>
        private static void LoadUser( IdentityOptions options, PermissionOptions permissionOptions ) {
            options.User.AllowedUserNameCharacters = permissionOptions.User.UserNameCharacters;
            options.User.RequireUniqueEmail = permissionOptions.User.UniqueEmail;
        }
    }
}
