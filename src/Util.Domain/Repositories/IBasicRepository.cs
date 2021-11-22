using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Util.Data.Filters;
using Util.Dependency;
using Util.Domain.Entities;
using Util.Validation;

namespace Util.Domain.Repositories {
    /// <summary>
    /// 基础仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IBasicRepository<TEntity> : IBasicRepository<TEntity, Guid>
        where TEntity : class, IAggregateRoot<Guid> {
    }

    /// <summary>
    /// 基础仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface IBasicRepository<TEntity, in TKey> : IFilterOperation, IScopeDependency where TEntity : class, IAggregateRoot<TKey> {
        /// <summary>
        /// 通过标识查找实体
        /// </summary>
        /// <param name="id">标识</param>
        TEntity FindById( object id );
        /// <summary>
        /// 通过标识查找实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<TEntity> FindByIdAsync( object id, CancellationToken cancellationToken = default );
        /// <summary>
        /// 通过标识列表查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        List<TEntity> FindByIds( params TKey[] ids );
        /// <summary>
        /// 通过标识列表查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        List<TEntity> FindByIds( IEnumerable<TKey> ids );
        /// <summary>
        /// 通过标识列表查找实体列表
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        List<TEntity> FindByIds( string ids );
        /// <summary>
        /// 通过标识列表查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        Task<List<TEntity>> FindByIdsAsync( params TKey[] ids );
        /// <summary>
        /// 通过标识列表查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<List<TEntity>> FindByIdsAsync( IEnumerable<TKey> ids, CancellationToken cancellationToken = default );
        /// <summary>
        /// 通过标识列表查找实体列表
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task<List<TEntity>> FindByIdsAsync( string ids, CancellationToken cancellationToken = default );
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="ids">标识列表</param>
        bool Exists( params TKey[] ids );
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="ids">标识列表</param>
        Task<bool> ExistsAsync( params TKey[] ids );
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Add( [Valid] TEntity entity );
        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Add( [Valid] IEnumerable<TEntity> entities );
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task AddAsync( [Valid] TEntity entity, CancellationToken cancellationToken );
        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task AddAsync( [Valid] IEnumerable<TEntity> entities, CancellationToken cancellationToken );
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Update( [Valid] TEntity entity );
        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Update( [Valid] IEnumerable<TEntity> entities );
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task UpdateAsync( [Valid] TEntity entity, CancellationToken cancellationToken = default );
        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task UpdateAsync( [Valid] IEnumerable<TEntity> entities, CancellationToken cancellationToken = default );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">标识</param>
        void Remove( object id );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Remove( TEntity entity );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">标识集合</param>
        void Remove( IEnumerable<TKey> ids );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Remove( IEnumerable<TEntity> entities );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( object id, CancellationToken cancellationToken = default );
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( TEntity entity, CancellationToken cancellationToken = default );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">标识集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( IEnumerable<TKey> ids, CancellationToken cancellationToken = default );
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        Task RemoveAsync( IEnumerable<TEntity> entities, CancellationToken cancellationToken = default );
    }
}
