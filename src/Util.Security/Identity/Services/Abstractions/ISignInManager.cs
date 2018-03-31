using System.Threading.Tasks;
using Util.Security.Identity.Models;

namespace Util.Security.Identity.Services.Abstractions {
    /// <summary>
    /// 登录服务
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TKey">用户类型</typeparam>
    public interface ISignInManager<in TUser, TKey> where TUser : User<TUser, TKey> {
        /// <summary>
        /// 密码登录
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">密码</param>
        /// <param name="isPersistent">cookie是否持久保留,设置为false,当关闭浏览器则cookie失效</param>
        /// <param name="lockoutOnFailure">达到登录失败次数是否锁定</param>
        Task PasswordSignInAsync( TUser user, string password, bool isPersistent = false, bool lockoutOnFailure = true );
    }
}
