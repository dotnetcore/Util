using System.Collections.Generic;
using System.Linq;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树型扩展
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        /// <param name="node">树节点</param>
        /// <param name="excludeSelf">是否排除当前节点,默认排除自身</param>
        public static List<string> GetParentIdsFromPath( this ITreeNode node, bool excludeSelf = true ) {
            if( node == null || node.Path.IsEmpty() )
                return new List<string>();
            var result = node.Path.Split( ',' ).Where( id => !string.IsNullOrWhiteSpace( id ) && id != "," ).ToList();
            if( excludeSelf )
                result = result.Where( id => id.SafeString().ToLower() != node.Id.SafeString().ToLower() ).ToList();
            return result;
        }

        /// <summary>
        /// 获取缺失的父标识列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entities">实体列表</param>
        public static List<string> GetMissingParentIds<TEntity>( this IEnumerable<TEntity> entities ) where TEntity : class,ITreeNode {
            var result = new List<string>();
            if( entities == null )
                return result;
            var list = entities.ToList();
            list.ForEach( entity => {
                if( entity == null )
                    return;
                result.AddRange( entity.GetParentIdsFromPath().Select( t => t.SafeString() ) );
            } );
            var ids = list.Select( t => t?.Id.SafeString() );
            return result.Except( ids ).ToList();
        }
    }
}
