using System;
using System.Linq.Expressions;
using Util.Domains.Repositories;
using Util.Domains.Trees;

namespace Util.Datas.Queries.Trees {
    /// <summary>
    /// 树型查询条件
    /// </summary>
    public class TreeCriteria<TEntity> : TreeCriteria<TEntity, Guid?> where TEntity : IPath, IEnabled, IParentId<Guid?> {
        /// <summary>
        /// 初始化树型查询条件
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public TreeCriteria( ITreeQueryParameter parameter ) : base( parameter ) {
            if( parameter.ParentId != null )
                Predicate = Predicate.And( t => t.ParentId == parameter.ParentId );
        }
    }

    /// <summary>
    /// 树型查询条件
    /// </summary>
    public class TreeCriteria<TEntity, TParentId> : ICriteria<TEntity> where TEntity : IPath, IEnabled {
        /// <summary>
        /// 初始化树型查询条件
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public TreeCriteria( ITreeQueryParameter<TParentId> parameter ) {
            if( !string.IsNullOrWhiteSpace( parameter.Path ) )
                Predicate = Predicate.And( t => t.Path.StartsWith( parameter.Path ) );
            if( parameter.Level != null )
                Predicate = Predicate.And( t => t.Level == parameter.Level );
            if( parameter.Enabled != null )
                Predicate = Predicate.And( t => t.Enabled == parameter.Enabled );
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        protected Expression<Func<TEntity, bool>> Predicate { get; set; }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public Expression<Func<TEntity, bool>> GetPredicate() {
            return Predicate;
        }
    }
}
