using System.Collections.Generic;
using System.Linq;
using Util.Applications.Trees;

namespace Util.Ui.NgZorro.Data {
    /// <summary>
    /// 树形结果
    /// </summary>
    public class TreeResult<TNode> : TreeResultBase<TNode, NgZorroTreeNode, NgZorroTreeResult> where TNode : TreeDtoBase<TNode> {
        /// <summary>
        /// 树形结果
        /// </summary>
        private readonly NgZorroTreeResult _result;

        /// <summary>
        /// 初始化树形结果
        /// </summary>
        /// <param name="data">树形参数列表</param>
        /// <param name="async">是否异步加载</param>
        /// <param name="allExpand">所有节点是否全部展开</param>
        public TreeResult( IEnumerable<TNode> data, bool async = false, bool allExpand = false ) : base( data, async, allExpand ) {
            _result = new NgZorroTreeResult();
        }

        /// <summary>
        /// 转换为目标节点
        /// </summary>
        protected override NgZorroTreeNode ToDestinationNode( TNode dto ) {
            var result = new NgZorroTreeNode {
                Key = dto.Id,
                Title = dto.GetText(),
                Icon = dto.Icon,
                Disabled = !dto.Enabled.SafeValue(),
                Expanded = dto.Expanded.SafeValue(),
                Checked = dto.Checked.SafeValue(),
                DisableCheckbox = dto.DisableCheckbox.SafeValue(),
                Selectable = dto.Selectable.SafeValue(),
                Selected = dto.Selected.SafeValue(),
                IsLeaf = dto.Leaf.SafeValue(),
                OriginalNode = dto,
                Children = dto.Children.Select( ToDestinationNode ).ToList()
            };
            return result;
        }

        /// <summary>
        /// 转换为结果
        /// </summary>
        protected override NgZorroTreeResult ToResult( List<NgZorroTreeNode> nodes ) {
            var data = GetData();
            _result.CheckedKeys = data.Where( t => t.Checked == true ).Select( t => t.Id ).ToList();
            _result.SelectedKeys = data.Where( t => t.Selected == true ).Select( t => t.Id ).ToList();
            _result.Nodes = nodes;
            return _result;
        }
    }
}