using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Util.Datas.Stores;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Datas.Ef.Core {
    /// <summary>
    /// 仓储 - 配合持久化对象使用
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    public abstract partial class CompactRepositoryBase<TEntity, TPo> : CompactRepositoryBase<TEntity, TPo, Guid>, ICompactRepository<TEntity>
        where TEntity : class, IAggregateRoot<Guid>
        where TPo : class, IKey<Guid> {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="store">存储器</param>
        protected CompactRepositoryBase( IStore<TPo,Guid> store ) : base( store ) {
        }
    }

    /// <summary>
    /// 仓储 - 配合持久化对象使用
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract partial class CompactRepositoryBase<TEntity, TPo, TKey> : ICompactRepository<TEntity, TKey>
        where TEntity : class, IAggregateRoot<TKey>
        where TPo : class, IKey<TKey> {
        /// <summary>
        /// 存储器
        /// </summary>
        private readonly IStore<TPo, TKey> _store;

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="store">存储器</param>
        protected CompactRepositoryBase( IStore<TPo, TKey> store ) {
            _store = store;
        }

        /// <summary>
        /// 将持久化对象转成实体
        /// </summary>
        /// <param name="po">持久化对象</param>
        protected abstract TEntity ToEntity( TPo po );

        /// <summary>
        /// 将实体转成持久化对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected abstract TPo ToPo( TEntity entity );

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public virtual TEntity Find( object id ) {
            return ToEntity( _store.Find( id ) );
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task<TEntity> FindAsync( object id, CancellationToken cancellationToken = default( CancellationToken ) ) {
            return ToEntity( await _store.FindAsync( id, cancellationToken ) );
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">实体标识列表</param>
        public virtual List<TEntity> FindByIds( params TKey[] ids ) {
            return _store.FindByIds( ids ).Select( ToEntity ).ToList();
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">实体标识列表</param>
        public virtual List<TEntity> FindByIds( IEnumerable<TKey> ids ) {
            return _store.FindByIds( ids ).Select( ToEntity ).ToList();
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        public virtual List<TEntity> FindByIds( string ids ) {
            return _store.FindByIds( ids ).Select( ToEntity ).ToList();
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public virtual async Task<List<TEntity>> FindByIdsAsync( params TKey[] ids ) {
            var pos = await _store.FindByIdsAsync( ids );
            return pos.Select( ToEntity ).ToList();
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task<List<TEntity>> FindByIdsAsync( IEnumerable<TKey> ids, CancellationToken cancellationToken = default( CancellationToken ) ) {
            var pos = await _store.FindByIdsAsync( ids, cancellationToken );
            return pos.Select( ToEntity ).ToList();
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">逗号分隔的标识列表，范例："1,2"</param>
        public virtual async Task<List<TEntity>> FindByIdsAsync( string ids ) {
            var pos = await _store.FindByIdsAsync( ids );
            return pos.Select( ToEntity ).ToList();
        }

        /// <summary>
        /// 判断实体是否存在
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public virtual bool Exists( params TKey[] ids ) {
            return _store.Exists( ids );
        }

        /// <summary>
        /// 判断实体是否存在
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public virtual async Task<bool> ExistsAsync( params TKey[] ids ) {
            return await _store.ExistsAsync( ids );
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Add( TEntity entity ) {
            _store.Add( ToPo( entity ) );
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual void Add( IEnumerable<TEntity> entities ) {
            _store.Add( entities.Select( ToPo ) );
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task AddAsync( TEntity entity, CancellationToken cancellationToken = default( CancellationToken ) ) {
            await _store.AddAsync( ToPo( entity ), cancellationToken );
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task AddAsync( IEnumerable<TEntity> entities, CancellationToken cancellationToken = default( CancellationToken ) ) {
            await _store.AddAsync( entities.Select( ToPo ), cancellationToken );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Update( TEntity entity ) {
            _store.Update( ToPo( entity ) );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual void Update( IEnumerable<TEntity> entities ) {
            _store.Update( entities.Select( ToPo ) );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual async Task UpdateAsync( TEntity entity ) {
            await _store.UpdateAsync( ToPo( entity ) );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual async Task UpdateAsync( IEnumerable<TEntity> entities ) {
            await _store.UpdateAsync( entities.Select( ToPo ) );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public virtual void Remove( object id ) {
            _store.Remove( id );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task RemoveAsync( object id, CancellationToken cancellationToken = default( CancellationToken ) ) {
            await _store.RemoveAsync( id, cancellationToken );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Remove( TEntity entity ) {
            _store.Remove( ToPo( entity ) );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task RemoveAsync( TEntity entity, CancellationToken cancellationToken = default( CancellationToken ) ) {
            await _store.RemoveAsync( ToPo( entity ), cancellationToken );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        public virtual void Remove( IEnumerable<TKey> ids ) {
            _store.Remove( ids );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task RemoveAsync( IEnumerable<TKey> ids, CancellationToken cancellationToken = default( CancellationToken ) ) {
            await _store.RemoveAsync( ids, cancellationToken );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual void Remove( IEnumerable<TEntity> entities ) {
            _store.Remove( entities.Select( ToPo ) );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task RemoveAsync( IEnumerable<TEntity> entities, CancellationToken cancellationToken = default( CancellationToken ) ) {
            await _store.RemoveAsync( entities.Select( ToPo ), cancellationToken );
        }
    }
}
