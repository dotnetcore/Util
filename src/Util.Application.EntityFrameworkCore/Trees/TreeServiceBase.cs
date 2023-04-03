using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Applications.Dtos;
using Util.Data;
using Util.Data.Trees;
using Util.Domain;
using Util.Domain.Compare;
using Util.Domain.Trees;
using Util.Properties;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeServiceBase<TEntity, TDto, TQuery>
        : TreeServiceBase<TEntity, TDto, TDto, TDto, TQuery, Guid, Guid?>
        where TEntity : class, ITreeEntity<TEntity, Guid, Guid?>, new()
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 初始化树形服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">树形仓储</param>
        protected TreeServiceBase( IServiceProvider serviceProvider, IUnitOfWork unitOfWork, ITreeRepository<TEntity, Guid, Guid?> repository ) : base( serviceProvider, unitOfWork, repository ) {
        }
    }

    /// <summary>
    /// 树形服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeServiceBase<TEntity, TDto, TCreateRequest, TUpdateRequest, TQuery>
        : TreeServiceBase<TEntity, TDto, TCreateRequest, TUpdateRequest, TQuery, Guid, Guid?>
        where TEntity : class, ITreeEntity<TEntity, Guid, Guid?>, new()
        where TDto : class, ITreeNode, new()
        where TCreateRequest : class, IRequest, new()
        where TUpdateRequest : class, IDto, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 初始化树形服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">树形仓储</param>
        protected TreeServiceBase( IServiceProvider serviceProvider, IUnitOfWork unitOfWork, ITreeRepository<TEntity, Guid, Guid?> repository ) : base( serviceProvider, unitOfWork, repository ) {
        }
    }

    /// <summary>
    /// 树形服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TCreateRequest">创建参数类型</typeparam>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class TreeServiceBase<TEntity, TDto, TCreateRequest, TUpdateRequest, TQuery, TKey, TParentId>
        : TreeQueryServiceBase<TEntity, TDto, TQuery, TKey, TParentId>, ITreeService<TDto, TCreateRequest, TUpdateRequest,TQuery>
        where TEntity : class, ITreeEntity<TEntity, TKey, TParentId>, new()
        where TDto : class, ITreeNode, new()
        where TCreateRequest : class,IRequest, new()
        where TUpdateRequest : class, IDto, new()
        where TQuery : class, ITreeQueryParameter {

        #region 字段

        /// <summary>
        /// 树形仓储
        /// </summary>
        private readonly ITreeRepository<TEntity, TKey, TParentId> _repository;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化树形服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">树形仓储</param>
        protected TreeServiceBase( IServiceProvider serviceProvider, IUnitOfWork unitOfWork, ITreeRepository<TEntity, TKey, TParentId> repository ) : base( serviceProvider, repository ) {
            UnitOfWork = unitOfWork;
            _repository = repository;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 工作单元
        /// </summary>
        protected IUnitOfWork UnitOfWork { get; }

        #endregion

        #region CreateAsync(创建)

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        public virtual async Task<string> CreateAsync( TCreateRequest request ) {
            var entity = ToEntity( request );
            entity.CheckNull( nameof( entity ) );
            await CreateAsync( entity );
            await CommitAsync();
            await CreateCommitAfterAsync( entity );
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
        /// 创建实体
        /// </summary>
        private async Task CreateAsync( TEntity entity ) {
            await CreateBeforeAsync( entity );
            entity.Init();
            var parent = await _repository.FindByIdAsync( entity.ParentId );
            entity.InitPath( parent );
            await _repository.AddAsync( entity );
            await CreateAfterAsync( entity );
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual Task CreateBeforeAsync( TEntity entity ) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 创建后操作
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual Task CreateAfterAsync( TEntity entity ) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 提交工作单元
        /// </summary>
        protected virtual async Task CommitAsync() {
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 创建提交后操作
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual Task CreateCommitAfterAsync( TEntity entity ) {
            return Task.CompletedTask;
        }

        #endregion

        #region UpdateAsync(修改)

        /// <inheritdoc />
        public virtual async Task UpdateAsync( TUpdateRequest request ) {
            if ( request.Id.IsEmpty() )
                throw new InvalidOperationException( R.IdIsEmpty );
            var oldEntity = await FindOldEntityAsync( request.Id );
            oldEntity.CheckNull( nameof( oldEntity ) );
            var entity = ToEntity( oldEntity.Clone(), request );
            entity.CheckNull( nameof( entity ) );
            var changes = oldEntity.GetChanges( entity );
            await UpdateAsync( entity );
            await CommitAsync();
            await UpdateCommitAfterAsync( entity, changes );
        }

        /// <summary>
        /// 查找旧实体
        /// </summary>
        /// <param name="id">标识</param>
        private async Task<TEntity> FindOldEntityAsync( object id ) {
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
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        private async Task UpdateAsync( TEntity entity ) {
            await UpdateBeforeAsync( entity );
            await _repository.UpdatePathAsync( entity );
            await _repository.UpdateAsync( entity );
            await UpdateAfterAsync( entity );
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

        /// <summary>
        /// 修改提交后操作
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="changeValues">变更值集合</param>
        protected virtual Task UpdateCommitAfterAsync( TEntity entity, ChangeValueCollection changeValues ) {
            return Task.CompletedTask;
        }

        #endregion

        #region DeleteAsync(删除)

        /// <inheritdoc />
        public virtual async Task DeleteAsync( string ids ) {
            if ( ids.IsEmpty() )
                return;
            var entities = await _repository.FindByIdsAsync( ids );
            if ( entities?.Count == 0 )
                return;
            await DeleteBeforeAsync( entities );
            await _repository.RemoveAsync( entities );
            await DeleteAfterAsync( entities );
            await CommitAsync();
            await DeleteCommitAfterAsync( entities );
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

        /// <summary>
        /// 删除提交后操作
        /// </summary>
        /// <param name="entities">实体集合</param>
        protected virtual Task DeleteCommitAfterAsync( List<TEntity> entities ) {
            return Task.CompletedTask;
        }

        #endregion

        #region EnableAsync(启用)

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual async Task EnableAsync( string ids ) {
            await Enable( ids, true );
        }

        /// <summary>
        /// 启用
        /// </summary>
        private async Task Enable( string ids, bool enabled ) {
            if ( ids.IsEmpty() )
                return;
            var entities = await _repository.FindByIdsAsync( ids );
            if ( entities == null || entities.Count == 0 )
                return;
            foreach ( var entity in entities ) {
                if ( enabled && await AllowEnable( entity ) == false )
                    return;
                if ( enabled == false && await AllowDisable( entity ) == false )
                    return;
                entity.Enabled = enabled;
                await _repository.UpdateAsync( entity );
            }
            await CommitAsync();
            if ( enabled ) {
                await EnableCommitAfterAsync( entities );
                return;
            }
            await DisableCommitAfterAsync( entities );
        }

        /// <summary>
        /// 允许启用
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual Task<bool> AllowEnable( TEntity entity ) {
            return Task.FromResult( true );
        }

        /// <summary>
        /// 允许禁用
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual Task<bool> AllowDisable( TEntity entity ) {
            return Task.FromResult( true );
        }

        /// <summary>
        /// 启用提交后操作
        /// </summary>
        /// <param name="entities">实体集合</param>
        protected virtual Task EnableCommitAfterAsync( List<TEntity> entities ) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 禁用提交后操作
        /// </summary>
        /// <param name="entities">实体集合</param>
        protected virtual Task DisableCommitAfterAsync( List<TEntity> entities ) {
            return Task.CompletedTask;
        }

        #endregion

        #region DisableAsync(禁用)

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual Task DisableAsync( string ids ) {
            return Enable( ids, false );
        }

        #endregion
    }
}
