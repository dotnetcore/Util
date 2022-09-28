using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Applications.Dtos;
using Util.Data;
using Util.Data.Queries;
using Util.Domain.Entities;
using Util.Domain.Repositories;
using Util.Helpers;
using Util.Properties;

namespace Util.Applications {
    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class CrudServiceBase<TEntity, TDto, TQuery> : CrudServiceBase<TEntity, TDto, TQuery, Guid>
        where TEntity : class, IAggregateRoot<TEntity, Guid>, new()
        where TDto : IDto, new()
        where TQuery : IPage {
        /// <summary>
        /// 初始化增删改查服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected CrudServiceBase( IServiceProvider serviceProvider, IUnitOfWork unitOfWork, IRepository<TEntity> repository ) : base( serviceProvider, unitOfWork, repository ) {
        }
    }

    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class CrudServiceBase<TEntity, TDto, TQuery, TKey>
        : CrudServiceBase<TEntity, TDto, TDto, TDto, TQuery, TKey>, ICrudService<TDto, TQuery>
        where TEntity : class, IAggregateRoot<TEntity, TKey>, new()
        where TDto : IDto, new()
        where TQuery : IPage {
        /// <summary>
        /// 初始化增删改查服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected CrudServiceBase( IServiceProvider serviceProvider, IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository ) : base( serviceProvider, unitOfWork, repository ) {
        }
    }

    /// <summary>
    /// 增删改查服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class CrudServiceBase<TEntity, TDto, TCreateRequest, TUpdateRequest, TQuery, TKey>
        : QueryServiceBase<TEntity, TDto, TQuery, TKey>, ICrudService<TDto, TCreateRequest, TUpdateRequest, TQuery>
        where TEntity : class, IAggregateRoot<TEntity, TKey>, new()
        where TDto : IDto, new()
        where TCreateRequest : IRequest, new()
        where TUpdateRequest : IDto, new()
        where TQuery : IPage {

        #region 字段

        /// <summary>
        /// 仓储
        /// </summary>
        private readonly IRepository<TEntity, TKey> _repository;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化增删改查服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected CrudServiceBase( IServiceProvider serviceProvider, IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository ) : base( serviceProvider, repository ) {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException( nameof( unitOfWork ) );
            _repository = repository ?? throw new ArgumentNullException( nameof( repository ) );
            EntityDescription = Reflection.GetDisplayNameOrDescription<TEntity>();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 工作单元
        /// </summary>
        protected IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 实体描述
        /// </summary>
        protected string EntityDescription { get; }

        #endregion

        #region CreateAsync(创建)

        /// <inheritdoc />
        public virtual async Task<string> CreateAsync( TCreateRequest request ) {
            request.CheckNull( nameof( request ) );
            var entity = ToEntity( request );
            entity.CheckNull( nameof( entity ) );
            entity.Init();
            await CreateBeforeAsync( entity );
            await _repository.AddAsync( entity );
            await CommitAsync();
            await CreateAfterAsync( entity );
            return entity.Id.ToString();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="request">创建参数</param>
        protected virtual TEntity ToEntity( TCreateRequest request ) {
            return request.MapTo<TEntity>();
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        protected virtual Task CreateBeforeAsync( TEntity entity ) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 创建后操作
        /// </summary>
        protected virtual Task CreateAfterAsync( TEntity entity ) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 提交工作单元
        /// </summary>
        protected virtual async Task CommitAsync() {
            await UnitOfWork.CommitAsync();
        }

        #endregion

        #region UpdateAsync(修改)

        /// <inheritdoc />
        public virtual async Task UpdateAsync( TUpdateRequest request ) {
            request.CheckNull( nameof( request ) );
            if( request.Id.IsEmpty() )
                throw new InvalidOperationException( R.IdIsEmpty );
            var oldEntity = await FindOldEntityAsync( request.Id );
            oldEntity.CheckNull( nameof( oldEntity ) );
            var entity = ToEntity( oldEntity, request );
            entity.CheckNull( nameof( entity ) );
            await UpdateBeforeAsync( entity );
            await _repository.UpdateAsync( entity );
            await CommitAsync();
            await UpdateAfterAsync( entity );
        }

        /// <summary>
        /// 查找旧实体
        /// </summary>
        /// <param name="id">标识</param>
        protected async Task<TEntity> FindOldEntityAsync( string id ) {
            return await _repository.FindByIdAsync( id );
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="oldEntity">旧实体</param>
        /// <param name="request">修改参数</param>
        protected virtual TEntity ToEntity( TEntity oldEntity, TUpdateRequest request ) {
            return request.MapTo( oldEntity );
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual Task UpdateBeforeAsync( TEntity entity ) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 修改后操作
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual Task UpdateAfterAsync( TEntity entity ) {
            return Task.CompletedTask;
        }

        #endregion

        #region DeleteAsync(删除)

        /// <inheritdoc />
        public virtual async Task DeleteAsync( string ids ) {
            if( ids.IsEmpty() )
                return;
            var entities = await _repository.FindByIdsAsync( ids );
            if( entities?.Count == 0 )
                return;
            await DeleteBeforeAsync( entities );
            await _repository.RemoveAsync( entities );
            await CommitAsync();
            await DeleteAfterAsync( entities );
        }

        /// <summary>
        /// 删除前操作
        /// </summary>
        /// <param name="entities">实体列表</param>
        protected virtual Task DeleteBeforeAsync( List<TEntity> entities ) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 删除后操作
        /// </summary>
        /// <param name="entities">实体集合</param>
        protected virtual Task DeleteAfterAsync( List<TEntity> entities ) {
            return Task.CompletedTask;
        }

        #endregion
    }
}
