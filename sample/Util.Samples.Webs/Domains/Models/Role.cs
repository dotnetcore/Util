using System;
using Util.Security.Identity.Models;

namespace Util.Samples.Webs.Domains.Models {
    /// <summary>
    /// 角色
    /// </summary>
    public class Role : Role<Role,Guid,Guid?> {
        /// <summary>
        /// 初始化角色
        /// </summary>
        public Role()
            : this( Guid.Empty, "", 0 ) {
        }

        /// <summary>
        /// 初始化角色
        /// </summary>
        /// <param name="id">角色标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        public Role( Guid id, string path, int level )
            : base( id, path, level ) {
        }
    }
}