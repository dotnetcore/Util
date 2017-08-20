using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef.Internal;
using Util.Datas.Persistence;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace Util.Datas.Ef.Core {
    /// <summary>
    /// 持久化存储
    /// </summary>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    public abstract class PersistentStoreBase<TPo> : PersistentStoreBase<TPo, Guid> where TPo : class, IPersistentObject<Guid> {
        /// <summary>
        /// 初始化持久化存储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected PersistentStoreBase( IUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }

    /// <summary>
    /// 持久化存储
    /// </summary>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    /// <typeparam name="TKey">持久化对象标识类型</typeparam>
    public abstract class PersistentStoreBase<TPo, TKey> : IPersistentStore<TPo, TKey> where TPo : class, IPersistentObject<TKey> {
        /// <summary>
        /// 数据上下文包装器
        /// </summary>
        private readonly DbContextWrapper<TPo, TKey> _wrapper;

        /// <summary>
        /// 工作单元
        /// </summary>
        protected UnitOfWorkBase UnitOfWork { get; }

        /// <summary>
        /// 实体集
        /// </summary>
        protected DbSet<TPo> Set { get; }

        /// <summary>
        /// 初始化持久化存储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected PersistentStoreBase( IUnitOfWork unitOfWork ) {
            _wrapper = new DbContextWrapper<TPo, TKey>( unitOfWork );
            UnitOfWork = _wrapper.UnitOfWork;
            Set = _wrapper.Set;
        }

        /// <summary>
        /// 获取未跟踪的持久化对象集合
        /// </summary>
        public IQueryable<TPo> FindAsNoTracking() {
            return Set.AsNoTracking();
        }

        /// <summary>
        /// 查找持久化对象集合
        /// </summary>
        public IQueryable<TPo> Find() {
            return _wrapper.Find();
        }

        /// <summary>
        /// 查找持久化对象集合
        /// </summary>
        /// <param name="criteria">条件</param>
        public IQueryable<TPo> Find( ICriteria<TPo> criteria ) {
            return Find().Where( criteria );
        }

        /// <summary>
        /// 查找持久化对象
        /// </summary>
        /// <param name="id">持久化对象标识</param>
        public TPo Find( object id ) {
            return _wrapper.Find( id );
        }

        /// <summary>
        /// 查找持久化对象
        /// </summary>
        /// <param name="id">持久化对象标识</param>
        public async Task<TPo> FindAsync( object id ) {
            return await _wrapper.FindAsync( id );
        }

        /// <summary>
        /// 查找持久化对象集合
        /// </summary>
        /// <param name="ids">持久化对象标识集合</param>
        public List<TPo> FindByIds( params TKey[] ids ) {
            return _wrapper.FindByIds( ids );
        }

        /// <summary>
        /// 查找持久化对象集合
        /// </summary>
        /// <param name="ids">持久化对象标识集合</param>
        public List<TPo> FindByIds( IEnumerable<TKey> ids ) {
            return _wrapper.FindByIds( ids );
        }

        /// <summary>
        /// 查找持久化对象集合
        /// </summary>
        /// <param name="ids">持久化对象标识集合</param>
        public async Task<List<TPo>> FindByIdsAsync( params TKey[] ids ) {
            return await _wrapper.FindByIdsAsync( ids );
        }

        /// <summary>
        /// 查找持久化对象集合
        /// </summary>
        /// <param name="ids">持久化对象标识集合</param>
        public async Task<List<TPo>> FindByIdsAsync( IEnumerable<TKey> ids ) {
            return await _wrapper.FindByIdsAsync( ids );
        }

        /// <summary>
        /// 获取单个持久化对象
        /// </summary>
        /// <param name="predicate">查询条件</param>
        public TPo Single( Expression<Func<TPo, bool>> predicate ) {
            return _wrapper.Single( predicate );
        }

        /// <summary>
        /// 获取单个持久化对象
        /// </summary>
        /// <param name="predicate">查询条件</param>
        public async Task<TPo> SingleAsync( Expression<Func<TPo, bool>> predicate ) {
            return await _wrapper.SingleAsync( predicate );
        }

        /// <summary>
        /// 判断持久化对象是否存在
        /// </summary>
        /// <param name="ids">持久化对象标识集合，均不存在返回true</param>
        public bool Exists( params TKey[] ids ) {
            if( ids == null )
                return false;
            return Find().Any( t => ids.Contains( t.Id ) );
        }

        /// <summary>
        /// 判断持久化对象是否存在
        /// </summary>
        /// <param name="ids">持久化对象标识集合，均不存在返回true</param>
        public async Task<bool> ExistsAsync( params TKey[] ids ) {
            if( ids == null )
                return false;
            return await Find().AnyAsync( t => ids.Contains( t.Id ) );
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public List<TPo> Query( IQueryBase<TPo> query ) {
            return _wrapper.Query( query );
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public async Task<List<TPo>> QueryAsync( IQueryBase<TPo> query ) {
            return await _wrapper.QueryAsync( query );
        }

        /// <summary>
        /// 查询 - 返回未跟踪的持久化对象
        /// </summary>
        /// <param name="query">查询对象</param>
        public List<TPo> QueryAsNoTracking( IQueryBase<TPo> query ) {
            return _wrapper.QueryAsNoTracking( query );
        }

        /// <summary>
        /// 查询 - 返回未跟踪的持久化对象
        /// </summary>
        /// <param name="query">查询对象</param>
        public async Task<List<TPo>> QueryAsNoTrackingAsync( IQueryBase<TPo> query ) {
            return await _wrapper.QueryAsNoTrackingAsync( query );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public PagerList<TPo> PagerQuery( IQueryBase<TPo> query ) {
            return _wrapper.PagerQuery( query );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public async Task<PagerList<TPo>> PagerQueryAsync( IQueryBase<TPo> query ) {
            return await _wrapper.PagerQueryAsync( query );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public PagerList<TPo> PagerQueryAsNoTracking( IQueryBase<TPo> query ) {
            return _wrapper.PagerQueryAsNoTracking( query );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        public async Task<PagerList<TPo>> PagerQueryAsNoTrackingAsync( IQueryBase<TPo> query ) {
            return await _wrapper.PagerQueryAsNoTrackingAsync( query );
        }

        /// <summary>
        /// 添加持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        public void Add( TPo po ) {
            _wrapper.Add( po );
        }

        /// <summary>
        /// 添加持久化对象集合
        /// </summary>
        /// <param name="pos">持久化对象集合</param>
        public void Add( IEnumerable<TPo> pos ) {
            _wrapper.Add( pos );
        }

        /// <summary>
        /// 添加持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        public async Task AddAsync( TPo po ) {
            await _wrapper.AddAsync( po );
        }

        /// <summary>
        /// 添加持久化对象集合
        /// </summary>
        /// <param name="pos">持久化对象集合</param>
        public async Task AddAsync( IEnumerable<TPo> pos ) {
            await _wrapper.AddAsync( pos );
        }

        /// <summary>
        /// 修改持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        public void Update( TPo po ) {
            if( po == null )
                throw new ArgumentNullException( nameof( po ) );
            var old = Find( po.Id );
            _wrapper.Update( po, old );
        }

        /// <summary>
        /// 修改持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        public async Task UpdateAsync( TPo po ) {
            if( po == null )
                throw new ArgumentNullException( nameof( po ) );
            var old = await FindAsync( po.Id );
            _wrapper.Update( po, old );
        }

        /// <summary>
        /// 移除持久化对象
        /// </summary>
        /// <param name="id">持久化对象标识</param>
        public void Remove( TKey id ) {
            _wrapper.Remove( id );
        }

        /// <summary>
        /// 移除持久化对象
        /// </summary>
        /// <param name="id">持久化对象标识</param>
        public async Task RemoveAsync( TKey id ) {
            await _wrapper.RemoveAsync( id );
        }

        /// <summary>
        /// 移除持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        public void Remove( TPo po ) {
            _wrapper.Remove( po );
        }

        /// <summary>
        /// 移除持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        public async Task RemoveAsync( TPo po ) {
            await _wrapper.RemoveAsync( po );
        }

        /// <summary>
        /// 移除持久化对象集合
        /// </summary>
        /// <param name="ids">持久化对象编号集合</param>
        public void Remove( IEnumerable<TKey> ids ) {
            _wrapper.Remove( ids );
        }

        /// <summary>
        /// 移除持久化对象集合
        /// </summary>
        /// <param name="ids">持久化对象编号集合</param>
        public async Task RemoveAsync( IEnumerable<TKey> ids ) {
            await _wrapper.RemoveAsync( ids );
        }

        /// <summary>
        /// 移除持久化对象集合
        /// </summary>
        /// <param name="pos">持久化对象集合</param>
        public void Remove( IEnumerable<TPo> pos ) {
            _wrapper.Remove( pos );
        }

        /// <summary>
        /// 移除持久化对象集合
        /// </summary>
        /// <param name="pos">持久化对象集合</param>
        public async Task RemoveAsync( IEnumerable<TPo> pos ) {
            await _wrapper.RemoveAsync( pos );
        }
    }
}
