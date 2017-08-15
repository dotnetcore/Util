namespace Util.Domains {
    /// <summary>
    /// 实体
    /// </summary>
    public interface IEntity : IDomainObject {
        /// <summary>
        /// 初始化
        /// </summary>
        void Init();
    }

    /// <summary>
    /// 实体
    /// </summary>
    /// <typeparam name="TKey">标识类型</typeparam>
    public interface IEntity<out TKey> : IKey<TKey>, IEntity {
    }

    /// <summary>
    /// 实体
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">标识类型</typeparam>
    public interface IEntity<in TEntity, out TKey> : ICompareChange<TEntity>, IEntity<TKey> where TEntity : IEntity {
    }
}
