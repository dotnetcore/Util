using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Util.Domains.Repositories {
    /// <summary>
    /// 仓储 - 可读
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IReadableRepository<TEntity> : IReadableRepository<TEntity, Guid> where TEntity : class, IAggregateRoot {
    }

    /// <summary>
    /// 仓储 - 可读
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface IReadableRepository<TEntity, in TKey> where TEntity : class, IAggregateRoot {
        /// <summary>
        /// 获取未跟踪的实体集
        /// </summary>
        IQueryable<TEntity> FindAsNoTracking();
        /// <summary>
        /// 查找实体集合
        /// </summary>
        IQueryable<TEntity> Find();
        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="criteria">条件</param>
        IQueryable<TEntity> Find( ICriteria<TEntity> criteria );
        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="predicate">条件</param>
        IQueryable<TEntity> Find( Expression<Func<TEntity, bool>> predicate );
        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        TEntity Find( object id );
        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        Task<TEntity> FindAsync( object id );
        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        List<TEntity> FindByIds( params TKey[] ids );
        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        List<TEntity> FindByIds( IEnumerable<TKey> ids );
        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        Task<List<TEntity>> FindByIdsAsync( params TKey[] ids );
        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        Task<List<TEntity>> FindByIdsAsync( IEnumerable<TKey> ids );
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        TEntity Single( Expression<Func<TEntity, bool>> predicate );
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        Task<TEntity> SingleAsync( Expression<Func<TEntity, bool>> predicate );
        /// <summary>
        /// 查找实体集合
        /// </summary>
        List<TEntity> FindAll( Expression<Func<TEntity, bool>> predicate = null );
        /// <summary>
        /// 查找实体集合
        /// </summary>
        Task<List<TEntity>> FindAllAsync( Expression<Func<TEntity, bool>> predicate = null );
    }
}
