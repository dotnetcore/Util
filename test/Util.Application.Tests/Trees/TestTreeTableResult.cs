using System.Collections.Generic;
using Util.Applications.Dtos;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形表格结果
    /// </summary>
    public class TestTreeTableResult : TreeTableResultBase<TreeDto, TreeDto, List<TreeDto>> {
        public TestTreeTableResult( IEnumerable<TreeDto> data, bool async = false ) : base( data, async ) {
        }

        protected override TreeDto ToDestinationNode( TreeDto node ) {
            return new TreeDto {
                Id = node.Id,
                Leaf = node.Leaf
            };
        }

        protected override List<TreeDto> ToResult( List<TreeDto> nodes ) {
            return nodes;
        }
    }
}
