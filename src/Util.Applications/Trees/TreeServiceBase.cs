using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Datas.Queries.Trees;
using Util.Datas.Stores;
using Util.Datas.UnitOfWorks;
using Util.Domains;
using Util.Domains.Trees;
using Convert = Util.Helpers.Convert;

namespace Util.Applications.Trees {
    /// <summary>
    /// 树形服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public abstract partial class TreeServiceBase<TEntity, TDto, TQueryParameter>
        : TreeServiceBase<TEntity, TDto, TQueryParameter, Guid, Guid?>, ITreeService<TDto, TQueryParameter>
        where TEntity : class, IParentId<Guid?>, IPath, IEnabled, ISortId, IKey<Guid>, IVersion, new()
        where TDto : class, ITreeNode, new()
        where TQueryParameter : class, ITreeQueryParameter {
        /// <summary>
        /// 存储器
        /// </summary>
        private readonly IStore<TEntity, Guid> _store;

        /// <summary>
        /// 初始化树形服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="store">存储器</param>
        protected TreeServiceBase( IUnitOfWork unitOfWork, IStore<TEntity, Guid> store ) : base( unitOfWork, store ) {
            _store = store;
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<TEntity> Filter( IQueryable<TEntity> queryable, TQueryParameter parameter ) {
            return queryable.Where( new TreeCriteria<TEntity>( parameter ) );
        }

        /// <summary>
        /// 获取直接下级子节点列表
        /// </summary>
        /// <param name="parameter">查询参数</param>
        protected override async Task<List<TEntity>> GetChildren( TQueryParameter parameter ) {
            return await _store.FindAllAsync( t => t.ParentId == parameter.ParentId );
        }
    }

    /// <summary>
    /// 树形服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class TreeServiceBase<TEntity, TDto, TQueryParameter, TKey, TParentId>
        : DeleteServiceBase<TEntity, TDto, TQueryParameter, TKey>, ITreeService<TDto, TQueryParameter, TParentId>
        where TEntity : class, IParentId<TParentId>, IPath, IEnabled, ISortId, IKey<TKey>, IVersion, new()
        where TDto : class, ITreeNode, new()
        where TQueryParameter : class, ITreeQueryParameter<TParentId> {
        /// <summary>
        /// 工作单元
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// 存储器
        /// </summary>
        private readonly IStore<TEntity, TKey> _store;

        /// <summary>
        /// 初始化树形服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="store">存储器</param>
        protected TreeServiceBase( IUnitOfWork unitOfWork, IStore<TEntity, TKey> store ) : base( unitOfWork, store ) {
            _unitOfWork = unitOfWork;
            _store = store;
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<TEntity> Filter( IQueryable<TEntity> queryable, TQueryParameter parameter ) {
            return queryable.Where( new TreeCriteria<TEntity, TParentId>( parameter ) );
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual async Task<List<TDto>> FindByIdsAsync( string ids ) {
            var entities = await _store.FindByIdsNoTrackingAsync( ids );
            return entities.Select( ToDto ).ToList();
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual async Task EnableAsync( string ids ) {
            await Enable( Convert.ToList<TKey>( ids ), true );
        }

        /// <summary>
        /// 启用
        /// </summary>
        private async Task Enable( List<TKey> ids, bool enabled ) {
            if( ids == null || ids.Count == 0 )
                return;
            var entities = await _store.FindByIdsAsync( ids );
            if( entities == null )
                return;
            foreach ( var entity in entities ) {
                if( enabled && await AllowEnable( entity ) == false )
                    return;
                if( enabled == false && await AllowDisable( entity ) == false )
                    return;
                entity.Enabled = enabled;
                await _store.UpdateAsync( entity );
            }
            _unitOfWork.Commit();
            WriteLog( entities, enabled );
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
        /// 写日志
        /// </summary>
        private void WriteLog( List<TEntity> entities, bool enabled ) {
            AddLog( entities );
            WriteLog( $"{( enabled ? "启用" : "冻结" )}成功" );
        }

        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="ids">标识列表</param>
        public virtual Task DisableAsync( string ids ) {
            return Enable( Convert.ToList<TKey>( ids ), false );
        }

        /// <summary>
        /// 交换排序
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="swapId">目标标识</param>
        public virtual async Task SwapSortAsync( Guid id, Guid swapId ) {
            var entity = await _store.FindAsync( id );
            var swapEntity = await _store.FindAsync( swapId );
            if( entity == null || swapEntity == null )
                return;
            entity.SwapSort( swapEntity );
            await _store.UpdateAsync( entity );
            await _store.UpdateAsync( swapEntity );
            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// 修正排序
        /// </summary>
        /// <param name="parameter">查询参数</param>
        public virtual async Task FixSortIdAsync( TQueryParameter parameter ) {
            var children = await GetChildren( parameter );
            if ( children == null )
                return;
            var list = children.OrderBy( t => t.SortId ).ToList();
            for ( int i = 0; i < children.Count; i++ )
                children[i].SortId = i + 1;
            await _store.UpdateAsync( list );
            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// 获取直接下级子节点列表
        /// </summary>
        /// <param name="parameter">查询参数</param>
        protected abstract Task<List<TEntity>> GetChildren( TQueryParameter parameter );
    }
}
