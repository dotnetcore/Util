using System;
using System.Linq;
using Util.Domains.Repositories;

namespace Util.Datas.Queries {
    /// <summary>
    /// 查询扩展
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="criteria">查询条件对象</param>
        public static IQueryable<TEntity> Where<TEntity>( this IQueryable<TEntity> source, ICriteria<TEntity> criteria ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( criteria == null )
                throw new ArgumentNullException( nameof( criteria ) );
            var predicate = criteria.GetPredicate();
            if( predicate == null )
                return source;
            return source.Where( predicate );
        }
    }
}
