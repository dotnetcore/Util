using System.Collections.Generic;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形结果
    /// </summary>
    /// <typeparam name="TSourceNode">源节点类型</typeparam>
    /// <typeparam name="TDestinationNode">目标节点类型</typeparam>
    /// <typeparam name="TResult">树形结果</typeparam>
    public abstract class TreeResultBase<TSourceNode, TDestinationNode, TResult> : TreeTableResultBase<TSourceNode, TDestinationNode, TResult>
        where TSourceNode : ITreeNode<TSourceNode>
        where TDestinationNode : class
        where TResult : class {
        /// <summary>
        /// 初始化树形结果
        /// </summary>
        /// <param name="data">树形参数列表</param>
        /// <param name="async">是否异步加载</param>
        /// <param name="allExpand">所有节点是否全部展开</param>
        protected TreeResultBase( IEnumerable<TSourceNode> data, bool async = false, bool allExpand = false ) : base( data, async, allExpand ) {
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="root">根节点</param>
        protected override void AddNode( TSourceNode root ) {
            if ( root == null )
                return;
            InitNode( root );
            AddChildren( root );
            var destinationNode = ToDestinationNode( root );
            AddDestinationNode( destinationNode );
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        protected virtual void AddChildren( TSourceNode node ) {
            if ( node == null )
                return;
            var children = GetChildren( node );
            children.ForEach( InitNode );
            node.Children = children;
            foreach ( var child in node.Children )
                AddChildren( child );
        }
    }
}
