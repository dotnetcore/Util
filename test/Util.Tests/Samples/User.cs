using System;
using Util.Domains;

namespace Util.Tests.Samples {
    /// <summary>
    /// 用户
    /// </summary>
    public class User : AggregateRoot<User> {
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