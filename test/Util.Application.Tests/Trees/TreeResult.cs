using System.Collections.Generic;
using Util.Applications.Dtos;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形结果
    /// </summary>
    public class TreeResult : TreeResultBase<TreeDto, TreeDto,List<TreeDto>> {
        public TreeResult( IEnumerable<TreeDto> data, bool async = false ) : base( data, async ) {
        }

        protected override TreeDto ToDestinationNode( TreeDto node ) {
            return new TreeDto {
                Id = node.Id,
                Leaf = node.Leaf,
                Children = node.Children
            };
        }

        protected override List<TreeDto> ToResult( List<TreeDto> nodes ) {
            return nodes;
        }
    }
}
