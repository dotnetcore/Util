using System;
using System.Linq.Expressions;
using Util.Domain.Trees;

namespace Util.Data.Trees {
    /// <summary>
    /// 树形查询条件
    /// </summary>
    public class TreeCondition<TEntity> : TreeCondition<TEntity, Guid?> where TEntity : IPath, IEnabled, IParentId<Guid?> {
        /// <summary>
        /// 初始化树型查询条件
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public TreeCondition( ITreeQueryParameter parameter ) : base( parameter ) {
        }
    }

    /// <summary>
    /// 树形查询条件
    /// </summary>
    /// <typeparam name="TEntity">树形实体类型</typeparam>
    /// <typeparam name="TParentId">树形实体父标识类型</typeparam>
    public class TreeCondition<TEntity, TParentId> : ICondition<TEntity> where TEntity : IPath, IEnabled, IParentId<TParentId> {
        /// <summary>
        /// 初始化树形查询条件
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public TreeCondition( ITreeQueryParameter parameter ) {
            if ( parameter == null )
                return;
            var parentId = Util.Helpers.Convert.To<TParentId>( parameter.ParentId );
            if ( parameter.ParentId.IsEmpty() == false )
                Condition = Condition.And( t => t.ParentId.Equals( parentId ) );
            if ( parameter.Path.IsEmpty() == false )
                Condition = Condition.And( t => t.Path.StartsWith( parameter.Path ) );
            if ( parameter.Level != null )
                Condition = Condition.And( t => t.Level == parameter.Level );
            if ( parameter.Enabled != null )
                Condition = Condition.And( t => t.Enabled == parameter.Enabled );
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        protected Expression<Func<TEntity, bool>> Condition { get; set; }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public Expression<Func<TEntity, bool>> GetCondition() {
            return Condition;
        }
    }
}
