using System;

namespace Util.Domains.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : class, IAggregateRoot {
    }

    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface IRepository<TEntity, in TKey> : IRepository<TEntity, TEntity, TKey> where TEntity : class, IAggregateRoot {
    }

    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPersistObject">持久化对象类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface IRepository<TEntity, TPersistObject, in TKey> : IReadableRepository<TEntity, TPersistObject, TKey> 
        where TEntity : class, IAggregateRoot
        where TPersistObject : class {
    }
}
