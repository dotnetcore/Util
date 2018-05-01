using System;
using Util.Datas.Stores.Operations;
using Util.Domains;

namespace Util.Datas.Stores {
    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    public interface IStore<TEntity> : IStore<TEntity, Guid>
        where TEntity : class, IKey<Guid>, IVersion {
    }

    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IStore<TEntity, in TKey> : IQueryStore<TEntity, TKey>,
        IAdd<TEntity, TKey>, IAddAsync<TEntity, TKey>,
        IUpdate<TEntity, TKey>, IUpdateAsync<TEntity, TKey>,
        IRemove<TEntity, TKey>, IRemoveAsync<TEntity, TKey>
        where TEntity : class, IKey<TKey>, IVersion {
    }
}
