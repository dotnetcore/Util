using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Util.Data.Filters;
using Util.Data.Queries;
using Util.Data.Stores;
using Util.Domain;
using Util.Exceptions;

namespace Util.Data.EntityFrameworkCore {
    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    public abstract class StoreBase<TEntity> : StoreBase<TEntity, Guid>, IStore<TEntity>
        where TEntity : class, IKey<Guid> {
        /// <summary>
        /// 初始化存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected StoreBase( IUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }

    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class StoreBase<TEntity, TKey> : IStore<TEntity, TKey>, IFilterSwitch, ITrack where TEntity : class, IKey<TKey> {

        #region 字段

        /// <summary>
        /// 是否已释放
        /// </summary>
        private bool _disposed;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected StoreBase( IUnitOfWork unitOfWork ) {
            UnitOfWork = (UnitOfWorkBase)unitOfWork;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 工作单元
        /// </summary>
        protected UnitOfWorkBase UnitOfWork { get; }

        /// <summary>
        /// 实体集
        /// </summary>
        protected DbSet<TEntity> Set => UnitOfWork.Set<TEntity>();

        /// <summary>
        /// 查询时是否跟踪对象
        /// </summary>
        protected bool IsTracking { get; private set; } = true;

        #endregion

        #region NoTracking(设置为不跟踪实体)

        /// <summary>
        /// 设置为不跟踪实体
        /// </summary>
        public void NoTracking() {
            IsTracking = false;
        }

        #endregion

        #region EnableFilter(启用过滤器)

        /// <summary>
        /// 启用过滤器
        /// </summary>
        /// <typeparam name="TFilterType">过滤器类型</typeparam>
        public void EnableFilter<TFilterType>() where TFilterType : class {
            UnitOfWork.EnableFilter<TFilterType>();
        }

        #endregion

        #region DisableFilter(禁用过滤器)

        /// <summary>
        /// 禁用过滤器
        /// </summary>
        /// <typeparam name="TFilterType">过滤器类型</typeparam>
        public IDisposable DisableFilter<TFilterType>() where TFilterType : class {
            return UnitOfWork.DisableFilter<TFilterType>();
        }

        #endregion

        #region Find(查找实体)

        /// <inheritdoc />
        public IQueryable<TEntity> Find() {
            ThrowIfDisposed();
            if ( IsTracking )
                return Set;
            var result = Set.AsNoTracking();
            IsTracking = true;
            return result;
        }

        /// <inheritdoc />
        public IQueryable<TEntity> Find( ICondition<TEntity> condition ) {
            return Find().Where( condition );
        }

        /// <inheritdoc />
        public IQueryable<TEntity> Find( Expression<Func<TEntity, bool>> condition ) {
            return Find().Where( condition );
        }

        #endregion

        #region FindById(通过标识查找实体)

        /// <inheritdoc />
        public TEntity FindById( object id ) {
            ThrowIfDisposed();
            if ( id.SafeString().IsEmpty() )
                return null;
            var key = GetKey( id );
            if( IsTracking )
                return Set.Find( key );
            return Single( t => t.Id.Equals( key ) );
        }

        /// <summary>
        /// 获取标识
        /// </summary>
        protected object GetKey( object id ) {
            if( id is TKey )
                return id;
            return Util.Helpers.Convert.To<TKey>( id );
        }

        #endregion

        #region FindByIdAsync(通过标识查找实体)

        /// <inheritdoc />
        public async Task<TEntity> FindByIdAsync( object id, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if ( id.SafeString().IsEmpty() )
                return null;
            var key = GetKey( id );
            if( IsTracking )
                return await Set.FindAsync( new[] { key }, cancellationToken );
            return await SingleAsync( t => t.Id.Equals( key ), cancellationToken );
        }

        #endregion

        #region FindByIds(通过标识列表查找实体列表)

        /// <inheritdoc />
        public virtual List<TEntity> FindByIds( params TKey[] ids ) {
            return FindByIds( (IEnumerable<TKey>)ids );
        }

        /// <inheritdoc />
        public virtual List<TEntity> FindByIds( IEnumerable<TKey> ids ) {
            return ids == null ? null : Find( t => ids.Contains( t.Id ) ).ToList();
        }

        /// <inheritdoc />
        public virtual List<TEntity> FindByIds( string ids ) {
            return FindByIds( Util.Helpers.Convert.ToList<TKey>( ids ) );
        }

        #endregion

        #region FindByIdsAsync(通过标识列表查找实体列表)

        /// <inheritdoc />
        public virtual async Task<List<TEntity>> FindByIdsAsync( params TKey[] ids ) {
            return await FindByIdsAsync( (IEnumerable<TKey>)ids );
        }

        /// <inheritdoc />
        public virtual async Task<List<TEntity>> FindByIdsAsync( IEnumerable<TKey> ids, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            return ids == null ? null : await Find( t => ids.Contains( t.Id ) ).ToListAsync( cancellationToken );
        }

        /// <inheritdoc />
        public virtual async Task<List<TEntity>> FindByIdsAsync( string ids, CancellationToken cancellationToken = default ) {
            return await FindByIdsAsync( Util.Helpers.Convert.ToList<TKey>( ids ), cancellationToken );
        }

        #endregion

        #region Single(查找单个实体)

        /// <inheritdoc />
        public virtual TEntity Single( Expression<Func<TEntity, bool>> condition ) {
            return Find().FirstOrDefault( condition );
        }

        /// <inheritdoc />
        public virtual TEntity Single( Expression<Func<TEntity, bool>> condition,Func<IQueryable<TEntity>, IQueryable<TEntity>> action ) {
            if ( action == null )
                return Single( condition );
            return action( Find() ).FirstOrDefault( condition );
        }

        #endregion

        #region SingleAsync(查找单个实体)

        /// <inheritdoc />
        public virtual async Task<TEntity> SingleAsync( Expression<Func<TEntity, bool>> condition, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            return await Find().FirstOrDefaultAsync( condition, cancellationToken );
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> SingleAsync( Expression<Func<TEntity, bool>> condition, Func<IQueryable<TEntity>, IQueryable<TEntity>> action, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            if ( action == null )
                return await SingleAsync( condition, cancellationToken );
            return await action( Find() ).FirstOrDefaultAsync( condition, cancellationToken );
        }

        #endregion

        #region FindAll(查找实体列表)

        /// <inheritdoc />
        public virtual List<TEntity> FindAll( Expression<Func<TEntity, bool>> condition = null ) {
            return condition == null ? Find().ToList() : Find( condition ).ToList();
        }

        #endregion

        #region FindAllAsync(查找实体列表)

        /// <inheritdoc />
        public virtual async Task<List<TEntity>> FindAllAsync( Expression<Func<TEntity, bool>> condition = null, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            if ( condition == null )
                return await Find().ToListAsync( cancellationToken );
            return await Find( condition ).ToListAsync( cancellationToken );
        }

        #endregion

        #region Exists(判断是否存在)

        /// <inheritdoc />
        public virtual bool Exists( params TKey[] ids ) {
            return ids != null && Exists( t => ids.Contains( t.Id ) );
        }

        /// <inheritdoc />
        public virtual bool Exists( Expression<Func<TEntity, bool>> condition ) {
            return condition != null && Find().Any( condition );
        }

        #endregion

        #region ExistsAsync(判断是否存在)

        /// <inheritdoc />
        public virtual async Task<bool> ExistsAsync( params TKey[] ids ) {
            return ids != null && await ExistsAsync( t => ids.Contains( t.Id ) );
        }

        /// <inheritdoc />
        public virtual async Task<bool> ExistsAsync( Expression<Func<TEntity, bool>> condition, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            return condition != null && await Find().AnyAsync( condition, cancellationToken );
        }

        #endregion

        #region Count(查找数量)

        /// <inheritdoc />
        public virtual int Count( Expression<Func<TEntity, bool>> condition = null ) {
            return condition == null ? Find().Count() : Find().Count( condition );
        }

        #endregion

        #region CountAsync(查找数量)

        /// <inheritdoc />
        public virtual async Task<int> CountAsync( Expression<Func<TEntity, bool>> condition = null, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            return condition == null
                ? await Find().CountAsync( cancellationToken )
                : await Find().CountAsync( condition, cancellationToken );
        }

        #endregion

        #region AddAsync(添加实体)

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task AddAsync( TEntity entity, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            entity.CheckNull( nameof( entity ) );
            await Set.AddAsync( entity, cancellationToken );
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task AddAsync( IEnumerable<TEntity> entities, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            entities.CheckNull( nameof( entities ) );
            await Set.AddRangeAsync( entities, cancellationToken );
        }

        #endregion

        #region UpdateAsync(修改实体)

        /// <inheritdoc />
        public virtual Task UpdateAsync( TEntity entity, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            Update( entity );
            return Task.CompletedTask;
        }

        /// <summary>
        /// 更新
        /// </summary>
        protected void Update( TEntity entity ) {
            ThrowIfDisposed();
            entity.CheckNull( nameof( entity ) );
            var entry = UnitOfWork.Entry( entity );
            ValidateVersion( entry, entity );
            UpdateEntity( entry, entity );
        }

        /// <summary>
        /// 验证版本号
        /// </summary>
        protected virtual void ValidateVersion( EntityEntry<TEntity> entry, TEntity entity ) {
            if ( entity is not IVersion current )
                return;
            if ( current.Version == null || current.Version.Length == 0 ) {
	            ThrowConcurrencyException( entity );
	            return;
            }
            var oldVersion = entry.OriginalValues.GetValue<byte[]>( "Version" );
            for ( int i = 0; i < oldVersion.Length; i++ ) {
                if ( current.Version[i] != oldVersion[i] )
					ThrowConcurrencyException( entity );
			}
        }

        /// <summary>
        /// 抛出并发异常
        /// </summary>
        private void ThrowConcurrencyException( TEntity entity ) {
	        throw new ConcurrencyException( new Exception( $"Type:{typeof( TEntity )},Id:{entity.Id}" ) );
		}

        /// <summary>
		/// 更新实体
		/// </summary>
		protected void UpdateEntity( EntityEntry<TEntity> entry, TEntity entity ) {
            var oldEntry = UnitOfWork.ChangeTracker.Entries<TEntity>().FirstOrDefault( t => t.Entity.Equals( entity ) );
            if ( oldEntry != null ) {
                oldEntry.CurrentValues.SetValues( entity );
                return;
            }
            if ( entry.State == EntityState.Detached )
                UnitOfWork.Update( entity );
        }

        /// <inheritdoc />
        public virtual Task UpdateAsync( IEnumerable<TEntity> entities, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            entities.CheckNull( nameof( entities ) );
            Update( entities );
            return Task.CompletedTask;
        }

        /// <summary>
        /// 更新实体集合
        /// </summary>
        protected void Update( IEnumerable<TEntity> entities ) {
            ThrowIfDisposed();
            entities.CheckNull( nameof( entities ) );
            foreach ( var entity in entities )
                Update( entity );
        }

        #endregion

        #region RemoveAsync(移除实体)

        /// <inheritdoc />
        public virtual async Task RemoveAsync( object id, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            var entity = await FindByIdAsync( id, cancellationToken );
            Delete( entity );
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Delete( TEntity entity ) {
            if ( entity == null )
                return;
            if ( entity is IDelete model ) {
                model.IsDeleted = true;
                return;
            }
            Set.Remove( entity );
        }

        /// <inheritdoc />
        public virtual async Task RemoveAsync( TEntity entity, CancellationToken cancellationToken = default ) {
            if ( entity == null )
                return;
            await RemoveAsync( entity.Id, cancellationToken );
        }

        /// <inheritdoc />
        public virtual async Task RemoveAsync( IEnumerable<TKey> ids, CancellationToken cancellationToken = default ) {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if ( ids == null )
                return;
            var entities = await FindByIdsAsync( ids, cancellationToken );
            Delete( entities );
        }

        /// <summary>
        /// 删除实体集合
        /// </summary>
        private void Delete( List<TEntity> list ) {
            if ( list == null )
                return;
            if ( !list.Any() )
                return;
            foreach ( var entity in list )
                Delete( entity );
        }

        /// <inheritdoc />
        public virtual async Task RemoveAsync( IEnumerable<TEntity> entities, CancellationToken cancellationToken = default ) {
            if ( entities == null )
                return;
            await RemoveAsync( entities.Select( t => t.Id ), cancellationToken );
        }

        #endregion

        #region ThrowIfDisposed(已释放则抛出异常)

        /// <summary>
        /// 已释放则抛出异常
        /// </summary>
        protected void ThrowIfDisposed() {
            if ( _disposed ) {
                throw new ObjectDisposedException( GetType().Name );
            }
        }

        #endregion

        #region Dispose(释放)

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose() {
            _disposed = true;
        }

        #endregion
    }
}
