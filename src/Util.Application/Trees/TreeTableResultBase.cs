using System.Collections.Generic;
using System.Linq;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形表格结果
    /// </summary>
    /// <typeparam name="TSourceNode">源节点类型</typeparam>
    /// <typeparam name="TDestinationNode">目标节点类型</typeparam>
    /// <typeparam name="TResult">树形结果</typeparam>
    public abstract class TreeTableResultBase<TSourceNode, TDestinationNode, TResult>
        where TSourceNode : ITreeNode
        where TDestinationNode : class
        where TResult : class {
        /// <summary>
        /// 源节点列表
        /// </summary>
        private readonly List<TSourceNode> _data;
        /// <summary>
        /// 目标节点列表
        /// </summary>
        private readonly List<TDestinationNode> _result;
        /// <summary>
        /// 是否异步加载
        /// </summary>
        private readonly bool _async;
        /// <summary>
        /// 所有节点是否全部展开
        /// </summary>
        private readonly bool _allExpand;

        /// <summary>
        /// 初始化树形表格结果
        /// </summary>
        /// <param name="data">树形参数列表</param>
        /// <param name="async">是否异步加载</param>
        /// <param name="allExpand">所有节点是否全部展开</param>
        protected TreeTableResultBase( IEnumerable<TSourceNode> data, bool async = false, bool allExpand = false ) {
            data.CheckNull( nameof( data ) );
            _data = data.ToList();
            _async = async;
            _allExpand = allExpand;
            _result = new List<TDestinationNode>();
        }

        /// <summary>
        /// 获取源数据
        /// </summary>
        protected List<TSourceNode> GetData() {
            return _data;
        }

        /// <summary>
        /// 获取树形结果
        /// </summary>
        public TResult GetResult() {
            if ( _data == null )
                return ToResult( null );
            foreach ( var root in GetRootNodes() )
                AddNode( root );
            return ToResult( _result );
        }

        /// <summary>
        /// 获取根节点列表
        /// </summary>
        protected virtual List<TSourceNode> GetRootNodes() {
            return _data.Where( IsRoot ).OrderBy( t => t.SortId ).ToList();
        }

        /// <summary>
        /// 是否根节点
        /// </summary>
        protected virtual bool IsRoot( TSourceNode dto ) {
            if ( _data.Any( t => t.ParentId.IsEmpty() ) )
                return dto.ParentId.IsEmpty();
            return dto.Level == _data.Min( t => t.Level );
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        protected virtual void AddNode( TSourceNode node ) {
            if ( node == null )
                return;
            InitNode( node );
            var destinationNode = ToDestinationNode( node );
            AddDestinationNode( destinationNode );
            var children = GetChildren( node );
            foreach ( var child in children )
                AddNode( child );
        }

        /// <summary>
        /// 初始化节点
        /// </summary>
        protected void InitNode( TSourceNode node ) {
            InitLeaf( node );
            InitExpanded( node );
        }

        /// <summary>
        /// 初始化叶节点状态
        /// </summary>
        protected virtual void InitLeaf( TSourceNode node ) {
            node.Leaf = false;
            if ( _async )
                return;
            if ( IsLeaf( node ) )
                node.Leaf = true;
        }

        /// <summary>
        /// 是否叶节点
        /// </summary>
        protected virtual bool IsLeaf( TSourceNode node ) {
            if ( _data.All( t => t.ParentId != node.Id ) )
                return true;
            var children = _data.FindAll( t => t.ParentId == node.Id );
            if ( children.All( t => t.Hide == true ) )
                return true;
            return false;
        }

        /// <summary>
        /// 初始化节点展开状态
        /// </summary>
        protected virtual void InitExpanded( TSourceNode node ) {
            if ( _allExpand == false )
                return;
            if ( _async == false ) {
                node.Expanded = true;
                return;
            }
            if ( _data.All( t => t.Level == 1 ) )
                return;
            if( node.Leaf == false )
                node.Expanded = true;
        }

        /// <summary>
        /// 添加目标节点
        /// </summary>
        /// <param name="node">目标节点</param>
        protected void AddDestinationNode( TDestinationNode node ) {
            _result.Add( node );
        }

        /// <summary>
        /// 获取节点直接下级
        /// </summary>
        protected List<TSourceNode> GetChildren( TSourceNode node ) {
            return _data.Where( t => t.ParentId == node.Id ).OrderBy( t => t.SortId ).ToList();
        }

        /// <summary>
        /// 将源节点转换为目标节点
        /// </summary>
        /// <param name="node">源节点</param>
        protected virtual TDestinationNode ToDestinationNode( TSourceNode node ) {
            return node.MapTo<TDestinationNode>();
        }

        /// <summary>
        /// 转换为结果
        /// </summary>
        /// <param name="nodes">目标节点列表</param>
        protected abstract TResult ToResult( List<TDestinationNode> nodes );
    }
}
