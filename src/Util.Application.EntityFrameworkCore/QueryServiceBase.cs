using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Data;
using Util.Data.EntityFrameworkCore;
using Util.Data.Queries;
using Util.Data.Stores;
using Util.Domain;

namespace Util.Applications {
    /// <summary>
    /// 查询服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class QueryServiceBase<TEntity, TDto, TQuery> : QueryServiceBase<TEntity, TDto, TQuery, Guid>
        where TEntity : class, IKey<Guid>
        where TDto : new()
        where TQuery : IPage {
        /// <summary>
        /// 初始化查询服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="store">查询存储器</param>
        protected QueryServiceBase( IServiceProvider serviceProvider, IQueryStore<TEntity, Guid> store ) : base( serviceProvider,store ) {
        }
    }

    /// <summary>
    /// 查询服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class QueryServiceBase<TEntity, TDto, TQuery, TKey> : ServiceBase, IQueryService<TDto, TQuery>
        where TEntity : class, IKey<TKey>
        where TDto : new()
        where TQuery : IPage {

        #region 字段

        /// <summary>
        /// 查询存储器
        /// </summary>
        private readonly IQueryStore<TEntity, TKey> _store;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化查询服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="store">查询存储器</param>
        protected QueryServiceBase( IServiceProvider serviceProvider,IQueryStore<TEntity, TKey> store ) : base( serviceProvider ) {
            _store = store ?? throw new ArgumentNullException( nameof( store ) );
        }

        #endregion

        #region 属性

        /// <summary>
        /// 查询时是否跟踪实体
        /// </summary>
        protected virtual bool IsTracking => false;

        #endregion

        #region ToDto(转换)

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual TDto ToDto( TEntity entity ) {
            return entity.MapTo<TDto>();
        }

        #endregion

        #region GetAllAsync(获取全部实体)

        /// <inheritdoc />
        public virtual async Task<List<TDto>> GetAllAsync() {
            var entities = await GetStore().FindAllAsync();
            return entities.Select( ToDto ).ToList();
        }

        /// <summary>
        /// 获取查询存储器
        /// </summary>
        private IQueryStore<TEntity, TKey> GetStore() {
            if( IsTracking )
                return _store;
            return _store.NoTracking();
        }

        #endregion

        #region GetByIdAsync(通过标识获取实体)

        /// <inheritdoc />
        public virtual async Task<TDto> GetByIdAsync( object id ) {
            var key = Util.Helpers.Convert.To<TKey>( id );
            return ToDto( await GetStore().FindByIdAsync( key ) );
        }

        #endregion

        #region GetByIdsAsync(通过标识列表获取实体列表)

        /// <inheritdoc />
        public virtual async Task<List<TDto>> GetByIdsAsync( string ids ) {
            var entities = await GetStore().FindByIdsAsync( ids );
            return entities.Select( ToDto ).ToList();
        }

        #endregion

        #region QueryAsync(查询)

        /// <inheritdoc />
        public virtual async Task<List<TDto>> QueryAsync( TQuery query ) {
            if( query == null )
                return new List<TDto>();
            var queryable = GetStore().Find();
            queryable = Filter( queryable, query );
            var result = await queryable.OrderBy( query ).ToListAsync();
            return result.Select( ToDto ).ToList();
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected virtual IQueryable<TEntity> Filter( IQueryable<TEntity> queryable, TQuery query ) {
            return queryable;
        }

        #endregion

        #region PageQueryAsync(分页查询)

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询参数</param>
        public async Task<PageList<TDto>> PageQueryAsync( TQuery query ) {
            if( query == null )
                return new PageList<TDto>();
            var queryable = GetStore().Find();
            queryable = Filter( queryable, query );
            var result = await queryable.ToPageListAsync( query );
            return result.Convert( ToDto );
        }

        #endregion
    }
}
