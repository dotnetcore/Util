using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef.Internal;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.Datas.Ef.Core {
    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, Guid>, IRepository<TEntity>
        where TEntity : class, IAggregateRoot<TEntity, Guid> {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected RepositoryBase( IUnitOfWork unitOfWork )
            : base( unitOfWork ) {
        }
    }

    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IAggregateRoot<TEntity, TKey> {
        /// <summary>
        /// 数据上下文包装器
        /// </summary>
        private readonly DbContextWrapper<TEntity, TKey> _wrapper;

        /// <summary>
        /// 工作单元
        /// </summary>
        protected UnitOfWorkBase UnitOfWork { get; }

        /// <summary>
        /// 实体集
        /// </summary>
        protected DbSet<TEntity> Set { get; }

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected RepositoryBase( IUnitOfWork unitOfWork ) {
            _wrapper = new DbContextWrapper<TEntity, TKey>( unitOfWork );
            UnitOfWork = _wrapper.UnitOfWork;
            Set = _wrapper.Set;
        }

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
            return _wrapper.Find();
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public TEntity Find( object id ) {
            return _wrapper.Find( id );
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public async Task<TEntity> FindAsync( object id ) {
            return await _wrapper.FindAsync( id );
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public List<TEntity> FindByIds( params TKey[] ids ) {
            return _wrapper.FindByIds( ids );
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public List<TEntity> FindByIds( IEnumerable<TKey> ids ) {
            return _wrapper.FindByIds( ids );
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public async Task<List<TEntity>> FindByIdsAsync( params TKey[] ids ) {
            return await _wrapper.FindByIdsAsync( ids );
        }

        /// <summary>
        /// 查找实体集合
        /// </summary>
        /// <param name="ids">实体标识集合</param>
        public async Task<List<TEntity>> FindByIdsAsync( IEnumerable<TKey> ids ) {
            return await _wrapper.FindByIdsAsync( ids );
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">条件</param>
        public TEntity Single( Expression<Func<TEntity, bool>> predicate ) {
            return _wrapper.Single( predicate );
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        public async Task<TEntity> SingleAsync( Expression<Func<TEntity, bool>> predicate ) {
            return await _wrapper.SingleAsync( predicate );
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Add( TEntity entity ) {
            _wrapper.Add( entity );
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void Add( IEnumerable<TEntity> entities ) {
            _wrapper.Add( entities );
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task AddAsync( TEntity entity ) {
            await _wrapper.AddAsync( entity );
        }

        /// <summary>
        /// 添加实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public async Task AddAsync( IEnumerable<TEntity> entities ) {
            await _wrapper.AddAsync( entities );
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Update( TEntity entity ) {
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            var oldEntity = Find( entity.Id );
            _wrapper.Update( entity, oldEntity );
        }

        /// <summary>
        /// 异步修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task UpdateAsync( TEntity entity ) {
            if( entity == null )
                throw new ArgumentNullException( nameof( entity ) );
            var oldEntity = await _wrapper.FindAsync( entity.Id );
            _wrapper.Update( entity, oldEntity );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public void Remove( TKey id ) {
            _wrapper.Remove( id );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public async Task RemoveAsync( TKey id ) {
            await _wrapper.RemoveAsync( id );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Remove( TEntity entity ) {
            _wrapper.Remove( entity );
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public async Task RemoveAsync( TEntity entity ) {
            await _wrapper.RemoveAsync( entity );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        public void Remove( IEnumerable<TKey> ids ) {
            _wrapper.Remove( ids );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="ids">实体编号集合</param>
        public async Task RemoveAsync( IEnumerable<TKey> ids ) {
            await _wrapper.RemoveAsync( ids );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void Remove( IEnumerable<TEntity> entities ) {
            _wrapper.Remove( entities );
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public async Task RemoveAsync( IEnumerable<TEntity> entities ) {
            await _wrapper.RemoveAsync( entities );
        }
    }
}
