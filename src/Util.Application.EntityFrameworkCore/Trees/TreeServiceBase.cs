using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Data;
using Util.Data.Stores;
using Util.Data.Trees;
using Util.Domain;
using Util.Domain.Trees;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    public abstract class TreeServiceBase<TEntity, TDto, TQuery>
        : TreeServiceBase<TEntity, TDto, TQuery, Guid, Guid?>
        where TEntity : class, IParentId<Guid?>, IPath, IEnabled, ISortId, IKey<Guid>, IVersion, new()
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {
        /// <summary>
        /// 初始化树形服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="store">存储器</param>
        protected TreeServiceBase( IServiceProvider serviceProvider, IUnitOfWork unitOfWork, IStore<TEntity, Guid> store ) : base( serviceProvider,unitOfWork, store ) {
        }
    }

    /// <summary>
    /// 树形服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class TreeServiceBase<TEntity, TDto, TQuery, TKey, TParentId>
        : QueryServiceBase<TEntity, TDto, TQuery, TKey>, ITreeService<TDto, TQuery>
        where TEntity : class, IParentId<TParentId>, IPath, IEnabled, ISortId, IKey<TKey>, IVersion, new()
        where TDto : class, ITreeNode, new()
        where TQuery : class, ITreeQueryParameter {

        #region 字段

        /// <summary>
        /// 存储器
        /// </summary>
        private readonly IStore<TEntity, TKey> _store;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化树形服务
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="store">存储器</param>
        protected TreeServiceBase( IServiceProvider serviceProvider, IUnitOfWork unitOfWork, IStore<TEntity, TKey> store ) : base( serviceProvider, store ) {
            UnitOfWork = unitOfWork;
            _store = store;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 工作单元
        /// </summary>
        protected IUnitOfWork UnitOfWork { get; }

        #endregion

        #region Filter(过滤)

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<TEntity> Filter( IQueryable<TEntity> queryable, TQuery parameter ) {
            return queryable.Where( new TreeCondition<TEntity, TParentId>( parameter ) );
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
            if( ids.IsEmpty() == false )
                return;
            var entities = await _store.FindByIdsAsync( ids );
            if( entities == null )
                return;
            foreach( var entity in entities ) {
                if( enabled && await AllowEnable( entity ) == false )
                    return;
                if( enabled == false && await AllowDisable( entity ) == false )
                    return;
                entity.Enabled = enabled;
                await _store.UpdateAsync( entity );
            }
            await CommitAsync();
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
        /// 提交工作单元
        /// </summary>
        protected virtual async Task CommitAsync() {
            await UnitOfWork.CommitAsync();
        }

        #endregion

        #region DisableAsync(冻结)

        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual Task DisableAsync( string ids ) {
            return Enable( ids, false );
        }

        #endregion

        #region DeleteAsync(删除)

        /// <inheritdoc />
        public virtual async Task DeleteAsync( string ids ) {
            if( ids.IsEmpty() )
                return;
            var entities = await _store.FindByIdsAsync( ids );
            if( entities?.Count == 0 )
                return;
            await DeleteBeforeAsync( entities );
            await _store.RemoveAsync( entities );
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
