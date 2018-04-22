using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Datas.Queries;
using Util.Domains;
using Util.Domains.Repositories;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Util.Applications.Dtos;
using Util.Datas.Ef;
using Util.Maps;

namespace Util.Applications {
    /// <summary>
    /// 查询服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public abstract class QueryServiceBase<TEntity, TDto, TQueryParameter> : QueryServiceBase<TEntity, TDto, TQueryParameter, Guid>
        where TEntity : class, IAggregateRoot<TEntity, Guid>
        where TDto : IResponse, new()
        where TQueryParameter : IQueryParameter {
        /// <summary>
        /// 初始化查询服务
        /// </summary>
        /// <param name="repository">仓储</param>
        protected QueryServiceBase( IRepository<TEntity, Guid> repository )
            : base( repository ) {
        }
    }

    /// <summary>
    /// 查询服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class QueryServiceBase<TEntity, TDto, TQueryParameter, TKey> : ServiceBase, IQueryService<TDto, TQueryParameter>
        where TEntity : class, IAggregateRoot<TEntity, TKey>
        where TDto : IResponse, new()
        where TQueryParameter : IQueryParameter {
        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IRepository<TEntity, TKey> _repository;

        /// <summary>
        /// 初始化查询服务
        /// </summary>
        /// <param name="repository">仓储</param>
        protected QueryServiceBase( IRepository<TEntity, TKey> repository ) {
            _repository = repository ?? throw new ArgumentNullException( nameof( repository ) );
        }

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual TDto ToDto( TEntity entity ) {
            return entity.MapTo<TDto>();
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        public List<TDto> GetAll() {
            return _repository.FindAll().Select( ToDto ).ToList();
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        public async Task<List<TDto>> GetAllAsync() {
            var entities = await _repository.FindAllAsync();
            return entities.Select( ToDto ).ToList();
        }

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        public TDto GetById( object id ) {
            var key = Util.Helpers.Convert.To<TKey>( id );
            return ToDto( _repository.Find( key ) );
        }

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        public async Task<TDto> GetByIdAsync( object id ) {
            var key = Util.Helpers.Convert.To<TKey>( id );
            return ToDto( await _repository.FindAsync( key ) );
        }

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public List<TDto> GetByIds( string ids ) {
            return _repository.FindByIds( ids ).Select( ToDto ).ToList();
        }

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        public async Task<List<TDto>> GetByIdsAsync( string ids ) {
            var entities = await _repository.FindByIdsAsync( ids );
            return entities.Select( ToDto ).ToList();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<List<TDto>> QueryAsync( TQueryParameter parameter ) {
            if( parameter == null )
                return new List<TDto>();
            return ( await ExecuteQuery( parameter ).ToListAsync() ).Select( ToDto ).ToList();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public List<TDto> Query( TQueryParameter parameter ) {
            if( parameter == null )
                return new List<TDto>();
            return ExecuteQuery( parameter ).ToList().Select( ToDto ).ToList();
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        private IQueryable<TEntity> ExecuteQuery( TQueryParameter parameter ) {
            var query = CreateQuery( parameter );
            var queryable = Filter( query );
            queryable = Filter( queryable, parameter );
            var order = query.GetOrder();
            return string.IsNullOrWhiteSpace( order ) ? queryable : queryable.OrderBy( order );
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="parameter">查询参数</param>
        protected abstract IQueryBase<TEntity> CreateQuery( TQueryParameter parameter );

        /// <summary>
        /// 过滤
        /// </summary>
        private IQueryable<TEntity> Filter( IQueryBase<TEntity> query ) {
            return IsTracking ? _repository.Find().Where( query ) : _repository.FindAsNoTracking().Where( query );
        }

        /// <summary>
        /// 查询时是否跟踪对象
        /// </summary>
        protected virtual bool IsTracking => false;

        /// <summary>
        /// 过滤
        /// </summary>
        protected virtual IQueryable<TEntity> Filter( IQueryable<TEntity> queryable, TQueryParameter parameter ) {
            return queryable;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public PagerList<TDto> PagerQuery( TQueryParameter parameter ) {
            if( parameter == null )
                return new PagerList<TDto>();
            var query = CreateQuery( parameter );
            var queryable = Filter( query );
            queryable = Filter( queryable, parameter );
            return queryable.ToPagerList( query.GetPager() ).Convert( ToDto );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public async Task<PagerList<TDto>> PagerQueryAsync( TQueryParameter parameter ) {
            if( parameter == null )
                return new PagerList<TDto>();
            var query = CreateQuery( parameter );
            var queryable = Filter( query );
            queryable = Filter( queryable, parameter );
            return ( await queryable.ToPagerListAsync( query.GetPager() ) ).Convert( ToDto );
        }
    }
}
