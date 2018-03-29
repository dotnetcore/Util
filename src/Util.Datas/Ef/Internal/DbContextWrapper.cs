using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef.Core;
using Util.Datas.Queries;
using Util.Datas.UnitOfWorks;
using Util.Domains;
using Util.Domains.Repositories;
using Util.Exceptions;

namespace Util.Datas.Ef.Internal {
    /// <summary>
    /// 数据上下文包装器
    /// </summary>
    internal class DbContextWrapper<TEntity, TKey> where TEntity : class, IKey<TKey>, IVersion {
        /// <summary>
        /// 初始化数据上下文包装器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DbContextWrapper( IUnitOfWork unitOfWork ) {
            UnitOfWork = (UnitOfWorkBase)unitOfWork;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public UnitOfWorkBase UnitOfWork { get; }

        /// <summary>
        /// 实体集
        /// </summary>
        public DbSet<TEntity> Set => UnitOfWork.Set<TEntity>();

        /// <summary>
        /// 获取未跟踪的实体集
        /// </summary>
        public IQueryable<TEntity> FindAsNoTracking() {
            return Set.AsNoTracking();
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        public IQueryable<TEntity> Find() {
            return Set;
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public TEntity Find( object id ) {
            if( id == null )
                return null;
            return Set.Find( id );
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<TEntity> FindAsync( object id, CancellationToken cancellationToken = default( CancellationToken ) ) {
            if( id == null )
                return null;
            return await Set.FindAsync( new [] { id }, cancellationToken );
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public List<TEntity> FindByIds( params TKey[] ids ) {
            return FindByIds( (IEnumerable<TKey>)ids );
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public List<TEntity> FindByIds( IEnumerable<TKey> ids ) {
            if( ids == null )
                return null;
            return Find().Where( t => ids.Contains( t.Id ) ).ToList();
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public async Task<List<TEntity>> FindByIdsAsync( params TKey[] ids ) {
            return await FindByIdsAsync( (IEnumerable<TKey>)ids );
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public async Task<List<TEntity>> FindByIdsAsync( IEnumerable<TKey> ids ) {
            if( ids == null )
                return null;
            return await Find().Where( t => ids.Contains( t.Id ) ).ToListAsync();
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">条件</param>
        public TEntity Single( Expression<Func<TEntity, bool>> predicate ) {
            return Find().FirstOrDefault( predicate );
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<TEntity> SingleAsync( Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default( CancellationToken ) ) {
            return await Find().FirstOrDefaultAsync( predicate, cancellationToken );
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public List<TEntity> Query( IQueryBase<TEntity> query ) {
            return GetQueryResult( Find(), query ).ToList();
        }

        /// <summary>
        /// 获取查询结果
        /// </summary>
        private IQueryable<TEntity> GetQueryResult( IQueryable<TEntity> queryable, IQueryBase<TEntity> query ) {
            queryable = queryable.Where( query );
            var order = query.GetOrder();
            if( string.IsNullOrWhiteSpace( order ) )
                return queryable;
            return queryable.OrderBy( order );
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public async Task<List<TEntity>> QueryAsync( IQueryBase<TEntity> query ) {
            return await GetQueryResult( Find(), query ).ToListAsync();
        }

        /// <summary>
        /// 查询 - 返回未跟踪的实体
        /// </summary>
        /// <param name="query">查询对象</param>
        public List<TEntity> QueryAsNoTracking( IQueryBase<TEntity> query ) {
            return GetQueryResult( FindAsNoTracking(), query ).ToList();
        }

        /// <summary>
        /// 查询 - 返回未跟踪的实体
        /// </summary>
        /// <param name="query">查询对象</param>
        public async Task<List<TEntity>> QueryAsNoTrackingAsync( IQueryBase<TEntity> query ) {
            return await GetQueryResult( FindAsNoTracking(), query ).ToListAsync();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public PagerList<TEntity> PagerQuery( IQueryBase<TEntity> query ) {
            var pager = query.GetPager();
            return GetPagerQueryResult( Find(), query, pager ).ToPagerList( pager );
        }

        /// <summary>
        /// 获取分页查询结果
        /// </summary>
        private IQueryable<TEntity> GetPagerQueryResult( IQueryable<TEntity> queryable, IQueryBase<TEntity> query, IPager pager ) {
            var order = pager.Order;
            if( string.IsNullOrWhiteSpace( order ) )
                order = "Id";
            return queryable.Where( query ).OrderBy( order ).Pager( pager );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public async Task<PagerList<TEntity>> PagerQueryAsync( IQueryBase<TEntity> query ) {
            var pager = query.GetPager();
            return await GetPagerQueryResult( Find(), query, pager ).ToPagerListAsync( pager );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public PagerList<TEntity> PagerQueryAsNoTracking( IQueryBase<TEntity> query ) {
            var pager = query.GetPager();
            return GetPagerQueryResult( FindAsNoTracking(), query, pager ).ToPagerList( pager );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public async Task<PagerList<TEntity>> PagerQueryAsNoTrackingAsync( IQueryBase<TEntity> query ) {
            var pager = query.GetPager();
            return await GetPagerQueryResult( FindAsNoTracking(), query, pager ).ToPagerListAsync( pager );
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Add( TEntity entity ) {
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            Set.Add( entity );
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void Add( IEnumerable<TEntity> entities ) {
            if( entities == null )
                throw new ArgumentNullException( nameof( entities ) );
            Set.AddRange( entities );
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task AddAsync( TEntity entity ) {
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            await Set.AddAsync( entity );
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public async Task AddAsync( IEnumerable<TEntity> entities ) {
            if( entities == null )
                throw new ArgumentNullException( nameof( entities ) );
            await Set.AddRangeAsync( entities );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public virtual void Update( TEntity entity ) {
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            UnitOfWork.Entry( entity ).State = EntityState.Modified;
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="newEntity">新实体</param>
        /// <param name="oldEntity">数据库中旧的实体</param>
        public void Update( TEntity newEntity, TEntity oldEntity ) {
            if( newEntity == null )
                throw new ArgumentNullException( nameof( newEntity ) );
            if( oldEntity == null )
                throw new ArgumentNullException( nameof( oldEntity ) );
            ValidateVersion( newEntity, oldEntity );
            UnitOfWork.Entry( oldEntity ).CurrentValues.SetValues( newEntity );
        }

        //验证版本号
        private void ValidateVersion( TEntity newEntity, TEntity oldEntity ) {
            if( newEntity.Version == null )
                throw new ConcurrencyException();
            for( int i = 0; i < oldEntity.Version.Length; i++ ) {
                if( newEntity.Version[i] != oldEntity.Version[i] )
                    throw new ConcurrencyException();
            }
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public void Remove( TKey id ) {
            var entity = Find( id );
            Delete( entity );
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Delete( TEntity entity ) {
            if ( entity == null )
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
        /// <param name="id">实体标识</param>
        public async Task RemoveAsync( TKey id ) {
            var entity = await FindAsync( id );
            Delete( entity );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        public void Remove( TEntity entity ) {
            if( entity == null )
                return;
            Remove( entity.Id );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task RemoveAsync( TEntity entity ) {
            if( entity == null )
                return;
            await RemoveAsync( entity.Id );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        public void Remove( IEnumerable<TKey> ids ) {
            if( ids == null )
                return;
            var list = FindByIds( ids );
            Delete( list );
        }

        /// <summary>
        /// 删除实体集合
        /// </summary>
        private void Delete( List<TEntity> list ) {
            if ( list == null )
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
        /// <param name="ids">实体编号集合</param>
        public async Task RemoveAsync( IEnumerable<TKey> ids ) {
            if( ids == null )
                return;
            var list = await FindByIdsAsync( ids );
            Delete( list );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void Remove( IEnumerable<TEntity> entities ) {
            if( entities == null )
                return;
            Remove( entities.Select( t => t.Id ) );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public async Task RemoveAsync( IEnumerable<TEntity> entities ) {
            if( entities == null )
                return;
            await RemoveAsync( entities.Select( t => t.Id ) );
        }
    }
}
