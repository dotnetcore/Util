using System.Collections.Generic;
using System.Linq;
using Util.Applications.Trees;

namespace Util.Applications {
    /// <summary>
    /// 树形节点扩展
    /// </summary>
    public static class TreeNodeExtensions {
        /// <summary>
        /// 从路径中获取所有上级节点标识
        /// </summary>
        /// <param name="node">树节点</param>
        /// <param name="excludeSelf">是否排除当前节点,默认排除自身</param>
        public static List<string> GetParentIdsFromPath( this ITreeNode node, bool excludeSelf = true ) {
            if ( node == null || node.Path.IsEmpty() )
                return new List<string>();
            var result = node.Path.Split( ',' ).Where( id => !string.IsNullOrWhiteSpace( id ) && id != "," ).ToList();
            if ( excludeSelf )
                result = result.Where( id => id.SafeString().ToLower() != node.Id.SafeString().ToLower() ).ToList();
            return result;
        }

        /// <summary>
        /// 获取缺失的父标识列表
        /// </summary>
        /// <typeparam name="TNode">树节点类型</typeparam>
        /// <param name="nodes">树节点列表</param>
        public static List<string> GetMissingParentIds<TNode>( this IEnumerable<TNode> nodes ) where TNode : class, ITreeNode {
            var result = new List<string>();
            if ( nodes == null )
                return result;
            var list = nodes.ToList();
            list.ForEach( entity => {
                if ( entity == null )
                    return;
                result.AddRange( entity.GetParentIdsFromPath().Select( t => t.SafeString() ) );
            } );
            var ids = list.DistinctBy( t => t.Id ).Select( t => t?.Id.SafeString() );
            return result.Except( ids ).ToList();
        }
    }
}