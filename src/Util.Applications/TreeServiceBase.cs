using System;
using System.Linq;
using Util.Applications.Dtos;
using Util.Datas.Queries;
using Util.Datas.Queries.Trees;
using Util.Domains.Repositories;
using Util.Domains.Trees;

namespace Util.Applications {
    /// <summary>
    /// 树型服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public abstract class TreeServiceBase<TEntity, TDto, TQueryParameter>
        : QueryServiceBase<TEntity, TDto, TQueryParameter, Guid>, ITreeService<TDto, TQueryParameter>
        where TEntity : class, ITreeEntity<TEntity, Guid, Guid?>
        where TDto : class, IResponse, ITreeNode, new()
        where TQueryParameter : class, ITreeQueryParameter {
        /// <summary>
        /// 初始化树型服务
        /// </summary>
        /// <param name="repository">仓储</param>
        protected TreeServiceBase( IRepository<TEntity, Guid> repository ) : base( repository ) {
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<TEntity> Filter( IQueryable<TEntity> queryable, TQueryParameter parameter ) {
            return queryable.Where( new TreeCriteria<TEntity>( parameter ) );
        }
    }

    /// <summary>
    /// 树型服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class TreeServiceBase<TEntity, TDto, TQueryParameter, TKey, TParentId>
        : QueryServiceBase<TEntity, TDto, TQueryParameter, TKey>, ITreeService<TDto, TQueryParameter, TParentId>
        where TEntity : class, ITreeEntity<TEntity, TKey, TParentId>
        where TDto : class, IResponse, ITreeNode, new()
        where TQueryParameter : class, ITreeQueryParameter<TParentId> {
        /// <summary>
        /// 初始化树型服务
        /// </summary>
        /// <param name="repository">仓储</param>
        protected TreeServiceBase( IRepository<TEntity, TKey> repository ) : base( repository ) {
        }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<TEntity> Filter( IQueryable<TEntity> queryable, TQueryParameter parameter ) {
            return queryable.Where( new TreeCriteria<TEntity, TKey, TParentId>( parameter ) );
        }
    }
}
