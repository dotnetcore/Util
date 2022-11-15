using System;
using Util.Applications.Trees;
using Util.Domain.Trees;

namespace Util.ObjectMapping.AutoMapper.Tests.Samples {
    /// <summary>
    /// 树形实体测试样例
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

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// 树形Dto测试样例
    /// </summary>
    public class TreeEntityDto : TreeDtoBase {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        public override string GetText() {
            return Name;
        }
    }
}
