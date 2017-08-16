using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Util.Domains.Repositories {
    /// <summary>
    /// 精简仓储 - 配合Po使用
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface ICompactRepository<TEntity> : ICompactRepository<TEntity, Guid>
        where TEntity : class, IAggregateRoot {
    }

    /// <summary>
    /// 精简仓储 - 配合Po使用
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface ICompactRepository<TEntity, in TKey> where TEntity : class, IAggregateRoot {
        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        TEntity Find( object id );
        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">实体标识列表</param>
        List<TEntity> FindByIds( params TKey[] ids );
        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">实体标识列表</param>
        List<TEntity> FindByIds( IEnumerable<TKey> ids );
        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        Task<TEntity> FindAsync( object id );
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Add( TEntity entity );
        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Add( IEnumerable<TEntity> entities );
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        Task AddAsync( TEntity entity );
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Update( TEntity entity );
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        Task UpdateAsync( TEntity entity );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        void Remove( TKey id );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        Task RemoveAsync( TKey id );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Remove( TEntity entity );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        Task RemoveAsync( TEntity entity );
    }
}
