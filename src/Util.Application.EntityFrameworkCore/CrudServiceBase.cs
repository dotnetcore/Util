using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Applications.Dtos;
using Util.Data;
using Util.Data.Queries;
using Util.Domain.Compare;
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
        where TDto : class, IDto, new()
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
        where TDto : class, IDto, new()
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
    public abstract class CrudServiceBase<TEntity, TDto, TCreateRequest, TUpdateRequest, TQuery> 
            : CrudServiceBase<TEntity, TDto, TCreateRequest, TUpdateRequest, TQuery, Guid>
        where TEntity : class, IAggregateRoot<TEntity, Guid>, new()
        where TDto : class, IDto, new()
        where TCreateRequest : class, IRequest, new()
        where TUpdateRequest : class, IDto, new()
        where TQuery : IPage {
        /// <summary>
        /// 初始化增删改查服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected CrudServiceBase( IServiceProvider serviceProvider, IUnitOfWork unitOfWork, IRepository<TEntity, Guid> repository ) : base( serviceProvider, unitOfWork, repository ) {
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
        where TDto : class,IDto, new()
        where TCreateRequest : class, IRequest, new()
        where TUpdateRequest : class, IDto, new()
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
        protected virtual Task UpdateCommitAfterAsync( TEntity entity,ChangeValueCollection changeValues ) {
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

        #region SaveAsync(批量保存)

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="creationList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        public virtual async Task<List<TDto>> SaveAsync( List<TDto> creationList, List<TDto> updateList, List<TDto> deleteList ) {
            if ( creationList == null && updateList == null && deleteList == null )
                return new List<TDto>();
            creationList ??= new List<TDto>();
            updateList ??= new List<TDto>();
            deleteList ??= new List<TDto>();
            FilterList( creationList, updateList, deleteList );
            var addEntities = ToEntities( creationList );
            var updateEntities = ToEntities( updateList );
            var deleteEntities = ToEntities( deleteList );
            await SaveBeforeAsync( addEntities, updateEntities, deleteEntities );
            await AddListAsync( addEntities );
            var changeValues = await UpdateListAsync( updateEntities );
            await DeleteListAsync( deleteEntities );
            await SaveAfterAsync( addEntities, updateEntities, deleteEntities );
            await CommitAsync();
            await SaveCommitAfterAsync( addEntities, updateEntities, deleteEntities, changeValues );
            return GetResult( addEntities, updateEntities );
        }

        /// <summary>
        /// 过滤列表
        /// </summary>
        private void FilterList( List<TDto> creationList, List<TDto> updateList, List<TDto> deleteList ) {
            FilterByDeleteList( creationList, deleteList );
            FilterByDeleteList( updateList, deleteList );
        }

        /// <summary>
        /// 过滤需要删除的项
        /// </summary>
        private void FilterByDeleteList( List<TDto> list, List<TDto> deleteList ) {
            for ( int i = 0; i < list.Count; i++ ) {
                var item = list[i];
                if ( deleteList.Any( d => d.Id == item.Id ) )
                    list.Remove( item );
            }
        }

        /// <summary>
        /// 转换为实体集合
        /// </summary>
        private List<TEntity> ToEntities( List<TDto> dtos ) {
            return dtos.Select( ToEntity ).Distinct().ToList();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="request">参数</param>
        protected virtual TEntity ToEntity( TDto request ) {
            return request.MapTo<TEntity>();
        }

        /// <summary>
        /// 保存前操作
        /// </summary>
        /// <param name="creationList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        protected virtual Task SaveBeforeAsync( List<TEntity> creationList, List<TEntity> updateList, List<TEntity> deleteList ) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 添加实体列表
        /// </summary>
        private async Task AddListAsync( List<TEntity> list ) {
            if ( list.Count == 0 )
                return;
            foreach ( var entity in list )
                await CreateAsync( entity );
        }

        /// <summary>
        /// 更新实体列表
        /// </summary>
        private async Task<List<Tuple<TEntity, ChangeValueCollection>>> UpdateListAsync( List<TEntity> list ) {
            var result = new List<Tuple<TEntity,ChangeValueCollection>>();
            if ( list.Count == 0 )
                return result;
            var oldEntities = await FindOldEntities( list );
            foreach ( var entity in list ) {
                var oldEntity = oldEntities.Find( t => t.Id.Equals( entity.Id ) );
                if ( oldEntity != null )
                    result.Add( new Tuple<TEntity, ChangeValueCollection>( entity, oldEntity.GetChanges( entity ) ) );
                await UpdateAsync( entity );
            }
            return result;
        }

        /// <summary>
        /// 查找旧实体集合
        /// </summary>
        private async Task<List<TEntity>> FindOldEntities( List<TEntity> list ) {
            return await _repository.FindAllAsync( item => list.Select( t => t.Id ).Contains( item.Id ) );
        }

        /// <summary>
        /// 删除实体列表
        /// </summary>
        private async Task DeleteListAsync( List<TEntity> list ) {
            if ( list.Count == 0 )
                return;
            foreach ( var entity in list )
                await DeleteChildrenAsync( entity );
        }

        /// <summary>
        /// 删除子节点集合
        /// </summary>
        protected virtual async Task DeleteChildrenAsync( TEntity parent ) {
            await _repository.RemoveAsync( parent.Id );
        }

        /// <summary>
        /// 保存后操作
        /// </summary>
        /// <param name="creationList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        protected virtual Task SaveAfterAsync( List<TEntity> creationList, List<TEntity> updateList, List<TEntity> deleteList ) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 保存提交后操作
        /// </summary>
        /// <param name="creationList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        /// <param name="changeValues">变更值集合</param>
        protected virtual Task SaveCommitAfterAsync( List<TEntity> creationList, List<TEntity> updateList, List<TEntity> deleteList, List<Tuple<TEntity, ChangeValueCollection>> changeValues ) {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        protected virtual List<TDto> GetResult( List<TEntity> creationList, List<TEntity> updateList ) {
            return creationList.Concat( updateList ).Select( ToDto ).ToList();
        }

        #endregion
    }
}
