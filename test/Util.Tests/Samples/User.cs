using System;
using Util.Security.Identity.Models;

namespace Util.Tests.Samples {
    /// <summary>
    /// 用户
    /// </summary>
    public class User : User<User,Guid> {
        /// <summary>
        /// 初始化用户
        /// </summary>
        public User() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化用户
        /// </summary>
        /// <param name="id">用户标识</param>
        public User( Guid id ) : base( id ) {
        }
    }
}