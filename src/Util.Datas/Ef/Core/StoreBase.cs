using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Stores;
using Util.Datas.UnitOfWorks;
using Util.Domains;

namespace Util.Datas.Ef.Core {
    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    public abstract partial class StoreBase<TEntity> : StoreBase<TEntity, Guid>, IStore<TEntity>
        where TEntity : class, IKey<Guid>, IVersion {
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
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public abstract partial class StoreBase<TEntity, TKey> : QueryStoreBase<TEntity, TKey>, IStore<TEntity, TKey> where TEntity : class, IKey<TKey> {
        /// <summary>
        /// 初始化存储器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected StoreBase( IUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Add( TEntity entity ) {
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            Set.Add( entity );
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual void Add( IEnumerable<TEntity> entities ) {
            if( entities == null )
                throw new ArgumentNullException( nameof( entities ) );
            Set.AddRange( entities );
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task AddAsync( TEntity entity, CancellationToken cancellationToken = default( CancellationToken ) ) {
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            await Set.AddAsync( entity, cancellationToken );
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task AddAsync( IEnumerable<TEntity> entities, CancellationToken cancellationToken = default( CancellationToken ) ) {
            if( entities == null )
                throw new ArgumentNullException( nameof( entities ) );
            await Set.AddRangeAsync( entities, cancellationToken );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Update( TEntity entity ) {
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            UnitOfWork.Entry( entity ).State = EntityState.Detached;
            var old = Find( entity.Id );
            var oldEntry = UnitOfWork.Entry( old );
            if ( !( entity is IVersion version ) ) {
                oldEntry.CurrentValues.SetValues( entity );
                return;
            }
            oldEntry.State = EntityState.Detached;
            oldEntry.CurrentValues[nameof( version.Version )] = version.Version;
            oldEntry = UnitOfWork.Attach( old );
            oldEntry.CurrentValues.SetValues( entity );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual Task UpdateAsync( TEntity entity ) {
            Update( entity );
            return Task.CompletedTask;
        }

        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual void Update( IEnumerable<TEntity> entities ) {
            if( entities == null )
                throw new ArgumentNullException( nameof( entities ) );
            foreach( var entity in entities )
                Update( entity );
        }

        /// <summary>
        /// 修改实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual async Task UpdateAsync( IEnumerable<TEntity> entities ) {
            if( entities == null )
                throw new ArgumentNullException( nameof( entities ) );
            foreach( var entity in entities )
                await UpdateAsync( entity );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public virtual void Remove( object id ) {
            var entity = Find( id );
            Delete( entity );
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Delete( TEntity entity ) {
            if( entity == null )
                return;
            if( entity is IDelete model ) {
                model.IsDeleted = true;
                return;
            }
            Set.Remove( entity );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task RemoveAsync( object id, CancellationToken cancellationToken = default( CancellationToken ) ) {
            var entity = await FindAsync( id, cancellationToken );
            Delete( entity );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Remove( TEntity entity ) {
            if( entity == null )
                return;
            Remove( entity.Id );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task RemoveAsync( TEntity entity, CancellationToken cancellationToken = default( CancellationToken ) ) {
            if( entity == null )
                return;
            await RemoveAsync( entity.Id, cancellationToken );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">标识集合</param>
        public virtual void Remove( IEnumerable<TKey> ids ) {
            if( ids == null )
                return;
            var list = FindByIds( ids );
            Delete( list );
        }

        /// <summary>
        /// 删除实体集合
        /// </summary>
        private void Delete( List<TEntity> list ) {
            if( list == null )
                return;
            if( !list.Any() )
                return;
            if( list[0] is IDelete ) {
                foreach( var entity in list.Select( t => (IDelete)t ) )
                    entity.IsDeleted = true;
                return;
            }
            Set.RemoveRange( list );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">标识集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task RemoveAsync( IEnumerable<TKey> ids, CancellationToken cancellationToken = default( CancellationToken ) ) {
            if( ids == null )
                return;
            var entities = await FindByIdsAsync( ids, cancellationToken );
            Delete( entities );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public virtual void Remove( IEnumerable<TEntity> entities ) {
            if( entities == null )
                return;
            Remove( entities.Select( t => t.Id ) );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        public virtual async Task RemoveAsync( IEnumerable<TEntity> entities, CancellationToken cancellationToken = default( CancellationToken ) ) {
            if( entities == null )
                return;
            await RemoveAsync( entities.Select( t => t.Id ), cancellationToken );
        }
    }
}
