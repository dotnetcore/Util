using System;
using Util.Domains.Trees;

namespace Util.Tests.Samples {
    /// <summary>
    /// 树型实体测试样例
    /// </summary>
    public class TreeEntitySample : TreeEntityBase<TreeEntitySample> {
        /// <summary>
        /// 初始化树型实体测试样例
        /// </summary>
        public TreeEntitySample() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化树型实体测试样例
        /// </summary>
        public TreeEntitySample( Guid id )
            : base( id, "", 0 ) {
        }

        /// <summary>
        /// 初始化树型实体测试样例
        /// </summary>
        public TreeEntitySample( Guid id, string path )
            : base( id, path, 0 ) {
        }
    }
}
