using System.Collections.Generic;
using System.Linq;
using Util.Applications.Trees;

namespace Util.Ui.Prime.TreeTables.Datas {
    /// <summary>
    /// Prime树结果
    /// </summary>
    public class PrimeTreeResult<TNode> where TNode : ITreeNode {
        /// <summary>
        /// 树型节点列表
        /// </summary>
        private readonly IEnumerable<TNode> _nodes;
        /// <summary>
        /// 是否异步加载
        /// </summary>
        private readonly bool _async;
        /// <summary>
        /// 所有节点是否全部展开
        /// </summary>
        private readonly bool _allExpand;

        /// <summary>
        /// 初始化Prime树结果
        /// </summary>
        /// <param name="nodes">树型节点列表</param>
        /// <param name="async">是否异步加载</param>
        /// <param name="allExpand">所有节点是否全部展开</param>
        public PrimeTreeResult( IEnumerable<TNode> nodes, bool async = false, bool allExpand = false ) {
            _nodes = nodes;
            _async = async;
            _allExpand = allExpand;
        }

        /// <summary>
        /// 获取Prime树结果
        /// </summary>
        public List<PrimeTreeNode<TNode>> GetResult() {
            var result = new List<PrimeTreeNode<TNode>>();
            if( _nodes == null )
                return result;
            foreach( var root in _nodes.Where( IsRoot ) )
                AddNode( result, ToPrimeTreeNode( root ) );
            return result;
        }

        /// <summary>
        /// 是否根节点
        /// </summary>
        private bool IsRoot( TNode node ) {
            if( _nodes.Any( t => t.ParentId.IsEmpty() ) )
                return node.ParentId.IsEmpty();
            return node.Level == _nodes.Min( t => t.Level );
        }

        /// <summary>
        /// 转换为Prime树节点
        /// </summary>
        private PrimeTreeNode<TNode> ToPrimeTreeNode( TNode node ) {
            var result = new PrimeTreeNode<TNode> {
                Data = node,
                Expanded = _allExpand ? true : node.Expanded
            };
            return result;
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        private void AddNode( List<PrimeTreeNode<TNode>> result, PrimeTreeNode<TNode> node ) {
            if( node == null )
                return;
            SetDefault( node );
            if( IsRoot( node.Data ) )
                result.Add( node );
            if( IsLeaf( node.Data ) )
                return;
            node.Children = GetChildren( node.Data );
            foreach( var child in node.Children )
                AddNode( result, child );
        }

        /// <summary>
        /// 设置默认值
        /// </summary>
        private void SetDefault( PrimeTreeNode<TNode> node ) {
            if( _async )
                node.Leaf = false;
        }

        /// <summary>
        /// 是否叶节点
        /// </summary>
        private bool IsLeaf( TNode node ) {
            if( node.Id.IsEmpty() )
                return true;
            return _nodes.All( t => t.ParentId != node.Id );
        }

        /// <summary>
        /// 获取节点直接下级
        /// </summary>
        private List<PrimeTreeNode<TNode>> GetChildren( TNode node ) {
            return _nodes.Where( t => t.ParentId == node.Id ).Select( ToPrimeTreeNode ).ToList();
        }
    }
}
