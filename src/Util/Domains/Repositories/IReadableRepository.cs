using System;

namespace Util.Domains.Repositories {
    /// <summary>
    /// 仓储 - 可读
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IReadableRepository<TEntity> : IReadableRepository<TEntity, Guid> where TEntity : class, IAggregateRoot {
    }

    /// <summary>
    /// 仓储 - 可读
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface IReadableRepository<TEntity, in TKey> : IReadableRepository<TEntity, TEntity, TKey> where TEntity : class, IAggregateRoot {
    }

    /// <summary>
    /// 仓储 - 可读
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPersistObject">持久化对象类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface IReadableRepository<TEntity, TPersistObject, in TKey> where TEntity : class, IAggregateRoot where TPersistObject : class {
    }
}
