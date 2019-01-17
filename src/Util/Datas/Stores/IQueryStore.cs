using System;
using Util.Datas.Stores.Operations;
using Util.Dependency;
using Util.Domains;

namespace Util.Datas.Stores {
    /// <summary>
    /// 查询存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    public interface IQueryStore<TEntity> : IQueryStore<TEntity, Guid>
        where TEntity : class, IKey<Guid> {
    }

    /// <summary>
    /// 查询存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IQueryStore<TEntity, in TKey> : IScopeDependency,
        IFindQueryable<TEntity, TKey>,
        IFindById<TEntity, TKey>, 
        IFindByIdAsync<TEntity, TKey>,
        IFindByIds<TEntity, TKey>, 
        IFindByIdsAsync<TEntity, TKey>,
        IFindByIdNoTracking<TEntity, TKey>, 
        IFindByIdNoTrackingAsync<TEntity, TKey>,
        IFindByIdsNoTracking<TEntity, TKey>, 
        IFindByIdsNoTrackingAsync<TEntity, TKey>,
        ISingle<TEntity, TKey>, 
        ISingleAsync<TEntity, TKey>,
        IFindAll<TEntity, TKey>, 
        IFindAllAsync<TEntity, TKey>,
        IFindAllNoTracking<TEntity, TKey>, 
        IFindAllNoTrackingAsync<TEntity, TKey>,
        IExists<TEntity, TKey>, 
        IExistsAsync<TEntity, TKey>,
        IExistsByExpression<TEntity, TKey>, 
        IExistsByExpressionAsync<TEntity, TKey>,
        ICount<TEntity, TKey>, 
        ICountAsync<TEntity, TKey>,
        IPageQuery<TEntity, TKey>, 
        IPageQueryAsync<TEntity, TKey>
        where TEntity : class, IKey<TKey> {
    }
}
